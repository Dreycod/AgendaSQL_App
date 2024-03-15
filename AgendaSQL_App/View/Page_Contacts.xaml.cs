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
        public Page_Contacts()
        {
            InitializeComponent();
            dao_contact = new DAO_Contact();
            UpdateContacts();
        }

        private void UpdateContacts()
        {
            DG_Contacts.ItemsSource = dao_contact.GetAllContacts();
            ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

            foreach (Contact contact in dao_contact.GetAllContacts())
            {
                contacts.Add(contact);
            }
            DG_Contacts.ItemsSource = contacts;

            int count = DG_Contacts.Items.Count;
            TotalContactsTB.Text = count.ToString()+" Total Contacts";
        }

        private void ToggleAddMember_Click(object sender, RoutedEventArgs e)
        {
            Window_ContactInfo window_ContactInfo = new Window_ContactInfo(this, null);
            window_ContactInfo.Show();
        }

        private void SaveMembers_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Contact> contacts = DG_Contacts.ItemsSource as IEnumerable<Contact>;
            foreach (Contact contact in contacts)
            {
                dao_contact.UpdateContact(contact);
            }
        }
        private void ResetMembers_Click(object sender, RoutedEventArgs e)
        {
            dao_contact.ResetContacts();
        }
        private void Relationship_Click(object sender, RoutedEventArgs e)
        {
            string Content = (sender as Button).Content.ToString();
            if (Content == "All")
            {
                DG_Contacts.ItemsSource = dao_contact.GetAllContacts();
            }
            else
            {
                DG_Contacts.ItemsSource = dao_contact.GetContactsByRelationship(Content);
            }
        }
        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = (Contact)DG_Contacts.SelectedItem;
            dao_contact.DeleteContact(contact.Id);
            UpdateContacts();
        }

        private void EditContact_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = (Contact)DG_Contacts.SelectedItem;
            Window_ContactInfo window_ContactInfo = new Window_ContactInfo(this, contact);
            window_ContactInfo.Show();
        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = textBoxFilter.Text;

            if (filter == "")
            {
                DG_Contacts.ItemsSource = dao_contact.GetAllContacts();
            }
            else
            {
                DG_Contacts.ItemsSource = dao_contact.GetContactsStartsByPrenom(filter);
            }
        }
    }
}

