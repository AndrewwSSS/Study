using System.Windows;

namespace _20._02._2022.Entities
{
    public partial class UpdateGroupWindow : Window
    {
        public Group groupResult;

        public UpdateGroupWindow(Group group)
        {
            InitializeComponent();
            LB_Contacts.ItemsSource = group.Contacts;
            TB_Name.Text = group.Name;
        }

        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            groupResult = new Group()
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
