using System;
using System.Linq;
using System.Windows;

namespace _13._02._2022
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CountriesEntities countriesDb;

        public MainWindow()
        {
            InitializeComponent();

            using (countriesDb = new CountriesEntities())
            {
                MainDataGrid.ItemsSource = countriesDb.Countries.ToList();
            }
        }

        private void BTN_Update_OnClick(object sender, RoutedEventArgs e)
        {
            UpdateInfo();
        }


        #region CRUID

        private void UpdateInfo()
        {
            using (countriesDb = new CountriesEntities())
            {
                MainDataGrid.ItemsSource = countriesDb.Countries.ToList();
            }
        }

        private void DeleteSelectedItem()
        {
            if (MainDataGrid.SelectedItem == null)
            {
                MessageBox.Show("No selected value", "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
                


            // receiving id of deleting Country
            int IdRecord = (MainDataGrid.SelectedItem as Country).id;

            using (countriesDb = new CountriesEntities())
            {
                var CountryToDelete =
                    (from c in countriesDb.Countries.ToList()
                        where (c.id == IdRecord)
                        select c).FirstOrDefault();

                if (CountryToDelete != null)
                {
                    countriesDb.Countries.Remove(CountryToDelete);
                    countriesDb.SaveChanges();
                    MainDataGrid.ItemsSource = countriesDb.Countries.ToList();
                }
            }
        }

        #endregion

        private void BTN_DeleteRecord_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteSelectedItem();
        }

        private void BTN_AddCountry_OnClick(object sender, RoutedEventArgs e)
        {
            if (TB_AddArea.Text == "" || TB_AddName.Text == "" || TB_AddNameOfCapital.Text == "" ||
                TB_AddPartOfWorld.Text == "" || TB_AddPopulation.Text == "")
            {
                MessageBox.Show("Erorr");
                return;
            }


            int tmpArea;
            int tmpPopulation;
            if (!Int32.TryParse(TB_AddArea.Text, out tmpArea) ||
                !Int32.TryParse(TB_AddPopulation.Text, out tmpPopulation))
            {

                MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

            using(countriesDb = new CountriesEntities())
            {
                countriesDb.Countries.Add(newCountry);
                countriesDb.SaveChanges();
                MainDataGrid.ItemsSource = countriesDb.Countries.ToList();
            }

            TB_AddArea.Text = "";
            TB_AddName.Text = "";
            TB_AddNameOfCapital.Text = "";
            TB_AddPartOfWorld.Text = "";
            TB_AddPopulation.Text = "";
        }

        private void BTN_EditSelectedRecord_OnClick(object sender, RoutedEventArgs e)
        {
            if (MainDataGrid.SelectedItem == null)
            {
                MessageBox.Show("No selected value", "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Country SelectedCountry = MainDataGrid.SelectedItem as Country;
            EditCountryWindow window = new EditCountryWindow(SelectedCountry);



            if (window.ShowDialog() == true)
            {
                using (countriesDb = new CountriesEntities())
                {
                    Country OldCountry =
                        (from c in countriesDb.Countries.ToList()
                            where c.id == SelectedCountry.id
                            select c).FirstOrDefault();

                    if (OldCountry != null)
                    {

                        Country updatedCountry = window.countryRes;

                        //countriesDb.Countries.Remove(OldCountry);
                        //countriesDb.Countries.Add(updatedCountry);



                        OldCountry.Area = updatedCountry.Area;
                        OldCountry.Name = updatedCountry.Name;
                        OldCountry.NameOfCapital = updatedCountry.NameOfCapital;
                        OldCountry.PartOfWorld = updatedCountry.PartOfWorld;
                        OldCountry.Population = updatedCountry.Population;

                        countriesDb.SaveChanges();
                        MainDataGrid.ItemsSource = countriesDb.Countries.ToList();
                    }
                }
            }
        }
    }
}
