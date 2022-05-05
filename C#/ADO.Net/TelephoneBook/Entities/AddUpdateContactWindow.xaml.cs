using System;
using System.Collections.Generic;
using System.Windows;
using _19._02._2022.Entities;

namespace _20._02._2022.Entities
{
    public partial class AddUpdateContactWindow : Window
    {
        public Contact resultContact;

        public AddUpdateContactWindow(List<Group> groups)
        {
            InitializeComponent();

            CB_IsBlocked.Items.Add("true");
            CB_IsBlocked.Items.Add("false");
            CB_IsBlocked.SelectedIndex = 0;

            CB_Groups.ItemsSource = groups;

            if (groups.Count > 0)
                CB_Groups.SelectedIndex = 0;
        }

        public AddUpdateContactWindow(Contact contact, List<Group> groups)
        {
            InitializeComponent();

            CB_IsBlocked.Items.Add("true");
            CB_IsBlocked.Items.Add("false");

            if (contact.IsBlocked)
                CB_IsBlocked.SelectedItem = "true";
            else
                CB_IsBlocked.SelectedItem = "false";


            CB_Groups.ItemsSource = groups;

            if (groups.Count > 0)
                CB_Groups.SelectedItem = contact.Group;


            TB_DateOfBirth.Text = contact.BirthDate.ToString();
            TB_Mail.Text = contact.Mail;
            TB_Name.Text = contact.FirstName;
            TB_Priority.Text = contact.Priority.ToString();
            TB_Surname.Text = contact.SecondName;
            TB_Telephone.Text = contact.Telephone;

        }

        private void BTN_Save_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime NewBirthDate;
            int NewPriority;
            bool NewIsBlocked;

            if (TB_DateOfBirth.Text == "" ||
                TB_Mail.Text == "" ||
                TB_Name.Text == "" ||
                TB_Surname.Text == "" ||
                TB_Telephone.Text == "" ||
                !int.TryParse(TB_Priority.Text, out NewPriority) ||
                !DateTime.TryParse(TB_DateOfBirth.Text, out NewBirthDate))
            {
                MessageBox.Show("Error");
                return;
            }

            if (CB_IsBlocked.SelectedItem.ToString() == "true")
                NewIsBlocked = true;
            else
                NewIsBlocked = false;

            resultContact = new Contact()
            {
                FirstName = TB_Name.Text,
                SecondName = TB_Surname.Text,
                Telephone = TB_Telephone.Text,
                Mail = TB_Mail.Text,
                IsBlocked = NewIsBlocked,
                Priority = NewPriority,
                BirthDate = NewBirthDate, 
                Group = (Group)CB_Groups.SelectedItem
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
