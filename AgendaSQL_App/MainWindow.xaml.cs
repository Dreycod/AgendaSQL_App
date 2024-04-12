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
using System.Configuration;
using AgendaSQL_App.Service;

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
            LoggedIn();
        }

        public void CheckDatabase()
        {
            if (DAO_Contact.DatabaseExists() == false)
            {
                Contacts_BTN.IsEnabled = false;
                Todolist_BTN.IsEnabled = false;
                MessageBox.Show("Database not found, please check your connection string! Contacts & Todolist Buttons Disabled.");

                Page_Settings page_Settings = new Page_Settings();
                Grid_Content.Children.Clear();
                Grid_Content.Children.Add(page_Settings);
            }
            else
            {
                Contacts_BTN.IsEnabled = true;
                Todolist_BTN.IsEnabled = true;
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

        private void Accueil_BTN_Click(object sender, RoutedEventArgs e)
        {
            Page_Dashboard page_Dashboard = new Page_Dashboard();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_Dashboard);
        }

        private void Calendar_BTN_Click(object sender, RoutedEventArgs e)
        {
            Page_Agenda page_Agenda = new Page_Agenda();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_Agenda);
        }

        private void Settings_BTNClick(object sender, RoutedEventArgs e)
        {
            Page_Settings page_Settings = new Page_Settings();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_Settings);
        }

        private void Log_BTNClick(object sender, RoutedEventArgs e)
        {
            // Get config login info 
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string user = config.AppSettings.Settings["loginUser"].Value;
            string password = config.AppSettings.Settings["loginPassword"].Value;

            // Check if password and user are correct
            string Pwd = Password_PB.Password;
            if (Pwd.Length < 8)
            {
                Pwd = MD5Crypter.CrypterMot_de_passe(Password_PB.Password).ToString();
            }

            if (Pwd == password && Username_TB.Text == user)
            {
                LoggedIn();
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
        }


        private void Register_BTNClick(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(Window_Register))
                {
                    // make the index window active
                    window.Activate();
                    return;
                }
            }

            Window_Register window_Register = new Window_Register();
            window_Register.Show();

        }

        private void LoggedIn()
        {
            CheckDatabase();
            Grid_Content.Visibility = Visibility.Visible;
            Login_Screen.Visibility = Visibility.Hidden;
            Function_Border.Visibility = Visibility.Visible;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string user = config.AppSettings.Settings["loginUser"].Value;
            Username.Text = user;

            Page_Dashboard page_Dashboard = new Page_Dashboard();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(page_Dashboard);
        }

        private void LogOutBTNClick(object sender, RoutedEventArgs e)
        {
            Grid_Content.Visibility = Visibility.Hidden;
            Login_Screen.Visibility = Visibility.Visible;
            Function_Border.Visibility = Visibility.Hidden;
        }
    }
}