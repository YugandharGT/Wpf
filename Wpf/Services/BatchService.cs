using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Data;

namespace Wpf.Services
{
    public class BatchService : IBatch
    {
        readonly WpfDbContext db;

        public BatchService(WpfDbContext wpfDbContext)
        {
            db = wpfDbContext;
        }

        public Batch AddBatch(Batch batch)
        {
            var result = db.Add(batch);
            db.SaveChanges();
            return result.Entity;
        }

        public Batch GetBatchDetails(int id)
        {
            if (db != null)
            {
                return db.Set<Batch>().FirstOrDefault(c => c.BatchId == id);
            }
            return null;
        }
    }
}
