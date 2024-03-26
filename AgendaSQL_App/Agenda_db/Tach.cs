using System;
using System.Collections.Generic;

namespace AgendaSQL_App.Agenda_db;

public partial class Tach
{
    public int Idtaches { get; set; }

    public string? Nom { get; set; }

    public sbyte Fait { get; set; }

    public DateTime? Temps { get; set; }

    public int TodolistId { get; set; }

    public virtual Todolist Todolist { get; set; } = null!;
}
