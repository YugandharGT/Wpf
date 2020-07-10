using Wpf.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Wpf.Services
{
    public class FacultyService : IFaculty
    {
        readonly WpfDbContext db;

        public FacultyService()
        {

        }

        public FacultyService(WpfDbContext wpfDbContext)
        {
            db = wpfDbContext;
        }

        public IEnumerable<Faculty> GetDetailsById(int id)
        {
            if (db != null)
            {
                return db.Set<Faculty>().Where(p => p.Id == id);
            }
            return null;
        }

        public IEnumerable<Faculty> GetDetailsByName(string name)
        {
            if (db != null)
            {
                return db.Set<Faculty>().Where(p => p.Name == name);
            }
            return null;
        }

        public Faculty AddFaculty(Faculty faculty)
        {
            var result = db.Add(faculty);
            db.SaveChanges();
            return result.Entity; 
        }

        public IEnumerable<Faculty> GetDetails()
        {
            if (db != null)
            {
                return db.Set<Faculty>().ToList();
            }
            return null;
        }
    }
}
