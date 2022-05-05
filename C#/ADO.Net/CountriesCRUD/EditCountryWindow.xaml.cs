using System;
using System.Windows;

namespace _13._02._2022
{
    /// <summary>
    /// Логика взаимодействия для EditCountryWindow.xaml
    /// </summary>
    public partial class EditCountryWindow : Window
    {
        public Country countryRes { get; private set; }

        public EditCountryWindow(Country country)
        {
            InitializeComponent();

            TB_Name.Text = country.Name;
            TB_Area.Text = country.Area.ToString();
            TB_PartOfWorld.Text = country.PartOfWorld;
            TB_Population.Text = country.Population.ToString();
            TB_NameOfCapital.Text = country.NameOfCapital;

        }

        private void BTN_Save_OnClick(object sender, RoutedEventArgs e)
        {
            int Area, Population;
            if (!Int32.TryParse(TB_Area.Text, out Area) ||
                !Int32.TryParse(TB_Population.Text, out Population) ||
                TB_Name.Text == "" ||
                TB_PartOfWorld.Text == "" ||
                TB_NameOfCapital.Text == "")
            {

                MessageBox.Show("Erorr, invalid values/value", "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            countryRes = new Country()
            {
                Name = TB_Name.Text,
                Area = Area,
                PartOfWorld = TB_PartOfWorld.Text,
                Population = Population,
                NameOfCapital = TB_NameOfCapital.Text
            };

            DialogResult = true;
            this.Close();
        }

        private void BTN_Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
