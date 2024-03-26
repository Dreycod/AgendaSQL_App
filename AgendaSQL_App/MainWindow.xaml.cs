using AgendaSQL_App.Agenda_db;
using AgendaSQL_App.Service.DAO;
using AgendaSQL_App.View;
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

namespace AgendaSQL_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DAO_Contact DAO_Contact;
        public MainWindow()
        {
            InitializeComponent();
            DAO_Contact = new DAO_Contact();
            if (DAO_Contact.DatabaseExists() == false)
            {
                Accueil_BTN.IsEnabled = false;
            }

        }
        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ContactsBTN_Click(object sender, RoutedEventArgs e)
        {
            Page_Contacts ContactsPage = new Page_Contacts();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(ContactsPage);
        }

        private void Todolist_BTNClick(object sender, RoutedEventArgs e)
        {
            Page_Todolist page_Todolist = new Page_Todolist();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_Todolist);
        }
    }
}