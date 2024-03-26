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
    /// Interaction logic for Window_ReseauSocial.xaml
    /// </summary>
    public partial class Window_ReseauSocial : Window
    {
        DAO_Contact dao_contact;
        DAO_Reseaux dao_reseaux;

        Contact PreContact;

        public Window_ReseauSocial(Contact contact)
        {
            InitializeComponent();
            dao_contact = new DAO_Contact();
            PreContact = contact;

        }
        private void SaveNewMember_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
