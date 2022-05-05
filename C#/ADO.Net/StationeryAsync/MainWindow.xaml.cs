using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace _11._02._2022
{

    public partial class MainWindow : Window
    {
        private delegate void AsyncAdapterFunc(SqlDataAdapter adapter, DataTable table);

        private AsyncAdapterFunc UpdateTableFunc;
        private AsyncAdapterFunc FillTableFunc;

        private SqlConnection Connection;
        private DataTable DataTable;
        private SqlDataAdapter MainAdapter;

        private string ConnectionString = "Data Source=DESKTOP-8PVIEVM;Initial Catalog=StationeryFirm;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public MainWindow()
        {
            InitializeComponent();

            UpdateTableFunc = new AsyncAdapterFunc((adapter, table) =>
            {
                try
                {
                    adapter.Update(table);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                }
                
            });
            FillTableFunc = new AsyncAdapterFunc((adapter, table) =>
            {
                adapter.Fill(table);
            });
        }


        #region Update/Save/Fill functions

        private void FillTableCB(IAsyncResult ar)
        {
            FillTableFunc.EndInvoke(ar);

            Action tmp = () =>
            {
                MainDataGrid.ItemsSource = null;
                MainDataGrid.ItemsSource = DataTable.DefaultView;
            }; 

            if (!CheckAccess()) 
                Dispatcher.Invoke(tmp);
            else
                tmp.Invoke();
        }

        private void UpdateTableCB(IAsyncResult ar)
        {
            UpdateTableFunc.EndInvoke(ar);
            FillTableFunc.BeginInvoke(MainAdapter, DataTable, FillTableCB, null);
        }


        #endregion

        #region Buttons/UI Elements

        private void ComboBox_Tables_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Connection == null)
                return;

            MainAdapter = new SqlDataAdapter($"select * from {ComboBox_Tables.SelectedItem}", ConnectionString);
            DataTable = new DataTable();

            FillTableFunc.BeginInvoke(MainAdapter, DataTable, FillTableCB, null);


        }

        private void BTN_Connection_OnClick(object sender, RoutedEventArgs e)
        {
            if (Connection == null)
            {
                Connection = new SqlConnection(ConnectionString);
                try
                {
                    Connection.Open();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Подключение установить не удалось. {exception.Message}", "Сбой подключения", MessageBoxButton.OK, MessageBoxImage.Error);
                    Connection = null;
                    return;
                }

                MessageBox.Show("Connection success!", "Connection Info", MessageBoxButton.OK, MessageBoxImage.Information);

                SqlCommand tmpCommand = new SqlCommand("select [name] from sys.tables where [name] <> 'sysdiagrams';", Connection);
                SqlDataReader reader = tmpCommand.ExecuteReader();


                while (reader.Read())
                    for (int i = 0; i < reader.FieldCount; i++)
                        ComboBox_Tables.Items.Add(reader[i]);
                reader.Close();


                if (ComboBox_Tables.Items.Count > 0)
                {
                    ComboBox_Tables.SelectedIndex = 0;
                    MainDataGrid.Visibility = Visibility.Visible;
                    BTN_Save.IsEnabled = true;
                    ComboBox_Tables.IsEnabled = true;
                    BTN_Update.IsEnabled = true;
                    BTN_Connection.Content = "Disconnect";
                }
            }
            else
            {
                Connection.Close();
                Connection = null;

                DataTable.Clear();
                DataTable = null;


                MainDataGrid.ItemsSource = null;
                ComboBox_Tables.Items.Clear();


                MainDataGrid.Visibility = Visibility.Hidden;
                BTN_Save.IsEnabled = false;
                ComboBox_Tables.IsEnabled = false;
                BTN_Update.IsEnabled = false;
                BTN_Connection.Content = "Connect";

            }
        }

        private void BTN_Save_OnClick(object sender, RoutedEventArgs e)
        {
            if (MainAdapter == null || Connection == null) return;

            SqlCommandBuilder CommandBuilder = new SqlCommandBuilder(MainAdapter);

            UpdateTableFunc.BeginInvoke(MainAdapter, DataTable, UpdateTableCB, null);
        }

        private void BTN_Update_OnClick(object sender, RoutedEventArgs e)
        {
            if (Connection == null)
                return;

            MainAdapter = new SqlDataAdapter($"select * from {ComboBox_Tables.SelectedItem}", ConnectionString);
            DataTable = new DataTable();

            FillTableFunc.BeginInvoke(MainAdapter, DataTable, FillTableCB, null);
        }

        #endregion



    }
}
