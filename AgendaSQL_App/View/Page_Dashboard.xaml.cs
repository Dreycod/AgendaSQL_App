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
          //  dao_contact = new DAO_Contact();
//            DG_Contacts.ItemsSource = dao_contact.GetAllContacts();
        }


        private void LV_Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddNewMember_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
