﻿using AgendaSQL_App.Service.DAO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AgendaSQL_App.Agenda_db;
using System.Collections.ObjectModel;

namespace AgendaSQL_App.View
{
    /// <summary>
    /// Logique d'interaction pour Page_Todolist.xaml
    /// </summary>
    public partial class Page_Todolist : UserControl
    {
        DAO_Todolist dao_todolist;

        string current_Genre = "All";

        public Page_Todolist()
        {
            InitializeComponent();
            dao_todolist = new DAO_Todolist();
            LoadTodoLists();

        }

        private void LoadTodoLists()
        {
            string filter = textBoxFilter.Text;
            IEnumerable<Todolist> Liste = dao_todolist.GetTodolistWithTaches();

            if (Liste != null)
            {
                if (current_Genre != "All")
                {
                    Liste = dao_todolist.GetTodolistWithTachesByGenre(current_Genre);

                    if (filter != "")
                    {
                        Liste = Liste.Where(todolist => todolist.Name.Contains(filter));
                    }
                }
                else if (filter != "")
                {
                    Liste = dao_todolist.GetTodolistWithTachesStartsByName(filter);
                }
            }

            LV_Todolists.ItemsSource = Liste;


            int count = LV_Todolists.Items.Count;
            TotalTodolistsTB.Text = count.ToString() + " Total Todolists";
        }

        private void AddTodolist_Click(object sender, RoutedEventArgs e)
        {
            Todolist _todolist = LV_Todolists.SelectedItem as Todolist;
            string name = ListName_TB.Text;
            if (Genre_CB.SelectedItem == null || name == "")
            {
                MessageBox.Show("Please fill all required fields");
                return;
            }

            string genre = Genre_CB.SelectedItem.ToString().Substring(38);

            if (_todolist == null)
            {
                

                Todolist todolist = new Todolist()
                {
                    Name = name,
                    Genre = genre
                };

                MessageBox.Show(genre);
                dao_todolist.AddTodolist(todolist);
            }
            else 
            {
                _todolist.Name = name;
                _todolist.Genre = Genre_CB.SelectedItem.ToString().Substring(38);
                dao_todolist.UpdateTodolist(_todolist);
            }

            LoadTodoLists();
        }

        private void ResetTodolists_Click(object sender, RoutedEventArgs e)
        {
            dao_todolist.ResetTodolists();
            LoadTodoLists();
        }

        private void Genre_Click(object sender, RoutedEventArgs e)
        {
            string Content = (sender as Button).Content.ToString();
            current_Genre = Content;
            LoadTodoLists();
        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadTodoLists();
        }

        private void DeleteTodolist_Click(object sender, RoutedEventArgs e)
        {
            Todolist todolist = (Todolist)LV_Todolists.SelectedItem;

            // if todolist null tell the user to select a list 
            if (todolist == null)
            {
                MessageBox.Show("Please select a todolist");
                return;
            }
            dao_todolist.DeleteTodolist(todolist.Id);
            LoadTodoLists();
        }


        private void OpenTaches_Click(object sender, RoutedEventArgs e)
        {
            Todolist todolist = (Todolist)LV_Todolists.SelectedItem;

            if (todolist == null)
            {
                MessageBox.Show("Please select a todolist");
                return;
            }

            bool IsOpen = false;

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(Window_Taches))
                {
                    window.Activate();
                    IsOpen = true;
                }
            }
            if (!IsOpen)
            {

                Window_Taches window_Taches = new Window_Taches(todolist);
                window_Taches.Show();
            }
        }

        private void LV_Todolists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Todolist todolist = (Todolist)LV_Todolists.SelectedItem;

            if (LV_Todolists.SelectedItem != null)
            {
                ListName_TB.Text = todolist.Name;
                Genre_CB.SelectedItem = todolist.Genre;
            }
            else
            {
                ListName_TB.Text = "";
                Genre_CB.SelectedItem = null;
            }
        }

        private void Genre_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}