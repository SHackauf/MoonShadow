using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleInheritance.Models.TPC;
using ExampleInheritance.Models.TPH;
using ExampleInheritance.Models.TPT;

namespace ExampleInheritance.Services
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("EF.Inheritance")
        {
            Database.SetInitializer<MyDbContext>(new DropCreateDatabaseAlways<MyDbContext>());
        }

        public DbSet<TphPerson> TphPerson { get; set; }
        public DbSet<TptPerson> TptPerson { get; set; }
        public DbSet<TpcPerson> TpcPerson { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
//            modelBuilder.Entity<TptPerson>()
//               .Map<TptMitarbeiter>(m => m.Requires("Type").HasValue("Mit"))
//               .Map<TptKunde>(m => m.Requires("Type").HasValue("Kd"));

            // modelBuilder.Entity<TptKunde>().ToTable("TptKunden");
            // modelBuilder.Entity<TptMitarbeiter>().ToTable("TptMitarbeiters");

            modelBuilder.Entity<TpcKunde>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("TpcKunden");
            });

            modelBuilder.Entity<TpcMitarbeiter>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("TpcMitarbeiter");
            });  
        } 
    }
}
