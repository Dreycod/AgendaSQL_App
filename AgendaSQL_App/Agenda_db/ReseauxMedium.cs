using System;
using System.Collections.Generic;

namespace AgendaSQL_App.Agenda_db;

public partial class ReseauxMedium
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Logourl { get; set; } = null!;

    public virtual ICollection<ReseauxProfile> ReseauxProfiles { get; set; } = new List<ReseauxProfile>();
}
