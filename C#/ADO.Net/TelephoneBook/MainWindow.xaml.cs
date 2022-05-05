using System;
using System.Data.Odbc;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using _19._02._2022.Entities;
using _20._02._2022.Entities;
using _20._02._2022.Entities.Context;

namespace _20._02._2022
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TelephoneBookContext DbContext = new TelephoneBookContext();

        public MainWindow()
        {
            InitializeComponent();

            DbContext.UpdateLocalData();
            

            Binding bindingContacts = new Binding();
            bindingContacts.Source = DbContext.Contacts.Local;
            LB_Contacts.SetBinding(ItemsControl.ItemsSourceProperty, bindingContacts);


            Binding bindingGroups = new Binding();
            bindingGroups.Source = DbContext.Groups.Local;
            LB_Groups.SetBinding(ItemsControl.ItemsSourceProperty, bindingGroups);



        }

        private void BTN_DeleteContact_OnClick(object sender, RoutedEventArgs e)
        {
            DbContext.Contacts.Remove((Contact)LB_Contacts.SelectedItem);

            try {
                DbContext.SaveChanges();
            }
            catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
                DbContext.UpdateLocalData();
            }

        }


        private void BTN_Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            Binding bindingContacts = new Binding();
            bindingContacts.Source = DbContext.Contacts.Local;
            LB_Contacts.SetBinding(ItemsControl.ItemsSourceProperty, bindingContacts);

            Binding bindingGroups = new Binding();
            bindingGroups.Source = DbContext.Groups.Local;
            LB_Groups.SetBinding(ItemsControl.ItemsSourceProperty, bindingGroups);

            DbContext.UpdateLocalData();
        }

        private void BTN_DeleteGroup_OnClick(object sender, RoutedEventArgs e)
        {
            DbContext.Groups.Remove((Group) LB_Groups.SelectedItem);

            try {
                DbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error: {exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                DbContext.UpdateLocalData();
            }
        }

        private void BTN_AddContact_OnClick(object sender, RoutedEventArgs e)
        {
            AddUpdateContactWindow window = new AddUpdateContactWindow(DbContext.Groups.ToList());

            if (window.ShowDialog() == true)
            {
                DbContext.Contacts.Add(window.resultContact);

                try
                {
                    DbContext.SaveChanges();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Error: {exception.Message}");
                    DbContext.UpdateLocalData();
                }
            }
        }

        private void BTN_UpdateContact_OnClick(object sender, RoutedEventArgs e)
        {
            Contact oldContact = (Contact) LB_Contacts.SelectedItem;
            AddUpdateContactWindow window = new AddUpdateContactWindow(oldContact, DbContext.Groups.ToList());
            
            if (window.ShowDialog() == true)
            {
                Contact UpdatingContact = (from c in DbContext.Contacts.ToList()
                    where (c.id == oldContact.id)
                    select c).FirstOrDefault();

                if (UpdatingContact == null)
                {
                    MessageBox.Show("Error");
                    return;
                }

                UpdatingContact.FirstName = window.resultContact.FirstName;
                UpdatingContact.SecondName = window.resultContact.SecondName;
                UpdatingContact.BirthDate = window.resultContact.BirthDate;
                UpdatingContact.Group = window.resultContact.Group;
                UpdatingContact.Mail = window.resultContact.Mail;
                UpdatingContact.IsBlocked = window.resultContact.IsBlocked;
                UpdatingContact.Priority = window.resultContact.Priority;
                UpdatingContact.Telephone = window.resultContact.Telephone;

                try
                {
                    DbContext.SaveChanges();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Error: {exception.Message}");
                    DbContext.UpdateLocalData();
                }
            }
        }

        private void BTN_AddGroup_OnClick(object sender, RoutedEventArgs e)
        {
            AddGroupWindow window = new AddGroupWindow();

            if (window.ShowDialog() == true)
            {
                DbContext.Groups.Add(window.groupResult);

                try
                {
                    DbContext.SaveChanges();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Error: {exception.Message}");
                    DbContext.UpdateLocalData();
                }
            }
        }

        private void BTN_UpdateGroup_OnClick(object sender, RoutedEventArgs e)
        {
            Group oldGroup = (Group)LB_Groups.SelectedItem;
            UpdateGroupWindow window = new UpdateGroupWindow(oldGroup);

            if (window.ShowDialog() == true)
            {
                Group UpdatingGroup = 
                    (from g in DbContext.Groups.ToList()
                    where g.id == oldGroup.id
                    select g).FirstOrDefault();

                UpdatingGroup.Name = window.groupResult.Name;
            }
        }

        private void BTN_SerchContacts_OnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TB_Search.Text))
                return;

            var result = from c in DbContext.Contacts.ToList()
                where TB_Search.Text.ToLower().Contains(c.FirstName.ToLower()) ||
                      TB_Search.Text.ToLower().Contains(c.SecondName.ToLower()) ||
                      c.FirstName.ToLower().Contains(TB_Search.Text.ToLower()) ||
                      c.SecondName.ToLower().Contains(TB_Search.Text.ToLower())
                select c;
            LB_Contacts.ItemsSource = result;
        }

        private void BTN_SerchGroups_OnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TB_Search.Text))
                return;

            var result = from g in DbContext.Groups.ToList()
                where TB_Search.Text.ToLower().Contains(g.Name.ToLower()) ||
                      g.Name.ToLower().Contains(TB_Search.Text.ToLower())
                select g;
            LB_Groups.ItemsSource = result;
        }
    }
}
