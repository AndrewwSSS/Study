using System;
using System.Collections.Generic;
using System.Windows;

namespace _18._02._2022.AddUpdateWindows
{
    public partial class AddUpdateGamesWindow : Window
    {
        public Game Result { get; set; }

        public AddUpdateGamesWindow(List<Developer> developers, List<Distributor> distributors)
        {
            InitializeComponent();
            CB_Developers.ItemsSource = developers;
            CB_Distributors.ItemsSource = distributors;

            CB_Developers.SelectedIndex = 0;
            CB_Distributors.SelectedIndex = 0;
        }

        public AddUpdateGamesWindow(List<Developer> developers, List<Distributor> distributors, Game game)
        {
            InitializeComponent();
            CB_Developers.ItemsSource = developers;
            CB_Distributors.ItemsSource = distributors;

            CB_Developers.SelectedItem = game.Developer;
            CB_Distributors.SelectedItem = game.Distributor;


            TB_Name.Text = game.Name;
            TB_Platform.Text = game.Platform;
            TB_RealaseDate.Text = game.ReleaseDate.ToString();


        }

        private void BTN_Save_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime date;
            if (TB_Name.Text == "" ||
                TB_Platform.Text == ""
                || !DateTime.TryParse(TB_RealaseDate.Text, out date))
            {
                MessageBox.Show("Error");
                return;
            }

            Result = new Game()
            {
                Name = TB_Name.Text,
                Platform = TB_Platform.Text,
                ReleaseDate = date,
                Developer = (Developer) CB_Developers.SelectedItem,
                Distributor = (Distributor) CB_Distributors.SelectedItem
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
