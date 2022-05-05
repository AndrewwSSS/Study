using System.Windows;

namespace _18._02._2022.AddUpdateWindows
{
    public partial class AddUpdateDistributorWindow : Window
    {
        public Distributor Result { get; set; }


        public AddUpdateDistributorWindow(Distributor distributor)
        {
            InitializeComponent();

            TB_Name.Text = distributor.Name;
            // Тут косяки с неймингом, из-за ModelFirst
            LB_Games.ItemsSource = distributor.Game;
        }

        public AddUpdateDistributorWindow()
        {
            InitializeComponent();
        }

        private void BTN_Save_OnClick(object sender, RoutedEventArgs e)
        {
            if (TB_Name.Text == "")
            {
                MessageBox.Show("Error");
                return;
            }

            Result = new Distributor()
            {
                Name = TB_Name.Text
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
