using AgendaSQL_App.Agenda_db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSQL_App.Service.DAO
{
    class DAO_Reseaux
    {
        public DAO_Reseaux()
        { 
        }
        
        public IEnumerable<ReseauxProfile> GetReseauxProfileByContactId(int id)
        {
            using (var db = new AgendaDbContext())
            {
                var ListReseauxProfile = db.ReseauxProfiles.Where(c => c.ContactId == id).ToList();
                return ListReseauxProfile;
            }
        }
        // Get reseauxmedium information by reseauxprofile id
        public ReseauxMedium GetReseauxMediumByReseauxProfileId(int id)
        {
            using (var db = new AgendaDbContext())
            {
                var reseauxProfile = db.ReseauxProfiles.Find(id);
                var reseauxMedium = db.ReseauxMedia.Find(reseauxProfile.ReseauxMediaId);
                return reseauxMedium;
            }
        }
        public void AddReseauxProfile(ReseauxProfile reseauxProfile)
        {
            using (var db = new AgendaDbContext())
            {
                db.ReseauxProfiles.Add(reseauxProfile);
                db.SaveChanges();
            }
        }
    }


}
