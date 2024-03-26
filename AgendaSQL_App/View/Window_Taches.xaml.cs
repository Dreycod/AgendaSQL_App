using AgendaSQL_App.Agenda_db;
using AgendaSQL_App.Service.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AgendaSQL_App.View
{
    /// <summary>
    /// Logique d'interaction pour Window_Taches.xaml
    /// </summary>
    public partial class Window_Taches : Window
    {
        Todolist preset_todolist;
        DAO_Taches dao_taches;
        DAO_Todolist dao_todolist;
        public Window_Taches(Todolist todolist)
        {
            InitializeComponent();
            preset_todolist = todolist;
            dao_taches = new DAO_Taches();
            dao_todolist = new DAO_Todolist();

            LoadTaches();
        }

        private void LoadTaches()
        {
            TodolistName_TB.Text = preset_todolist.Name;
            DG_Taches.ItemsSource = dao_taches.GetTachesByTodolistId(preset_todolist.Id);
            int count = DG_Taches.Items.Count;
            TachesAmount_TB.Text = count.ToString() + " Total Taches";
        }

        private void EditTache_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteTache_Click(object sender, RoutedEventArgs e)
        {
            Tach tache = (Tach)DG_Taches.SelectedItem;
            if (tache != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this tache?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    dao_taches.DeleteTache(tache.Idtaches);
                    LoadTaches();
                }
            }
        }

        private void AddTache_Click(object sender, RoutedEventArgs e)
        {
            Tach tache = DG_Taches.SelectedItem as Tach;

            if (tache == null)
            {
                tache = new Tach()
                {
                    TodolistId = preset_todolist.Id,
                    Nom = TacheName_TB.Text,
                    Temps = Date.SelectedDate
                };
                dao_taches.AddTacheToTodolist(tache);
            }
            else
            {
                tache.Nom = TacheName_TB.Text;
                tache.Temps = Date.SelectedDate;

                dao_taches.UpdateTache(tache);
            }

            LoadTaches();

        }

        private void SaveTaches_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to save the changes?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // save changes
                foreach (Tach tach in DG_Taches.Items)
                {
                    dao_taches.UpdateTache(tach);
                }
                // Save the name of the todolist
                preset_todolist.Name = TodolistName_TB.Text;
                dao_todolist.UpdateTodolist(preset_todolist);

                MessageBox.Show("Changes saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DG_Taches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DG_Taches.SelectedItem != null)
            {
                Tach tache = DG_Taches.SelectedItem as Tach;
                TacheName_TB.Text = tache.Nom;
                Date.SelectedDate = tache.Temps;
            }
            else
            {
                TacheName_TB.Text = "";
                Date.SelectedDate = null;
            }
        }

    }
}