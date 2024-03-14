using System;
using System.Collections.Generic;

namespace AgendaSQL_App.Agenda_db;

public partial class Contact
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public int? Age { get; set; }

    public string? Email { get; set; }

    public string Phone { get; set; } = null!;

    public string? Addresse { get; set; }

    public string? Codepostal { get; set; }

    public string? Ville { get; set; }

    public string? Dateofbirth { get; set; }

    public string? Entreprise { get; set; }

    public string Relationship { get; set; } = null!;

    public virtual ICollection<ReseauxProfile> ReseauxProfiles { get; set; } = new List<ReseauxProfile>();
}
