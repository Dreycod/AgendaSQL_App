using AgendaSQL_App.Agenda_db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSQL_App.Service.DAO
{
    internal class DAO_Taches
    {



        // get Taches by todolist id
        public IEnumerable<Tach> GetTachesByTodolistId(int id)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                return db.Taches.Where(t => t.TodolistId == id).ToList();
            }
        }
        // add tache to todolist
        public void AddTacheToTodolist(Tach tache)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                db.Taches.Add(tache);
                db.SaveChanges();
            }
        }
        // get tache by id
        public Tach GetTacheById(int id)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                return db.Taches.Find(id);
            }
        }
        // update tache
        public void UpdateTache(Tach tache)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                db.Taches.Update(tache);
                db.SaveChanges();
            }
        }
        // delete tache
        public void DeleteTache(int id)
        {
            using (var db = new AgendaSuzukidbContext())
            {
                var tache = db.Taches.SingleOrDefault(c => c.Idtaches == id);
                if (tache != null)
                {
                    db.Taches.Remove(tache);
                    db.SaveChanges();
                }
            }
        }
        // reset taches
        public void ResetTaches()
        {
            using (var db = new AgendaSuzukidbContext())
            {
                db.Taches.RemoveRange(db.Taches);
                db.SaveChanges();
            }
        }

    }
}