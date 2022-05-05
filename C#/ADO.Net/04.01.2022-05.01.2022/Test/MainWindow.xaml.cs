using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;

namespace Test
{

    public partial class MainWindow : Window
    {
        private SqlConnection Connection;
        private DataTable MainTable;
        private SqlDataAdapter MainAdapter;
        private string ConnectionString = "Data Source=DESKTOP-8PVIEVM;Initial Catalog=VegetablesAndFruits;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public MainWindow()
        {
            InitializeComponent();

            BTN_AVGCalories.IsEnabled = false;
            BTN_MaxCalories.IsEnabled = false;
            BTN_MinCalories.IsEnabled = false;
            BTN_Reload.IsEnabled = false;
            BTN_Save.IsEnabled = false;
            BTN_ShowColors.IsEnabled = false;
            BTN_ShowNames.IsEnabled = false;
            BTN_CountFruit.IsEnabled = false;
            BTN_CountVegetables.IsEnabled = false;
            BTN_CountByColor.IsEnabled = false;
            TB_Color.IsEnabled = false;

            TB_MoreCalories.IsEnabled = false;
            TB_LessCalories.IsEnabled = false;
            TB_ColorLess.IsEnabled = false;
            TB_ColoriesMore.IsEnabled = false;

            BTN_CountByCalless.IsEnabled = false;
            BTN_CountByCaloriesMore.IsEnabled = false;
            BTN_CaloriesBetween.IsEnabled = false;
            BTN_ShowAllProdColorYellowOrRed.IsEnabled = false;
            BTN_ShowAllProdByColor.IsEnabled = false;
            MainAdapter = new SqlDataAdapter();

        }


        private void BTN_Save_OnClick(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void BTN_Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            MainTable.Clear();
            MainAdapter = new SqlDataAdapter($"select * from VegetablesAndFruits", Connection);
            MainAdapter.Fill(MainTable);
            MainDataGrid.ItemsSource = MainTable.DefaultView;
        }

        private void BTN_ShowNames_OnClick(object sender, RoutedEventArgs e)
        {

            SqlDataAdapter tmpAdapter =
                new SqlDataAdapter($"select distinct [Name] from FruitsAndVegetables", ConnectionString);

            DataTable tmpTable = new DataTable();
            tmpAdapter.Fill(tmpTable);

            ItemsWindow form = new ItemsWindow(tmpTable);

            form.ShowDialog();
        }

        private void BTN_ShowColors_OnClick(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter tmpAdapter = new SqlDataAdapter($"select distinct [Color] from FruitsAndVegetables", Connection);
            DataTable tmpTable = new DataTable();
            tmpAdapter.Fill(tmpTable);

            ItemsWindow itemsWindow = new ItemsWindow(tmpTable);

            itemsWindow.ShowDialog();
        }

        private void BTN_MaxCalories_OnClick(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter tmpAdapter = new SqlDataAdapter($"select Top 1 Max(Calories) from FruitsAndVegetables", Connection);
            DataTable tmpTable = new DataTable();

            tmpAdapter.Fill(tmpTable);
            MessageBox.Show("Максимальная калорийность: " + tmpTable.Rows[0].ItemArray[0]);
        }

        private void BTN_MinCalories_OnClick(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter tmpAdapter = new SqlDataAdapter($"select Top 1 Min(Calories) from FruitsAndVegetables", Connection);
            DataTable tmpTable = new DataTable();

            tmpAdapter.Fill(tmpTable);
            MessageBox.Show("Минимальная калорийность: " + tmpTable.Rows[0].ItemArray[0]);
        }

