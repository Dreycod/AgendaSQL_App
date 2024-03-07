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
            DG_Contacts.ItemsSource = dao_contact.GetAllContacts();
        }


        private void LV_Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddNewMember_Click(object sender, RoutedEventArgs e)
        {
            NewMemberPopup.IsOpen = true;
        }

        private void SaveNewMember_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve values from text boxes and date picker
            string name = NameTextBox.Text;
            string prenom = PrenomTextBox.Text;
            int age = int.Parse(AgeTextBox.Text); // Assuming age is an integer
            string email = EmailTextBox.Text;
            string phone = PhoneTextBox.Text;
            string address = AddressTextBox.Text;
            string postalCode = PostalCodeTextBox.Text;
            string city = CityTextBox.Text;
            DateTime? dateOfBirth = DateOfBirthPicker.SelectedDate;
            string company = CompanyTextBox.Text;
            string socialMediaProfiles = SocialMediaTextBox.Text;

            Contact contact = new Contact
            {
                Id = 4, // auto increment ? 
                Name = name,
                Prenom = prenom,
                Age = age,
                Email = email,
                Phone = phone,
                Addresse = address,
                Codepostal = postalCode,
                Ville = city,
                Dateofbirth = dateOfBirth.ToString(),
                Entreprise = company
            };

            dao_contact.AddContact(contact);

            // Save the new member's information as needed
            // You can implement your logic here, such as saving to a database or updating UI
        }

        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            NewMemberPopup.IsOpen = false;
        }

        private void ResetMembers_Click(object sender, RoutedEventArgs e)
        {
            dao_contact.ResetContacts();
        }
    }
}
