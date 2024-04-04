using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AgendaSQL_App.Model
{
    public class Appointment
    {
        /// <summary>
        /// Gets or sets the value to display the start date.
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets the value to display the end date.
        /// </summary>
        public DateTime To { get; set; }

        /// <summary>
        /// Gets or sets the value to display the subject.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the appointment background color.
        /// </summary>
        public Brush Background { get; set; }
    }
}
