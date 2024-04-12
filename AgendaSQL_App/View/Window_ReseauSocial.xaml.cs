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
        DAO_Reseaux dao_reseaux;
        Contact PreContact;
        ReseauxProfile SelectedReseaux;

        public Window_ReseauSocial(Contact contact)
        {
            InitializeComponent();
            dao_reseaux = new DAO_Reseaux();    
            PreContact = contact;
            LoadInfo();
        }

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
        private void LoadInfo()
        {

            if (PreContact != null)
            {
                IEnumerable<ReseauxProfile> liste_reseaux = dao_reseaux.GetReseauxProfileByContactId(PreContact.Id);
                DG_SocialMedia.ItemsSource = liste_reseaux;

                Title_TB.Text = PreContact.Prenom+"'s Social Profiles";
            }

            IEnumerable<ReseauxMedium> reseauxMediums = dao_reseaux.GetAllReseauxMedium();

            foreach (var item in reseauxMediums)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = item.Name;
                cbi.Tag = item.Id;
                Reseaux_CB.Items.Add(cbi);
            }
        }

        private void SaveNewMember_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ReseauxProfile reseaux = new ReseauxProfile();

            ComboBoxItem cbi = (ComboBoxItem)Reseaux_CB.SelectedItem;
             
            int reseauxMediumId = int.Parse(cbi.Tag.ToString());
            reseaux.ReseauxMediaId = reseauxMediumId;
            reseaux.Nom = Nom_TB.Text;
            reseaux.Url = Url_TB.Text;

            MessageBox.Show(SelectedReseaux.Id.ToString());

            if (SelectedReseaux == null)
            {
                reseaux.ContactId = PreContact.Id;
                dao_reseaux.AddReseauxProfile(reseaux);
            }
            else
            {
                reseaux.ContactId = SelectedReseaux.ContactId;
                dao_reseaux.UpdateReseauxProfile(reseaux);
            }

            LoadInfo();

        }

        private void DeleteTodolist_Click(object sender, RoutedEventArgs e)
        {
            ReseauxProfile reseaux = (ReseauxProfile)DG_SocialMedia.SelectedItem;

            if (reseaux != null)
            {
                using (var db = new AgendaSuzukidbContext())
                {
                    db.ReseauxProfiles.Remove(reseaux);
                    db.SaveChanges();
                }

                LoadInfo();
            }

        }

        private void DG_SocialMedia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // check if selected item is not null

            if (DG_SocialMedia.SelectedItem == null)
            {
                SelectedReseaux = null;
                Nom_TB.Text = "";
                Url_TB.Text = "";
                Followers_TB.Text = "";
                Reseaux_CB.SelectedItem = null;
                return;
            }

            SelectedReseaux = (ReseauxProfile)DG_SocialMedia.SelectedItem;

            Nom_TB.Text = SelectedReseaux.Nom;
            Url_TB.Text = SelectedReseaux.Url;
            Followers_TB.Text = "";

            if (SelectedReseaux.Followers != null)
            {
                Followers_TB.Text = SelectedReseaux.Followers.ToString();
            }

            foreach (ComboBoxItem item in Reseaux_CB.Items)
            {
                if (int.Parse(item.Tag.ToString()) == SelectedReseaux.ReseauxMediaId)
                {
                    Reseaux_CB.SelectedItem = item;
                    break;
                }
            }

        }
    }
}
