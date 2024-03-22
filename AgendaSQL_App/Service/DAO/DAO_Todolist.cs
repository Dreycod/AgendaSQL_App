﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaSQL_App.Agenda_db;
namespace AgendaSQL_App.Service.DAO
{
    internal class DAO_Todolist
    {
        // get all todolists
        public IEnumerable<Todolist> GetAllTodolists()
        {
            using (var db = new AgendaDbContext())
            {
                return db.Todolists.ToList();
            }
        }
        // add a todolist
        public void AddTodolist(Todolist todolist)
        {
            using (var db = new AgendaDbContext())
            {
                db.Todolists.Add(todolist);
                db.SaveChanges();
            }
        }
        // get a todolist by id
        public Todolist GetTodolistById(int id)
        {
            using (var db = new AgendaDbContext())
            {
                return db.Todolists.Find(id);
            }
        }
        // update a todolist
        public void UpdateTodolist(Todolist todolist)
        {
            using (var db = new AgendaDbContext())
            {
                db.Todolists.Update(todolist);
                db.SaveChanges();
            }
        }
        // delete a todolist
        public void DeleteTodolist(int id)
        {
            using (var db = new AgendaDbContext())
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
            using (var db = new AgendaDbContext())
            {
                db.Todolists.RemoveRange(db.Todolists);
                db.SaveChanges();
            }
        }
        // get todolist by genre
        public IEnumerable<Todolist> GetTodolistByGenre(string genre)
        {
            using (var db = new AgendaDbContext())
            {
                return db.Todolists.Where(t => t.Genre == genre).ToList();
            }
        }
        // Get todoliststartsby name
        public IEnumerable<Todolist> GetTodolistStartsByName(string name)
        {
            using (var db = new AgendaDbContext())
            {
                return db.Todolists.Where(t => t.Name.StartsWith(name)).ToList();
            }
        }
    }
}
