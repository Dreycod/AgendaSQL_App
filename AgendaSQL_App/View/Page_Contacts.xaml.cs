using AgendaSQL_App.Agenda_db;
using AgendaSQL_App.Service.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AgendaSQL_App.View
{
    /// <summary>
    /// Logique d'interaction pour Page_Contacts.xaml
    /// </summary>
    public partial class Page_Contacts : UserControl
    {
        DAO_Contact dao_contact;
        string current_Genre = "All";

        public Page_Contacts()
        {
            InitializeComponent();
            dao_contact = new DAO_Contact();
            UpdateContacts();
        }
        private void UpdateContacts()
        {
            string filter = textBoxFilter.Text;
            ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

            foreach (Contact contact in dao_contact.GetAllContacts())
            {
                contacts.Add(contact);
            }
            IEnumerable<Contact> Liste = contacts;

            if (Liste != null)
            {
                if (current_Genre != "All")
                {
                    Liste = dao_contact.GetContactsByRelationship(current_Genre);

                    if (filter != "")
                    {
                        Liste = Liste.Where(todolist => todolist.Name.Contains(filter));
                    }
                }
                else if (filter != "")
                {
                    Liste = dao_contact.GetContactsStartsByPrenom(filter);
                }
            }

            DG_Contacts.ItemsSource = Liste;

            int count = DG_Contacts.Items.Count;
            TotalContactsTB.Text = count.ToString() + " Total Contacts";
        }
        private void ToggleAddMember_Click(object sender, RoutedEventArgs e)
        {
            // check if a window is already open
            bool IsOpen = false;

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(Window_ContactInfo))
                {
                    MessageBox.Show("Please close the current window before opening a new one");
                    IsOpen = true;
                }
            }
            if (!IsOpen)
            {
                Window_ContactInfo window_ContactInfo = new Window_ContactInfo(this, null);
                window_ContactInfo.Show();
            }
        }

        private void ResetMembers_Click(object sender, RoutedEventArgs e)
        {
            dao_contact.ResetContacts();
        }
        private void Relationship_Click(object sender, RoutedEventArgs e)
        {
            string Content = (sender as Button).Content.ToString();
            current_Genre = Content;
            UpdateContacts();
        }
        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this contact?", "Delete Contact", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            Contact contact = (Contact)DG_Contacts.SelectedItem;
            dao_contact.DeleteContact(contact.Id);
            UpdateContacts();
        }
        private void EditContact_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = (Contact)DG_Contacts.SelectedItem;
            // check if a window is already open
            bool IsOpen = false;

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(Window_ContactInfo))
                {
                    MessageBox.Show("Please close the current window before opening a new one");
                    IsOpen = true;
                }
            }
            if (!IsOpen)
            {
                Window_ContactInfo window_ContactInfo = new Window_ContactInfo(this, contact);
                window_ContactInfo.Show();
            }
        }
        private void OpenReseau_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = (Contact)DG_Contacts.SelectedItem;
            bool IsOpen = false;

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(Window_ReseauSocial))
                {
                    MessageBox.Show("Please close the current window before opening a new one");
                    IsOpen = true;
                }
            }
            if (!IsOpen)
            {
                Window_ReseauSocial window_Reseau = new Window_ReseauSocial(contact);
                window_Reseau.Show();
            }
        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateContacts();
        }
    }
}

