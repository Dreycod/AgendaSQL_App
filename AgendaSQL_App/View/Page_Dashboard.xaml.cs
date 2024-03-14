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
using AgendaSQL_App.Agenda_db;
using AgendaSQL_App.Service.DAO;

namespace AgendaSQL_App.View
{
    /// <summary>
    /// Logique d'interaction pour Page_Dashboard.xaml
    /// </summary>
    public partial class Page_Dashboard : UserControl
    {
        DAO_Contact dao_contact;
        public Page_Dashboard()
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
        }


        private void ToggleAddMember_Click(object sender, RoutedEventArgs e)
        {
            NewMemberPopup.IsOpen = true;
        }
        private void ToggleRemoveMember_Click(object sender, RoutedEventArgs e)
        {
            RemoveMemberPopup.IsOpen = true;
        }

        private void RemoveMember_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(Remove_IDTB.Text);
            dao_contact.DeleteContact(id);
            RemoveMemberPopup.IsOpen = false;
            DG_Contacts.ItemsSource = dao_contact.GetAllContacts();
        }
        private void SaveMembers_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Contact> contacts = DG_Contacts.ItemsSource as IEnumerable<Contact>;
            foreach (Contact contact in contacts)
            {
                dao_contact.UpdateContact(contact);
            }
        }
        private void SaveNewMember_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve values from text boxes and date picker
            string name = Add_NomTB.Text;
            string prenom = Add_PrenomTB.Text;
            int age = int.Parse(Add_AgeTB.Text); // Assuming age is an integer
            string email = Add_EmailTB.Text;
            string phone = Add_PhoneTB.Text;
            string address = Add_AddressTB.Text;
            string postalCode = Add_PostalCodeTB.Text;
            string city = Add_CityTB.Text;
            DateTime? dateOfBirth = Add_Date.SelectedDate;
            string company = Add_CompanyTB.Text;
            string socialMediaProfiles = Add_SocialMediaTB.Text;

            Contact contact = new Contact
            {
                Name = name,
                Prenom = prenom,
                Age = age,
                Email = email,
                Phone = phone,
                Addresse = address,
                Codepostal = postalCode,
                Ville = city,
                Dateofbirth = dateOfBirth.ToString(),
                Entreprise = company,
            };

            dao_contact.AddContact(contact);
            NewMemberPopup.IsOpen = false; 
            DG_Contacts.ItemsSource = dao_contact.GetAllContacts();
        }

        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            NewMemberPopup.IsOpen = false;
        }

        private void ResetMembers_Click(object sender, RoutedEventArgs e)
        {
            dao_contact.ResetContacts();
        }
        private void CancelAddPopup_Click(object sender, RoutedEventArgs e)
        {
            NewMemberPopup.IsOpen = false;
        }
        private void CancelRemovePopup_Click(object sender, RoutedEventArgs e)
        {
            RemoveMemberPopup.IsOpen = false;
        }
    }
}
