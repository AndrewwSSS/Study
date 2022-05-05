using Dapper;
using DistributionDapper.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Section = DistributionDapper.Entities.Section;

namespace DistributionDapper
{

    public partial class MainWindow : Window
    {
        private SqlConnection connection;

        public MainWindow()
        {
            InitializeComponent();

            ComboBox_Tables.Items.Add("Products");
            ComboBox_Tables.Items.Add("Customers");
            ComboBox_Tables.Items.Add("Sections");
            ComboBox_Tables.Items.Add("Promotional products");
            ComboBox_Tables.Items.Add("Interests");

          

        }

        private void BTN_Connection_OnClick(object sender, RoutedEventArgs e)
        {
            if (connection == null)
            {
                ConnectToDB();
            }
            else
            {
                DisconnectFromDb();
            }
        }

        private void ConnectToDB()
        {
            try
            {
                connection = new SqlConnection(AppConnection.ConnectionString);
                connection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                connection = null;
                return;
            }

            MessageBox.Show("Connection complete", "Success", MessageBoxButton.OK, MessageBoxImage.Information);



            ComboBox_Tables.SelectedIndex = 0;

            BTN_Connection.Content = "Disconnect";
            MainDataGrid.Visibility = Visibility.Visible;

            ComboBox_Tables.IsEnabled = true;
            BTN_Refresh.IsEnabled = true;
        }

        private void DisconnectFromDb()
        {
            connection.Close();
            connection = null;

            MainDataGrid.Visibility = Visibility.Hidden;
            ComboBox_Tables.SelectedIndex = -1;

            ComboBox_Tables.IsEnabled = false;
            BTN_Refresh.IsEnabled = false;
        }



        private void ComboBox_Tables_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reload();
        }

        private void BTN_Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            if (connection == null)
                return;

