using System;
using System.Collections.Generic;

namespace AgendaSQL_App.Agenda_db;

public partial class ReseauxProfile
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string? Followers { get; set; }

    public string Url { get; set; } = null!;

    public int ContactId { get; set; }

    public int ReseauxMediaId { get; set; }

    public virtual Contact Contact { get; set; } = null!;

    public virtual ReseauxMedium ReseauxMedia { get; set; } = null!;
}