        private void Save()
        {
            if (MainAdapter == null) return;

            SqlCommandBuilder CommandBuilder = new SqlCommandBuilder(MainAdapter);

            try
            {
                MainAdapter.Update(MainTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            MainDataGrid.ItemsSource = null;
            MainTable = new DataTable("VegetablesAndFruits");
            MainAdapter.Fill(MainTable);
            MainDataGrid.ItemsSource = MainTable.DefaultView;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if(Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        private void BTN_AVGCalories_OnClick(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter tmpAdapter = new SqlDataAdapter($"select Top 1 Avg(Calories) from FruitsAndVegetables", ConnectionString);
            DataTable tmpTable = new DataTable();
            tmpAdapter.Fill(tmpTable);
            MessageBox.Show("Средняя калорийность: " + tmpTable.Rows[0].ItemArray[0]);
        }

        private void BTN_ConnectAndDisconnect_OnClick(object sender, RoutedEventArgs e)
        {

            if (BTN_ConnectAndDisconnect.Content.ToString() == "Connect")
            {
                
                try
                {
                    Connection = new SqlConnection(ConnectionString);
                    Connection.Open();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: " + exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MainDataGrid.Visibility = Visibility.Visible;
                BTN_AVGCalories.IsEnabled = true;
                BTN_MaxCalories.IsEnabled = true;
                BTN_MinCalories.IsEnabled = true;
                BTN_Save.IsEnabled = true;
                BTN_Reload.IsEnabled = true;
                BTN_ShowColors.IsEnabled = true;
                BTN_ShowNames.IsEnabled = true;
              
                BTN_CountFruit.IsEnabled = true;
                BTN_CountVegetables.IsEnabled = true;
                BTN_CountByColor.IsEnabled = true;
                TB_Color.IsEnabled = true;


                TB_MoreCalories.IsEnabled = true;
                TB_LessCalories.IsEnabled = true;
                TB_ColorLess.IsEnabled = true;
                TB_ColoriesMore.IsEnabled = true;
                BTN_CountByCalless.IsEnabled = true;
                BTN_CountByCaloriesMore.IsEnabled = true;
                BTN_CaloriesBetween.IsEnabled = true;
                BTN_ShowAllProdColorYellowOrRed.IsEnabled = true;
                BTN_ShowAllProdByColor.IsEnabled = true;

                MainAdapter = new SqlDataAdapter();

                

                MessageBox.Show("Success conection!");
                BTN_ConnectAndDisconnect.Content = "Disconnect";

            }
            else
            {
                MainDataGrid.Visibility = Visibility.Hidden;

                BTN_AVGCalories.IsEnabled = false;
                BTN_MaxCalories.IsEnabled = false;
                BTN_MinCalories.IsEnabled = false;
                BTN_Save.IsEnabled = false;
                BTN_Reload.IsEnabled = false;
                BTN_ShowColors.IsEnabled = false;
                BTN_ShowNames.IsEnabled = false;
                BTN_CountFruit.IsEnabled = false;
                BTN_CountVegetables.IsEnabled = false;
                BTN_CountByColor.IsEnabled = false;
                TB_Color.IsEnabled = false;
                TB_MoreCalories.IsEnabled = false;
                TB_LessCalories.IsEnabled = false;
                TB_ColorLess.IsEnabled = false;
                TB_ColoriesMore.IsEnabled = false;
                BTN_CountByCalless.IsEnabled = false;
                BTN_CountByCaloriesMore.IsEnabled = false;
                BTN_CaloriesBetween.IsEnabled = false;
                BTN_ShowAllProdColorYellowOrRed.IsEnabled = false;
                BTN_ShowAllProdByColor.IsEnabled = false;


                if(MainTable != null)
                    MainTable.Clear();

                MainTable = null;
                MainDataGrid.ItemsSource = null;
                MainAdapter = null;

                BTN_ConnectAndDisconnect.Content = "Connect";
            }
        }

        private void BTN_CountFruit_OnClick(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter tmpAdapter = new SqlDataAdapter($"select Count(Type) from FruitsAndVegetables where(Type = 'F') group by Type", Connection);
            DataTable tmpTable = new DataTable();

            tmpAdapter.Fill(tmpTable);
            MessageBox.Show("Count fruits: " + tmpTable.Rows[0].ItemArray[0]);
        }

        private void BTN_CountVegetables_OnClick(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter tmpAdapter = new SqlDataAdapter($"select Count(Type) from FruitsAndVegetables where(Type = 'V') group by Type", Connection);
            DataTable tmpTable = new DataTable();

            tmpAdapter.Fill(tmpTable);
            MessageBox.Show("Количество овощей: " + tmpTable.Rows[0].ItemArray[0]);
        }

        private void BTN_CountByColor_OnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TB_Color.Text) || String.IsNullOrEmpty(TB_Color.Text))
            {
                MessageBox.Show("Invalid string!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SqlCommand tmpCommand =
                new SqlCommand("select Count(id) from FruitsAndVegetables where(Color = @name)", Connection);

            SqlParameter nameParameter = new SqlParameter("@name", TB_Color.Text);
            tmpCommand.Parameters.Add(nameParameter);

            SqlDataAdapter tmpAdapter = new SqlDataAdapter(tmpCommand);
            DataTable tmpTable = new DataTable();

            tmpAdapter.Fill(tmpTable);
            MessageBox.Show($"Количество продуктов по цвету {TB_Color.Text}: " + tmpTable.Rows[0].ItemArray[0]);
        }

        private void BTN_ShowAllProdByColor_OnClick(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter tmpAdapter =
                new SqlDataAdapter($"select Color, Count(Color) from FruitsAndVegetables group by Color", ConnectionString);
            DataTable tmpTable = new DataTable();
            tmpAdapter.Fill(tmpTable);

            ItemsWindow form = new ItemsWindow(tmpTable);

            form.ShowDialog();
        }

        private void BTN_CountByCalless_OnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TB_ColorLess.Text) || String.IsNullOrEmpty(TB_ColorLess.Text))
            {
                MessageBox.Show("Строка не прошла валидацию!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int calories;
            try
            {
               calories = Int32.Parse(TB_ColorLess.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Строка не прошла валидацию!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SqlCommand tmpCommand =
                new SqlCommand("select * from FruitsAndVegetables where(Calories < @parametr)", Connection);



            SqlParameter nameParameter = new SqlParameter
            {
                ParameterName = "@parametr",
                SqlDbType = SqlDbType.Int,
                Value = calories
            };
            tmpCommand.Parameters.Add(nameParameter);



            SqlDataAdapter tmpAdapter = new SqlDataAdapter(tmpCommand);
            DataTable tmpTable = new DataTable();

            tmpAdapter.Fill(tmpTable);
            ItemsWindow window = new ItemsWindow(tmpTable);
            window.ShowDialog();
        }

        private void BTN_CaloriesBetween_OnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TB_MoreCalories.Text) || String.IsNullOrEmpty(TB_MoreCalories.Text) 
                || String.IsNullOrWhiteSpace(TB_LessCalories.Text) || String.IsNullOrEmpty(TB_LessCalories.Text))
            {
                MessageBox.Show("Строка не прошла валидацию!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int caloriesLess;
            int caloriesMore;
            try
            {
                caloriesLess = Int32.Parse(TB_LessCalories.Text);
                caloriesMore = Int32.Parse(TB_MoreCalories.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Строка не прошла валидацию!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SqlCommand tmpCommand = new SqlCommand
                    (
                  "select * from FruitsAndVegetables where(Calories < @parametr1 and Calories > @parametr2)",
                        Connection
                    );



            SqlParameter caloriesLessParameter = new SqlParameter
            {
                ParameterName = "@parametr1",
                SqlDbType = SqlDbType.Int,
                Value = caloriesLess
            };
            SqlParameter caloriesMoreParameter = new SqlParameter
            {
                ParameterName = "@parametr2",
                SqlDbType = SqlDbType.Int,
                Value = caloriesMore
            };

            tmpCommand.Parameters.Add(caloriesLessParameter);
            tmpCommand.Parameters.Add(caloriesMoreParameter);


            SqlDataAdapter tmpAdapter = new SqlDataAdapter(tmpCommand);
            DataTable tmpTable = new DataTable();

            tmpAdapter.Fill(tmpTable);
            ItemsWindow window = new ItemsWindow(tmpTable);
            window.ShowDialog();
        }

        private void BTN_ShowAllProdColorYellowOrRed_OnClick(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter tmpAdapter = new SqlDataAdapter($"select * from FruitsAndVegetables where(Color = 'Red' or Color = 'Yellow')", Connection);
            DataTable tmpTable = new DataTable();
            tmpAdapter.Fill(tmpTable);

            ItemsWindow itemsWindow = new ItemsWindow(tmpTable);
            itemsWindow.ShowDialog();
        }

        private void BTN_CountByCaloriesMore_OnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TB_ColoriesMore.Text) || String.IsNullOrEmpty(TB_ColoriesMore.Text))
            {
                MessageBox.Show("Строка не прошла валидацию!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int calories;
            try
            {
                calories = Int32.Parse(TB_ColoriesMore.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Строка не прошла валидацию!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SqlCommand tmpCommand =
                new SqlCommand("select * from FruitsAndVegetables where(Calories > @parametr)", Connection);

            SqlParameter nameParameter = new SqlParameter
            {
                ParameterName = "@parametr",
                SqlDbType = SqlDbType.Int,
                Value = calories
            };
            tmpCommand.Parameters.Add(nameParameter);

            SqlDataAdapter tmpAdapter = new SqlDataAdapter(tmpCommand);
            DataTable tmpTable = new DataTable();

            tmpAdapter.Fill(tmpTable);
            ItemsWindow window = new ItemsWindow(tmpTable);
            window.ShowDialog();
        }
    }
}
