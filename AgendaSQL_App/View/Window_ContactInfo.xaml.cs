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
    /// Logique d'interaction pour Window_ContactInfo.xaml
    /// </summary>
    public partial class Window_ContactInfo : Window
    {
        DAO_Contact dao_contact;
        Page_Dashboard page_dashboard;
        public Window_ContactInfo(Page_Dashboard p_dash)
        {
            InitializeComponent();
            dao_contact = new DAO_Contact();
            page_dashboard = p_dash;
        }
        private void SaveNewMember_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve values from text boxes and date picker
            string name = NomTB.Text;
            string prenom = PrenomTB.Text;
            int age = int.Parse(AgeTB.Text); // Assuming age is an integer
            string email = EmailTB.Text;
            string phone = PhoneTB.Text;
            string address = AddressTB.Text;
            string postalCode = PostalCodeTB.Text;
            string city = CityTB.Text;
            DateTime? dateOfBirth = Date.SelectedDate;
            string company = CompanyTB.Text;
            string relationship = RelationshipTB.Text;
            string socialMediaProfiles = SocialMediaTB.Text;

            Contact contact = new Contact
            {
                Name = name,
                Prenom = prenom,
                Age = age,
                Email = email,
                Phone = phone,
                Addresse = address,
                Codepostal = postalCode,
                Relationship = relationship,
                Ville = city,
                Dateofbirth = dateOfBirth.ToString(),
                Entreprise = company,
            };

            dao_contact.AddContact(contact);
            page_dashboard.DG_Contacts.ItemsSource = dao_contact.GetAllContacts();
            this.Close();
        }
    }
}
