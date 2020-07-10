using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Data;

namespace Wpf.Services
{
    public class ParticipantService : IParticipant
    {
        private WpfDbContext db;

        public ParticipantService(WpfDbContext wpfDbContext)
        {
            db = wpfDbContext;
        }

        public Participant AddParticipant(Participant participant)
        {
            var result = db.Add(participant);
            db.SaveChanges();
            return result.Entity;
        }

        public IEnumerable<Participant> GetDetails()
        {
            if (db != null)
            {
                return db.Set<Participant>().ToList();
            }
            return null;
        }

        public IEnumerable<Participant> GetDetailsById(int id)
        {
            if (db != null)
            {
                return db.Set<Participant>().Where(p => p.Id == id);
            }
            return null;
        }

        public IEnumerable<Participant> GetDetailsByName(string name)
        {
            if (db != null)
            {
                return db.Set<Participant>().Where(p => p.Name == name);
            }
            return null;
        }
    }
}
