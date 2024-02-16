using System;
using System.Collections.Generic;

namespace AgendaSQL_App.Agenda_db;

public partial class Todolist
{
    public int IdTodolist { get; set; }

    public string? Name { get; set; }

    public string? Genre { get; set; }

    public virtual ICollection<Tâch> Tâches { get; set; } = new List<Tâch>();
}
