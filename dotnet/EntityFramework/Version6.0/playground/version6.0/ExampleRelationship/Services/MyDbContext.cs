using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleRelationship.Models.ManyToMany;
using ExampleRelationship.Models.OneToMany;
using ExampleRelationship.Models.OntToOne;

namespace ExampleRelationship.Services
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("Ef.Relationship")
        {
            Database.SetInitializer<MyDbContext>(new DropCreateDatabaseAlways<MyDbContext>());
        }

        public DbSet<Student1> Students1 { get; set; }
        public DbSet<Student2> Students2 { get; set; }

        public DbSet<Employee> Employees1 { get; set; }
        public DbSet<Company> Companies1 { get; set; }
        public DbSet<Employee2> Employees2 { get; set; }
        public DbSet<Company2> Companies2 { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<User2> Users2 { get; set; }
        public DbSet<Application2> Applications2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student2Adress>().HasKey(e => e.StudentId);
            modelBuilder.Entity<Student2>()
                .HasOptional(s => s.Adress)
                .WithRequired(req => req.Student2);

            modelBuilder.Entity<Employee2>()
                .HasOptional<Company2>(s => s.Company)
                .WithMany(s => s.Employees)
                .HasForeignKey(s => s.CompanyId);
//            modelBuilder.Entity<Company2>()
//                .HasMany<Employee2>(s => s.Employees)
//                .WithRequired(s => s.Company)
//                .HasForeignKey(s => s.CompanyId);

            modelBuilder.Entity<User2>()
                .HasMany<Application2>(s => s.Applications)
                .WithMany(c => c.Users)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("ApplicationId");
                    cs.ToTable("User2ToApplication2");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
