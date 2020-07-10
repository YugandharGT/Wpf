using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Wpf.Data
{
    public class WpfDbContext : DbContext
    {

        public DbSet<Faculty> Faculties;
        public DbSet<Batch> Batches;
        public DbSet<Participant> Participants;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PC\\SQLEXPRESS;Database=Wpf;Integrated Security=SSPI;");
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>();
            modelBuilder.Entity<Batch>().HasKey(c => c.BatchId);
            modelBuilder.Entity<Participant>();
            //modelBuilder.Entity<Participant>().HasOne<Batch>(ch => ch.Batch).WithMany(m => m.Participants).HasForeignKey(fk => fk.Batchid);
            //modelBuilder.Entity<Faculty>().HasOne<Batch>(ch => ch.Batches).WithOne(m => m.Faculties).HasForeignKey<Batch>(fk => fk.FacultyId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
