using System;
using System.Collections.Generic;

namespace AgendaSQL_App.Agenda_db;

public partial class Tâch
{
    public int Idtâches { get; set; }

    public string? Nom { get; set; }

    public sbyte Fait { get; set; }

    public int TodolistIdTodolist { get; set; }

    public DateTime? Temps { get; set; }

    public virtual Todolist TodolistIdTodolistNavigation { get; set; } = null!;
}
