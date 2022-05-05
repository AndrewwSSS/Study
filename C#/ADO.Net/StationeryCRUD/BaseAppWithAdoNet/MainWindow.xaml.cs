using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BaseAppWithAdoNet
{
    public partial class MainWindow : Window
    {
        private delegate void AsyncAdapterFunc(SqlDataAdapter adapter, DataTable table);

        private AsyncAdapterFunc UpdateTableFunc;
        private AsyncAdapterFunc FillTableFunc;

        private SqlConnection Connection;
        private DataTable MainTable;
        private SqlDataAdapter adapter;
        private string ConnectionString = "Data Source=DESKTOP-8PVIEVM;Initial Catalog=StationeryFirm;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public MainWindow()
        {
            InitializeComponent();

            UpdateTableFunc = new AsyncAdapterFunc((adapter, table) =>
            {
                adapter.Update(table);
            });

            FillTableFunc = new AsyncAdapterFunc((adapter, table) =>
            {
                adapter.Fill(table);
            });

        }

        #region Update/Save/Fill functions

            private void FillTableAsync(IAsyncResult ar)
            {
                FillTableFunc.EndInvoke(ar);

                Action tmp = () =>
                {
                    if (Connection == null)
                        return;

                    MainTable = new DataTable();
                    adapter = new SqlDataAdapter($"select * from {ComboBox_Tables.SelectedItem}", Connection);

                    adapter.Fill(MainTable);
                    MainDataGrid.ItemsSource = MainTable.DefaultView;
                };

               
                if (!CheckAccess())
                    Dispatcher.Invoke(tmp);
                else
                    tmp.Invoke();
            }

        #endregion


        private void ComboBox_Tables_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            FillTableFunc.BeginInvoke(adapter, MainTable, FillTableAsync, null);




        }

        private void BTN_Connection_OnClick(object sender, RoutedEventArgs e)
        {
            if (Connection == null)
            {
                Connection = new SqlConnection(ConnectionString);
                try
                {
                    Connection.OpenAsync();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Подключение установить не удалось. {exception.Message}", "Сбой подключения", MessageBoxButton.OK, MessageBoxImage.Error);
                    Connection = null;
                    return;
                }

                MessageBox.Show("Подключение прошло успешно", "Успешное подключение", MessageBoxButton.OK, MessageBoxImage.Information);
                SqlCommand tmpCommand = new SqlCommand("select [name] from sys.tables where [name] <> 'sysdiagrams';", Connection);

                SqlDataReader reader = tmpCommand.ExecuteReader();
                while (reader.Read())
                    for(int i = 0; i < reader.FieldCount; i++)
                        ComboBox_Tables.Items.Add(reader[i]);
                reader.CloseAsync();

                
                if (ComboBox_Tables.Items.Count > 0)
                    ComboBox_Tables.SelectedItem = ComboBox_Tables.Items[0];

                MainDataGrid.Visibility = Visibility.Visible;
                BTN_Save.IsEnabled = true;
                ComboBox_Tables.IsEnabled = true;
                //BTN_DeleteRow.IsEnabled = true;
                BTN_Update.IsEnabled = true;
                BTN_Connection.Content = "Disconnect";
            }
            else
            {
                Connection.CloseAsync();
                Connection = null;

                MainTable.Clear();
                MainTable = null;


                MainDataGrid.ItemsSource = null;
                ComboBox_Tables.Items.Clear();


                MainDataGrid.Visibility = Visibility.Hidden;
                BTN_Save.IsEnabled = false;
                ComboBox_Tables.IsEnabled = false;
                //BTN_DeleteRow.IsEnabled = false;
                BTN_Update.IsEnabled = false;
                BTN_Connection.Content = "Connect";

            }
        }

        private  void BTN_Save_OnClick(object sender, RoutedEventArgs e)
        {
            if (adapter != null || Connection == null) return;

            SqlCommandBuilder CommandBuilder = new SqlCommandBuilder(adapter);

            try
            {
                adapter.Update(MainTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            MainDataGrid.ItemsSource = null;
            MainTable = new DataTable(ComboBox_Tables.Text); 
            adapter.Fill(MainTable);
            MainDataGrid.ItemsSource = MainTable.DefaultView;
        }

        private void BTN_Update_OnClick(object sender, RoutedEventArgs e)
        {
            if (Connection == null)
                return;

            MainTable = new DataTable();
            adapter = new SqlDataAdapter($"select * from {ComboBox_Tables.SelectedItem}", Connection);
            adapter.Fill(MainTable);
            MainDataGrid.ItemsSource = MainTable.DefaultView;
        }
    }
}