            switch (ComboBox_Tables.SelectedItem.ToString())
            {
                case "Products":
                    MainDataGrid.ItemsSource =
                        connection.Query<Product>("select p.id, p.Name, p.Price, s.Name as 'Section' from Products p, Sections s where(s.id = p.SectionId)");
                    break;
                case "Customers":
                    MainDataGrid.ItemsSource =
                        connection.Query<Customer>("select * from Customers");
                    break;
                case "Sections":
                    MainDataGrid.ItemsSource =
                        connection.Query<Section>("select * from Sections");
                    break;
                case "Promotional products":
                    MainDataGrid.ItemsSource =
                        connection.Query<PromotionalProduct>
                            ("select p.id, prod.Name as 'ProductName', p.NewPrice, p.DateStart, p.DateEnd, p.Country from PromotionalProducts p, Products prod where(prod.id = p.ProductId)");
                    break;
                case "Interests":
                    MainDataGrid.ItemsSource =
                        connection.Query<Interest>(
                            "select i.id, c.FirstName+' ' + c.SecondName+' ' + c.Patronymic as 'Custumer', s.Name as 'Section' from Customers c, Sections s, Interests i where(i.CustomerId = c.id and i.SectionId = s.id)");
                    break;
            }
        }



        private void FindPeoplesByCounty_OnClick(object sender, RoutedEventArgs e)
        {
            List<Customer> res =
                connection.Query<Customer>("select * from Customers where(CountryOfResidence = @Arg1)",
                    new { Arg1 = TB_SearchPeopleByCountry.Text }).ToList();

            ShowCustomersWindow window = new ShowCustomersWindow(res);
            window.ShowDialog();
        }

        private void FindActionByCounty_OnClick(object sender, RoutedEventArgs e)
        {
            List<PromotionalProduct> res =
                connection.Query<PromotionalProduct>("select P.id, Prod.Name as 'ProductName', p.NewPrice , p.DateStart, p.DateEnd from PromotionalProducts P, Products Prod where(P.Country = @Arg1 and P.ProductId = Prod.Id)",
                    new { Arg1 = TB_SearchActionByCountry.Text }).ToList();

            ShowActionsWindow window = new ShowActionsWindow(res);
            window.ShowDialog();
        }

        private void BTN_Top3DistributionSections_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(3) s.Name, Count(i.SectionId) as 'NumberOfMembers' from Interests i, Sections s where(i.SectionId = s.id) group by i.SectionId, s.Name order by 2 desc");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{i}. {item.Name}. Number of members: {item.NumberOfMembers}");
                i++;
            }

            MessageBox.Show(builder.ToString());


         }

        private void BTN_MostPopularDistributionSections_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(1) s.Name, Count(i.SectionId) from Interests i, Sections s where(i.SectionId = s.id) group by i.SectionId, s.Name order by 2 desc");

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            var item = res.First();


            MessageBox.Show($"Most pupular distribution sections: {item.Name}");
        }
        
        private void BTN_Top3NotPopularDistributionSections_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(3) s.Name, Count(i.SectionId) as 'NumberOfMembers' from Interests i, Sections s where(i.SectionId = s.id) group by i.SectionId, s.Name order by 2 asc");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{i}. {item.Name}. Number of members: {item.NumberOfMembers}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_MostNotPopularDistributionSections_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(1) s.Name, Count(i.SectionId) from Interests i, Sections s where(i.SectionId = s.id) group by i.SectionId, s.Name order by 2 asc");

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }
            int i = 1;
            var item = res.First();


            MessageBox.Show($"most not pupular distribution sections: {item.Name}");
        }

        private void BTN_Top3DistributionSectionsByNumberOfPromotionalGoods_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(3) S.Name, Count(P.SectionId) as 'NumberOfGoods' from promotionalProducts Pp, Products P, Sections S where(P.id = Pp.ProductId and S.id = P.SectionId) group by P.SectionId, S.Name order by 2 desc");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{i}. {item.Name}. Number of goods: {item.NumberOfGoods}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_Top1DistributionSectionsByNumberOfPromotionalGoods_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(1) S.Name, Count(P.SectionId) as 'NumberOfGoods' from promotionalProducts Pp, Products P, Sections S where(P.id = Pp.ProductId and S.id = P.SectionId) group by P.SectionId, S.Name order by 2 desc");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{i}. {item.Name}. Number of good: {item.NumberOfGoods}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_Top3DistributionSectionsByleastNumberOfPromotionalGoods_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(3) S.Name, Count(P.SectionId) as 'NumberOfGoods' from promotionalProducts Pp, Products P, Sections S where(P.id = Pp.ProductId and S.id = P.SectionId) group by P.SectionId, S.Name order by 2 asc");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{i}. {item.Name}. Number of goods: {item.NumberOfGoods}");
                i++;
            }
            MessageBox.Show(builder.ToString());
        }

        private void BTN_Top1DistributionSectionsByleastNumberOfPromotionalGoods_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(1) S.Name, Count(P.SectionId) as 'NumberOfGoods' from promotionalProducts Pp, Products P, Sections S where(P.id = Pp.ProductId and S.id = P.SectionId) group by P.SectionId, S.Name order by 2 asc");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{i}. {item.Name}. Number of good: {item.NumberOfGoods}");
                i++;
            }
            MessageBox.Show(builder.ToString());
        }

        private void BTN_PromotionalGoodsWhichHaveUntilTheEndStockThreeDaysLeft_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select distinct P.Name, P.Price, Pp.NewPrice, Pp.DateStart, Pp.DateEnd, Pp.Country from PromotionalProducts Pp, Products p where((DATEDIFF(day, getdate(), Pp.DateEnd) = 3) and Pp.ProductId = P.id)");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{(string)item.Name} Old price:{item.Price} New price: {item.NewPrice} Date start:{((DateTime)item.DateStart).ToShortDateString()} Date end:{((DateTime)item.DateEnd).ToShortDateString()} Country:{(string)item.Country}");
                i++;
            }
            MessageBox.Show(builder.ToString());
        }

        private void BTN_promotionalGoodsWhichHaveLegalStockExpirationDate_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select distinct P.Name, P.Price, Pp.NewPrice, Pp.DateStart, Pp.DateEnd, Pp.Country from PromotionalProducts Pp, Products P where(DATEDIFF(day, getdate(), Pp.DateEnd) < 0)");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{(string)item.Name} Old price:{item.Price} New price: {item.NewPrice} Date start: {((DateTime)item.DateStart).ToShortDateString()} Date end:{((DateTime)item.DateEnd).ToShortDateString()} Country:{(string)item.Country}");
                i++;
            }
            MessageBox.Show(builder.ToString());
        }

        private void BTN_TransferAllProductsThatHaveExpiredThePromotionToTheArchive_Click(object sender, RoutedEventArgs e)
        {
            var res = connection.QuerySingle<dynamic>("declare @result int; exec @result = [dbo].ArchivetePp; select @result as 'result';");

            MessageBox.Show($"Operation ended success. Rows affected: {(int)res.result}");
        }

        private void BTN_AverageAgeOfBuyersForEachSection_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select S.Name, Avg(DATEDIFF(YEAR, C.DateOfbirth,  getdate())) as 'AvgAge' from Customers C, Interests I, Sections S where(S.id = I.SectionId and I.CustomerId = C.id) group by S.Name");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"Name of section: {item.Name} | AvgAge: {item.AvgAge}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_TheAverageAgeOfTheBuyerForEachCountry_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select C.CountryOfResidence, Avg(DATEDIFF(YEAR, C.DateOfbirth,  getdate())) as 'AvgAge' from Customers C group by C.CountryOfResidence");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"Country: {(string)item.CountryOfResidence} | AvgAge: {(int)item.AvgAge}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_Top1SectionsForWomens_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(1) S.Name as 'Top1SectionsForWomens' from Customers C, Interests I, Sections S where(C.id = I.CustomerId and S.id = I.SectionId and C.Sex = 0) group by C.Sex, S.Name order by Count(I.SectionId) desc");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"Name of section: {item.Top1SectionsForWomens}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_Top1SectionsForMans_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(1) S.Name as 'Top1SectionsForMans' from Customers C, Interests I, Sections S where(C.id = I.CustomerId and S.id = I.SectionId and C.Sex = 1) group by C.Sex, S.Name order by Count(I.SectionId) desc");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"Name of section: {item.Top1SectionsForMans}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_Top3SectionsForMans_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(3) S.Name as 'Top3SectionsForMans' from Customers C, Interests I, Sections S where(C.id = I.CustomerId and S.id = I.SectionId and C.Sex = 1) group by C.Sex, S.Name order by Count(I.SectionId) desc");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{i}. {item.Top3SectionsForMans}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_Top3SectionsForWomans_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select top(3) S.Name as 'Top3SectionsForMans' from Customers C, Interests I, Sections S where(C.id = I.CustomerId and S.id = I.SectionId and C.Sex = 0) group by C.Sex, S.Name order by Count(I.SectionId) desc");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{i}. {item.Top3SectionsForMans}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_NumbersOfMans_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select Count(C.Sex) as 'NumberOfWomens' from Customers C where (C.Sex = 0)");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"Numbers of womans: {item.NumberOfWomens}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_NumbersOfWomans_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select Count(C.Sex) as 'NumberOfMans' from Customers C where (C.Sex = 0)");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"Numbers of womans: {item.NumberOfMans}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_NumbersOfWomensBuyers_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select C.CountryOfResidence, Count(C.id) as 'NumberOfWomens' from Customers C where (C.Sex = 0) group by C.CountryOfResidence");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{item.CountryOfResidence} | Numbers of mans buyers: {item.NumberOfWomens}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }

        private void BTN_NumbersOfMansBuyers_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dynamic> res = connection.Query("select C.CountryOfResidence, Count(C.id) as 'NumberOfMans' from Customers C where (C.Sex = 1) group by C.CountryOfResidence");
            StringBuilder builder = new StringBuilder();

            if (res.Count() == 0)
            {
                MessageBox.Show("Nothing found");
                return;
            }

            int i = 1;
            foreach (dynamic item in res)
            {
                builder.AppendLine($"{item.CountryOfResidence} | Numbers of mans buyers: {item.NumberOfMans}");
                i++;
            }

            MessageBox.Show(builder.ToString());
        }
    }
}
