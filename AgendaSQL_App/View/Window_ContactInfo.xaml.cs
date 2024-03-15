using AgendaSQL_App.Agenda_db;
using AgendaSQL_App.Service.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Page_Contacts page_dashboard;
        Contact presetContact;
        public Window_ContactInfo(Page_Contacts p_dash, Contact contact)
        {
            InitializeComponent();
            dao_contact = new DAO_Contact();
            page_dashboard = p_dash;
            if (contact != null)
            {
               presetContact = contact;
               EditMember();
            }
        }

        private void EditMember()
        {

            NomTB.Text = presetContact.Name;
            PrenomTB.Text = presetContact.Prenom;
            AgeTB.Text = presetContact.Age.ToString();
            EmailTB.Text = presetContact.Email;
            PhoneTB.Text = presetContact.Phone;
            AddressTB.Text = presetContact.Addresse;
            PostalCodeTB.Text = presetContact.Codepostal;
            CityTB.Text = presetContact.Ville;
            Date.SelectedDate = DateTime.Parse(presetContact.Dateofbirth);
            CompanyTB.Text = presetContact.Entreprise;
        }

        private void SaveNewMember_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve values from text boxes and date picker
            string name = NomTB.Text;
            string prenom = PrenomTB.Text;
            string str_age = AgeTB.Text;
            string email = EmailTB.Text;
            string phone = PhoneTB.Text;
            string address = AddressTB.Text;
            string postalCode = PostalCodeTB.Text;
            string city = CityTB.Text;
            DateTime? dateOfBirth = Date.SelectedDate;
            string company = CompanyTB.Text;

            string relationship;
            int age;


            // Verify that all required fields are filled
            if (name == "" || prenom == "" || str_age == "" || email == "" || phone == "" || address == "" || postalCode == "" || city == "" || dateOfBirth == null || company == "")
            {
                MessageBox.Show("Please fill all required fields");
                return;
            }
            if (RelationshipCB.SelectedItem == null)
            {
                MessageBox.Show("Please select a relationship");
                return;
            }

            // Convert age to int
            try
            {
                age = int.Parse(str_age);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid age");
                return;
            }

            relationship = RelationshipCB.SelectedItem.ToString().Substring(38);

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

            if (presetContact != null)
            {
                contact.Id = presetContact.Id;
                dao_contact.UpdateContact(contact);
            }
            else
            {
              dao_contact.AddContact(contact);
            }
            page_dashboard.DG_Contacts.ItemsSource = dao_contact.GetAllContacts();
            this.Close();
        }
    }
}
