using Google.Apis.Calendar.v3.Data;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
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
using WpfAgendaDatabase.Service.DAO;

namespace AgendaSQL_App.View
{
    /// <summary>
    /// Interaction logic for Page_Agenda.xaml
    /// </summary>
    public partial class Page_Agenda : UserControl
    {
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();

        public Page_Agenda()
        {
            InitializeComponent();

            this.DataContext = this;
            DateTime Today = DateTime.Now;

            LoadEventsAsync(Today);
        }

        private async void LoadEventsAsync(DateTime date)
        {
            try
            {
                var service = await DAO_GoogleCalendar.GetCalendarServiceAsync();
                var request = service.Events.List("primary");
                // time min et max sur la journée sélectionnée
                request.TimeMin = date.Date;
                request.TimeMax = date.Date.AddDays(1);
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.MaxResults = 10;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
               

                var events = await request.ExecuteAsync();


                foreach (var eventItem in events.Items)
                {
                    Events.Add(eventItem);
                }


                EventsListView.ItemsSource = Events;
            }
            catch (Exception ex)
            {
                // Gérer l'erreur, par exemple en affichant un message
                MessageBox.Show($"Erreur lors du chargement des événements: {ex.Message}");
            }
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // Récupérer la date sélectionnée et load
            var date = DateCalendar.SelectedDate.Value;
            // clear the list
            Events.Clear();
            LoadEventsAsync(date);

        }
    }
}
