using System;
using System.Windows;
using System.Data.Linq;
using System.Linq;
using _12._02._2022.Entities;

namespace _12._02._2022
{

    public partial class MainWindow : Window
    {
        private string ConnectionString = "Data Source=DESKTOP-8PVIEVM;Initial Catalog=Countries;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private DataContext DbContext;

        public MainWindow()
        {
            InitializeComponent();

            BTN_Save.IsEnabled = false;
            BTN_ShowAllEurope.IsEnabled = false;
            BTN_Update.IsEnabled = false;
            BTN_AreaBetween.IsEnabled = false;
            BTN_CountryMoreArea.IsEnabled = false;
            BTN_CountryMorePopulation.IsEnabled = false;
            BTN_LettersAU.IsEnabled = false;
            BTN_ShowAllEurope.IsEnabled = false;
            BTN_SmallerAreaInAfrica.IsEnabled = false;
            BTN_StartWithAU.IsEnabled = false;
            BTN_AVGAreaOfAsia.IsEnabled = false;
            BTN_TOP1byArea.IsEnabled = false;
            BTN_TOP5byArea.IsEnabled = false;
            BTN_TOP1byPopulation.IsEnabled = false;
            BTN_TOP5byPopulation.IsEnabled = false;
            

        }

        private void BTN_Connection_OnClick(object sender, RoutedEventArgs e)
        {
            if (DbContext == null)
            {
                try
                {
                    DbContext = new DataContext(ConnectionString);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Connection failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    DbContext = null;
                    return;
                }
                MainDataGrid.ItemsSource = DbContext.GetTable<Country>();

                MessageBox.Show("Connection success", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                
                MainDataGrid.Visibility = Visibility.Visible;
                BTN_Save.IsEnabled = true;
                BTN_ShowAllEurope.IsEnabled = true;
                BTN_Update.IsEnabled = true;
                BTN_AreaBetween.IsEnabled = true;
                BTN_CountryMoreArea.IsEnabled = true;
                BTN_CountryMorePopulation.IsEnabled = true;
                BTN_LettersAU.IsEnabled = true;
                BTN_ShowAllEurope.IsEnabled = true;
                BTN_SmallerAreaInAfrica.IsEnabled = true;
                BTN_StartWithAU.IsEnabled = true;
                BTN_AVGAreaOfAsia.IsEnabled = true;
                BTN_TOP1byArea.IsEnabled = true;
                BTN_TOP5byArea.IsEnabled = true;
                BTN_TOP1byPopulation.IsEnabled = true;
                BTN_TOP5byPopulation.IsEnabled = true;
                BTN_AddCountry.IsEnabled = true;

                BTN_Connection.Content = "Disconnect";
            }
            else
            {
                DbContext = null;
                MainDataGrid.ItemsSource = null;
                
                MainDataGrid.Visibility = Visibility.Hidden;

                BTN_Save.IsEnabled = false;
                BTN_ShowAllEurope.IsEnabled = false;
                BTN_Update.IsEnabled = false;
                BTN_AreaBetween.IsEnabled = false;
                BTN_CountryMoreArea.IsEnabled = false;
                BTN_CountryMorePopulation.IsEnabled = false;
                BTN_LettersAU.IsEnabled = false;
                BTN_ShowAllEurope.IsEnabled = false;
                BTN_SmallerAreaInAfrica.IsEnabled = false;
                BTN_StartWithAU.IsEnabled = false;
                BTN_AVGAreaOfAsia.IsEnabled = false;
                BTN_TOP1byArea.IsEnabled = false;
                BTN_TOP5byArea.IsEnabled = false;
                BTN_TOP1byPopulation.IsEnabled = false;
                BTN_TOP5byPopulation.IsEnabled = false;
                BTN_AddCountry.IsEnabled = false;
                BTN_AddCountry.IsEnabled = false;
                BTN_Connection.Content = "Connect";

            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            int tmpArea;
            int tmpPopulation;

            if (TB_AddArea.Text == "" ||
                TB_AddName.Text == "" ||
                TB_AddNameOfCapital.Text == "" ||
                TB_AddPartOfWorld.Text == "" ||
                TB_AddPopulation.Text == "" ||
                !Int32.TryParse(TB_AddArea.Text, out tmpArea) ||
                !Int32.TryParse(TB_AddPopulation.Text, out tmpPopulation))
            {
                MessageBox.Show("Incorrect parameters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            Country newCountry = new Country()
            {
                Name = TB_AddName.Text,
                Area = tmpArea,
                NameOfCapital = TB_AddNameOfCapital.Text,
                Population = tmpPopulation,
                PartOfWorld = TB_AddPartOfWorld.Text
            };

            DbContext.GetTable<Country>().InsertOnSubmit(newCountry);
            DbContext.SubmitChanges();

            TB_AddArea.Text = "";
            TB_AddName.Text = "";
            TB_AddNameOfCapital.Text = "";
            TB_AddPartOfWorld.Text = "";
            TB_AddPopulation.Text = "";
        }

        private void RefreshTable()
        {
            if (DbContext != null)
            {
                MainDataGrid.ItemsSource = null;
                MainDataGrid.ItemsSource = DbContext.GetTable<Country>();
            }
        }

        private void BTN_Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            RefreshTable();
        }

        private void BTN_ShowAllEurope_OnClick(object sender, RoutedEventArgs e)
        {

            var tmp =   from c in DbContext.GetTable<Country>()
                                      where c.PartOfWorld == "Eвропа"
                                      select c;

            ShowTableWindow window = new ShowTableWindow(tmp);

            window.ShowDialog();
        }

        private void BTN_CountryMoreArea_OnClick(object sender, RoutedEventArgs e)
        {
            int AreaLess;
            if (!Int32.TryParse(TB_AreaLess.Text, out AreaLess))
            {
                MessageBox.Show("Error");
                return;
            }

            var Res =
                from c in DbContext.GetTable<Country>()
                where c.Area > AreaLess
                select c;


            ShowTableWindow window = new ShowTableWindow(Res);
            window.ShowDialog();

        }

        private void BTN_LettersAU_OnClick(object sender, RoutedEventArgs e)
        {
            var items =
                from c in DbContext.GetTable<Country>()
                where (c.Name.ToLower().Contains("a") && c.Name.ToLower().Contains("u"))
                select c;

            ShowTableWindow window = new ShowTableWindow(items);
            window.ShowDialog();
        }

        private void BTN_StartWithA_OnClick(object sender, RoutedEventArgs e)
        {
            var items =
                from c in DbContext.GetTable<Country>()
                where c.Name.ToLower().StartsWith("а")
                select c;

            ShowTableWindow window = new ShowTableWindow(items);
            window.ShowDialog();
        }

        private void BTN_AreaBetween_OnClick(object sender, RoutedEventArgs e)
        {
            int AreaLess;
            int AreaMore;
            if (!Int32.TryParse(TB_LessArea.Text, out AreaLess) || !Int32.TryParse(TB_MoreArea.Text, out AreaMore))
            {
                MessageBox.Show("Error");
                return;
            }

            var Res =
                from c in DbContext.GetTable<Country>()
                where c.Area > AreaLess && c.Area < AreaMore
                select c;


            ShowTableWindow window = new ShowTableWindow(Res);
            window.ShowDialog();
        }

        private void BTN_CountryMorePopulation_OnClick(object sender, RoutedEventArgs e)
        {
            int PopulationLess;
            if (!Int32.TryParse(TB_PopulationLess.Text, out PopulationLess))
            {
                MessageBox.Show("Error");
                return;
            }

            var Res =
                from c in DbContext.GetTable<Country>()
                where c.Population > PopulationLess
                select c;


            ShowTableWindow window = new ShowTableWindow(Res);
            window.ShowDialog();

        }

        private void BTN_TOP5byArea_OnClick(object sender, RoutedEventArgs e)
        {
            var items =
                (from c in DbContext.GetTable<Country>()
                    orderby c.Area descending
                    select c).Take(5);
                

            ShowTableWindow window = new ShowTableWindow(items);
            window.ShowDialog();
        }

        private void BTN_TOP5byPopulation_OnClick(object sender, RoutedEventArgs e)
        {
            var items = 
                    (from c in DbContext.GetTable<Country>()
                    orderby c.Population descending
                    select c).Take(5);


            ShowTableWindow window = new ShowTableWindow(items);
            window.ShowDialog();
        }

        private void BTN_TOP1byArea_OnClick(object sender, RoutedEventArgs e)
        {
            var items =
                (from c in DbContext.GetTable<Country>()
                    orderby c.Area descending
                    select c).Take(1);


            ShowTableWindow window = new ShowTableWindow(items);
            window.ShowDialog();
        }

        private void BTN_TOP1byPopulation_OnClick(object sender, RoutedEventArgs e)
        {
            var items =
                (from c in DbContext.GetTable<Country>()
                    orderby c.Population descending
                    select c).Take(1);


            ShowTableWindow window = new ShowTableWindow(items);
            window.ShowDialog();
        }

        private void BTN_SmallerAreaInAfrica_OnClick(object sender, RoutedEventArgs e)
        {
            var items =
                (from c in DbContext.GetTable<Country>()
                    where c.PartOfWorld == "Африка"
                    orderby c.Area
                    select c).Take(1);


            ShowTableWindow window = new ShowTableWindow(items);
            window.ShowDialog();
        }

        private void BTN_AVGAreaOfAsia_OnClick(object sender, RoutedEventArgs e)
        {
            var items =
                (from c in DbContext.GetTable<Country>()
                    where c.PartOfWorld == "Азия"
                    select c).Average(c => c.Area);

            MessageBox.Show(items.ToString());
        }

        private void BTN_Save_OnClick(object sender, RoutedEventArgs e)
        {
            DbContext.SubmitChanges();
            RefreshTable();
        }
    }
}
