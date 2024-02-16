using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaSQL_App.Agenda_db;

namespace AgendaSQL_App.Service.DAO
{
    public class DAO_Contact
    {
        public IEnumerable<Contact> GetAllContacts()
        {
            using (var db = new AgendaDbContext())
            {
                return db.Contacts.ToList();
            }
        }

        public void AddContact(Contact contact)
        {
            using (var db = new AgendaDbContext())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
        }

        public Contact GetContactById(int id)
        {
            using (var db = new AgendaDbContext())
            {
                return db.Contacts.Find(id);
            }
        }
        public void UpdateContact(Contact contact)
        {
            using (var db = new AgendaDbContext())
            {
                db.Contacts.Update(contact);
                db.SaveChanges();
            }
        }
        public void DeleteContact(int id)
        {
            using (var db = new AgendaDbContext())
            {
                var contact = db.Contacts.Find(id);
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
        }

        public IEnumerable<Contact> GetContactsByName(string name)
        {
            using (var db = new AgendaDbContext())
            {
                return db.Contacts.Where(c => c.Name.Contains(name)).ToList();
            }
        }

    }
}
