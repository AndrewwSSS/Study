using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using _18._02._2022.AddUpdateWindows;

namespace _18._02._2022
{

    public partial class MainWindow : Window
    {
        private Games2Entities GamesDb = new Games2Entities();
        private string CurrTableName;

        public MainWindow()
        {
            InitializeComponent();

        }





        public void UpdateTableInfo()
        {
            switch (CurrTableName)
            {
                case "Games":
                    DataGridGames.ItemsSource = null;
                    DataGridGames.ItemsSource = GamesDb.Games.ToList();
                    break;
                case "Developers":
                    DataGridDevelopers.ItemsSource = null;
                    DataGridDevelopers.ItemsSource = GamesDb.Developers.ToList();
                    break;
                case "Distributors":
                    DataGridDistributors.ItemsSource = null;
                    DataGridDistributors.ItemsSource = GamesDb.Distributors.ToList();
                    break;
            }
        }


        private void TabControl_Main_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                CurrTableName = ((TextBlock)((TabItem)TabControl_Main.SelectedItem).Header).Text;
                UpdateTableInfo();
            }
        }


        private void BTN_Update_OnClick(object sender, RoutedEventArgs e)
        {
            UpdateTableInfo();
        }

        private void BTN_DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            switch (CurrTableName)
            {
                case "Games":
                {
                    if (DataGridGames.SelectedItem == null)
                        return;

                    GamesDb.Games.Remove((Game)DataGridGames.SelectedItem);

                    try {
                        GamesDb.SaveChanges();
                    }
                    catch (Exception exception) {
                        MessageBox.Show("Deleted failed! Maybe record already deleted");
                    }

                    DataGridGames.ItemsSource = null;
                    DataGridGames.ItemsSource = GamesDb.Games.ToList();
                    break;
                }
                case "Developers":
                {
                    if (DataGridDevelopers.SelectedItem == null)
                        return;

                    GamesDb.Developers.Remove((Developer)DataGridDevelopers.SelectedItem);

                    try
                    {
                        GamesDb.SaveChanges();
                    }
                    catch (Exception exception) {
                        MessageBox.Show("Deleted failed! Maybe record already deleted");
                    }
                    

                    DataGridDevelopers.ItemsSource = null; 
                    DataGridDevelopers.ItemsSource = GamesDb.Developers.ToList();
                    break;
                }
                case "Distributors":
                {
                    if (DataGridDistributors.SelectedItem == null)
                        return;

                    GamesDb.Distributors.Remove((Distributor)DataGridDistributors.SelectedItem);

                    try
                    {
                        GamesDb.SaveChanges();
                    }
                    catch (Exception exception) {
                        MessageBox.Show("Deleted failed! Maybe record already deleted");
                    }


                    DataGridDistributors.ItemsSource = null;
                    DataGridDistributors.ItemsSource = GamesDb.Distributors.ToList();
                    break;
                }
            }
        }

        private void BTN_AddRecord_OnClick(object sender, RoutedEventArgs e)
        {
            switch (CurrTableName)
            {
                case "Games":
                {
                    AddUpdateGamesWindow window = new AddUpdateGamesWindow(GamesDb.Developers.ToList(), GamesDb.Distributors.ToList());

                    if (window.ShowDialog() == true)
                    {
                        GamesDb.Games.Add(window.Result);

                        try
                        {
                            GamesDb.SaveChanges();
                        }
                        catch (Exception exe)
                        {
                            MessageBox.Show("Error");
                        }

                    }

                    DataGridGames.ItemsSource = null;
                    DataGridGames.ItemsSource = GamesDb.Games.ToList();
                    break;
                }
                case "Developers":
                {
                    AddUpdateDeveloperWindow window = new AddUpdateDeveloperWindow();

                    if (window.ShowDialog() == true)
                    {
                        GamesDb.Developers.Add(window.Result);

                        try
                        {
                            GamesDb.SaveChanges();
                        }
                        catch (Exception exe)
                        {
                            MessageBox.Show("Error");
                        }

                    }

                    DataGridDevelopers.ItemsSource = null;
                    DataGridDevelopers.ItemsSource = GamesDb.Developers.ToList();
                    break;
                }
                case "Distributors":
                {
                    AddUpdateDistributorWindow window = new AddUpdateDistributorWindow();

                    if (window.ShowDialog() == true)
                    {
                        GamesDb.Distributors.Add(window.Result);

                        try {
                            GamesDb.SaveChanges();
                        }
                        catch (Exception exe) {
                            MessageBox.Show("Error");
                        }
 
                    }

                    DataGridDistributors.ItemsSource = null;
                    DataGridDistributors.ItemsSource = GamesDb.Distributors.ToList();
                    break;
                }
            }
        }

        private void BTN_UpdateRecord_OnClick(object sender, RoutedEventArgs e)
        {
            switch (CurrTableName)
            {
                case "Games":
                {
                    if (DataGridGames.SelectedItem == null)
                    {
                        MessageBox.Show("Error");
                        return;
                    }

                    AddUpdateGamesWindow window = new AddUpdateGamesWindow(
                            GamesDb.Developers.ToList(),
                            GamesDb.Distributors.ToList(),
                            (Game)DataGridGames.SelectedItem
                            );

                    if (window.ShowDialog() == true)
                    {
                        Game UpdatedGame =
                            (from d in GamesDb.Games.ToList()
                                where d.Id == ((Game)DataGridGames.SelectedItem).Id
                                select d).FirstOrDefault();

                        if (UpdatedGame != null)
                        {
                            UpdatedGame.Name = window.Result.Name;
                            UpdatedGame.Developer = window.Result.Developer;
                            UpdatedGame.Distributor = window.Result.Distributor;
                            UpdatedGame.Platform = window.Result.Platform;
                            UpdatedGame.ReleaseDate = window.Result.ReleaseDate;

                            try {
                                GamesDb.SaveChanges();
                            }
                            catch (Exception exe) {
                                MessageBox.Show($"Error. {exe.Message}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }

                    DataGridGames.ItemsSource = null;
                    DataGridGames.ItemsSource = GamesDb.Games.ToList();
                    break;
                }
                case "Developers":
                {
                    if (DataGridDevelopers.SelectedItem == null)
                    {
                        MessageBox.Show("Error");
                        return;
                    }

                    AddUpdateDeveloperWindow window
                        = new AddUpdateDeveloperWindow((Developer)DataGridDevelopers.SelectedItem);

                    if (window.ShowDialog() == true)
                    {
                        Developer UpdatedDev =
                            (from d in GamesDb.Developers.ToList()
                                where d.Id == ((Developer)DataGridDevelopers.SelectedItem).Id
                                select d).FirstOrDefault();

                        if (UpdatedDev != null)
                        {
                            UpdatedDev.Name = window.Result.Name;

                            try
                            {
                                GamesDb.SaveChanges();
                            }
                            catch (Exception exe)
                            {
                                MessageBox.Show($"Error. {exe.Message}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }

                    DataGridDevelopers.ItemsSource = null;
                    DataGridDevelopers.ItemsSource = GamesDb.Developers.ToList();
                    break;
                    
                }
                case "Distributors":
                {
                    if (DataGridDistributors.SelectedItem == null)
                    {
                        MessageBox.Show("Error");
                        return;
                    }

                    AddUpdateDistributorWindow window 
                        = new AddUpdateDistributorWindow((Distributor)DataGridDistributors.SelectedItem);

                    if (window.ShowDialog() == true)
                    {
                        Distributor UpdatedDist =
                                (from d in GamesDb.Distributors.ToList()
                                where d.Id == ((Distributor) DataGridDistributors.SelectedItem).Id
                                select d).FirstOrDefault();

                        if (UpdatedDist != null)
                        {
                            UpdatedDist.Name = window.Result.Name;

                            try {
                                GamesDb.SaveChanges();
                            }
                            catch (Exception exe) {
                                MessageBox.Show($"Error. {exe.Message}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }

                    DataGridDistributors.ItemsSource = null;
                    DataGridDistributors.ItemsSource = GamesDb.Distributors.ToList();
                    break;
                }
            }
        }
    }
}
