using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BaseConnectToDbWithAdoNet
{
    public partial class MainWindow : Window
    {
        private delegate void AsyncAdapterFunc(SqlDataAdapter adapter, DataTable table);
        private AsyncAdapterFunc SaveChengesFunc;
        private AsyncAdapterFunc FillTableFunc;
        private SqlDataAdapter MainAdapter;
        private SqlConnection Connection;
        private DataTable CurrentTable;
        private Dictionary<string, DataTable> Tables;
        private string ConnectionString;

        public MainWindow()
        {
            InitializeComponent();

            SaveChengesFunc = new AsyncAdapterFunc((adapter, table) =>
            {
                try
                {
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(table);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                }
            });
            FillTableFunc = new AsyncAdapterFunc((adapter, table) =>
            {
                table.Clear();
                adapter.Fill(table);
            });

            ChoiceDbWindow window = new ChoiceDbWindow();
            
            window.ShowDialog();
            ConnectionString = window.ConnectionString;
        }


        #region Refresh/Fill functions

        private void FillTableCB(IAsyncResult ar)
        {
            FillTableFunc.EndInvoke(ar);

            Action tmp = () =>
            {
                MainDataGrid.ItemsSource = null;
                MainDataGrid.ItemsSource = CurrentTable.DefaultView;
            };

            if (!CheckAccess())
                Dispatcher.Invoke(tmp);
            else
                tmp.Invoke();
        }

        private void SaveChangesCB(IAsyncResult ar)
        {
            SaveChengesFunc.EndInvoke(ar);
            FillTableFunc.BeginInvoke(MainAdapter, CurrentTable, FillTableCB, null);
        }

        private void SaveChanges()
        {
            SaveChengesFunc.BeginInvoke(MainAdapter, CurrentTable, SaveChangesCB, null);
        }

        private void Refresh()
        {
            if(Connection == null) 
                return;

            if (!Tables.ContainsKey(ComboBox_Tables.SelectedItem.ToString()))
                Tables[ComboBox_Tables.SelectedItem.ToString()] = new DataTable();
            
            CurrentTable = Tables[ComboBox_Tables.SelectedItem.ToString()];

            FillTableFunc.BeginInvoke(MainAdapter, CurrentTable, FillTableCB, null);
        }

        #endregion


        #region Buttons/UI Elements

        private void ComboBox_Tables_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainAdapter = new SqlDataAdapter($"select * from {ComboBox_Tables.SelectedItem}", ConnectionString);
            Refresh();
        }

        private void BTN_Connection_OnClick(object sender, RoutedEventArgs e)
        {
            if (Connection == null)
            {
                Connect();
            }
            else
            {
                Disconnect();
            }
        }

        private void Connect()
        {
            Connection = new SqlConnection(ConnectionString);
            try
            {
                Connection.Open();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Connection failed. {exception.Message}", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Connection = null;
                return;
            }
            finally
            {
                MessageBox.Show("Connection success!", "Connection Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            SqlCommand tmpCommand = new SqlCommand("select [name] from sys.tables where [name] <> 'sysdiagrams';", Connection);
            SqlDataReader reader = tmpCommand.ExecuteReader();


            while (reader.Read())
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ComboBox_Tables.Items.Add(reader[i]);
                }

            reader.Close();

            Tables = new Dictionary<string, DataTable>();

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

        private void Disconnect()
        {
            Connection.Close();
            Connection = null;

            CurrentTable.Clear();
            CurrentTable = null;



            MainDataGrid.ItemsSource = null;
            ComboBox_Tables.Items.Clear();

            Tables.Clear();

            MainDataGrid.Visibility = Visibility.Hidden;
            BTN_Save.IsEnabled = false;
            ComboBox_Tables.IsEnabled = false;
            BTN_Update.IsEnabled = false;
            BTN_Connection.Content = "Connect";
        }


        private void BTN_Save_OnClick(object sender, RoutedEventArgs e)
        {
            SaveChanges();
        }

        private void BTN_Update_OnClick(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        #endregion


        private void BTN_ChangeDb_OnClick(object sender, RoutedEventArgs e)
        {

            if (Connection != null)
            {

                if (MessageBox.Show("Last session dont closed. Close now?",
                        "",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
                else
                    this.Disconnect();
            }

            ChoiceDbWindow window = new ChoiceDbWindow();
            window.ShowDialog();
            ConnectionString = window.ConnectionString;
        }
    }
}
