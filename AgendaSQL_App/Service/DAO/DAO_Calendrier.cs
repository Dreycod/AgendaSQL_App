using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using System.Linq;

namespace WpfAgendaDatabase.Service.DAO
{
    public class DAO_GoogleCalendar
    {
        private static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        private static string ApplicationName = "AgendaDB";

        // Méthode pour obtenir le service de calendrier
        public static async Task<CalendarService> GetCalendarServiceAsync()
        {
            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = "536688738653-hhfdpq3e4at05ks63ql0r7rihav32cgr.apps.googleusercontent.com",
                    ClientSecret = "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"
                },
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore("token.json", true));

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }

        // Méthode pour obtenir les événements du calendrier
        public static async Task<List<Google.Apis.Calendar.v3.Data.Event>> GetEventsAsync(CalendarService service)
        {
            // Assurez-vous que le service est déjà initialisé
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service), "Le service de calendrier n'est pas initialisé.");
            }

            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now.AddMonths(-1);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            try
            {
                var events = await request.ExecuteAsync();
                return events.Items.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Google.Apis.Calendar.v3.Data.Event>();
            }
        }

    }
}