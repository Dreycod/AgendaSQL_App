using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaSQL_App.Agenda_db;
using Microsoft.EntityFrameworkCore;
namespace AgendaSQL_App.Service.DAO
{
    internal class DAO_Todolist
    {
        // get all todolists
        public IEnumerable<Todolist> GetAllTodolists()
        {
            using (var db = new AgendaSuzukidbContext())
            {
                return db.Todolists.ToList();
            }
        }
        // add a todolist
        public void AddTodolist(Todolist todolist)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                db.Todolists.Add(todolist);
                db.SaveChanges();
            }
        }
        // get a todolist by id
        public Todolist GetTodolistById(int id)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                return db.Todolists.Find(id);
            }
        }
        // update a todolist
        public void UpdateTodolist(Todolist todolist)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                db.Todolists.Update(todolist);
                db.SaveChanges();
            }
        }
        // delete a todolist
        public void DeleteTodolist(int id)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                var todolist = db.Todolists.SingleOrDefault(c => c.Id == id);
                if (todolist != null)
                {
                    db.Todolists.Remove(todolist);
                    db.SaveChanges();
                }
            }
        }
        // reset todolists
        public void ResetTodolists()
        {
            using (var db = new AgendaSuzukidbContext())
            {
                db.Todolists.RemoveRange(db.Todolists);
                db.SaveChanges();
            }
        }
        // get todolist by genre
        public IEnumerable<Todolist> GetTodolistByGenre(string genre)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                return db.Todolists.Where(t => t.Genre == genre).ToList();
            }
        }
        // Get todoliststartsby name
        public IEnumerable<Todolist> GetTodolistStartsByName(string name)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                return db.Todolists.Where(t => t.Name.StartsWith(name)).ToList();
            }
        }

        // get a jointure of todolist and taches
        public IEnumerable<Todolist> GetTodolistWithTaches()
        {
            using (var db = new AgendaSuzukidbContext())
            {
                return db.Todolists.Include("Taches").ToList();
            }
        }

        public IEnumerable<Todolist> GetTodolistWithTachesByGenre(string genre)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                return db.Todolists.Include("Taches").Where(t => t.Genre == genre).ToList();
            }
        }
        public IEnumerable<Todolist> GetTodolistWithTachesStartsByName(string name)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                return db.Todolists.Include("Taches").Where(t => t.Name.StartsWith(name)).ToList();
            }
        }
    }
}