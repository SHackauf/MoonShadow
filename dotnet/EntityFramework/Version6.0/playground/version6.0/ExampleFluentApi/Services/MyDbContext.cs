using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleFluentApi.Models;

namespace ExampleFluentApi.Services
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("EF.FluentApi")
        {
            Database.SetInitializer<MyDbContext>(new DropCreateDatabaseAlways<MyDbContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRange> ProductRanges { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // https://msdn.microsoft.com/de-de/data/jj591617.aspx
            // https://msdn.microsoft.com/en-us/data/jj591620.aspx

            var employeeConfig = modelBuilder.Entity<Employee>();
            employeeConfig
                .HasKey(e => e.PersonnelNumber);
            employeeConfig.Property(p => p.Lastname)
                .HasMaxLength(50)
                .IsRequired();
            employeeConfig.Property(p => p.Firstname)
                .HasMaxLength(50)
                .IsRequired();
            employeeConfig.Property(p => p.RowVersion)
                .IsRowVersion();

            var menuConfig = modelBuilder.Entity<Menu>();
            menuConfig.ToTable("ProgramMenu")
                .HasKey(p => new { p.MainMenu, p.SubMenu })
                .Ignore(p => p.SuperName);
            menuConfig.Property(p => p.MainMenu)
                .HasColumnOrder(1);
            menuConfig.Property(p => p.SubMenu)
                .HasColumnOrder(2);
            menuConfig.Property(p => p.Pos)
                .HasColumnName("MenuPos");

            var customerConfig = modelBuilder.Entity<Customer>();
            customerConfig.HasKey(p => p.Id);
            customerConfig.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            var productConfig = modelBuilder.Entity<Product>();
            productConfig.HasKey(p => p.Id);
            productConfig
                .HasOptional(p => p.MainRange)
                .WithMany(r => r.MainProducts)
                .HasForeignKey(p => p.MainRangeId);
            productConfig
                .HasOptional(p => p.SubRange)
                .WithMany(r => r.SubProducts)
                .HasForeignKey(p => p.SubRangeId);

            var productRangeConfig = modelBuilder.Entity<ProductRange>();
            productRangeConfig
                .HasKey(p => p.Id);

            modelBuilder.Entity<Student>().Map(m =>
                {
                    m.Properties(p => new { p.Id, p.Firstname, p.Lastname });
                    m.ToTable("Student");
                }).Map(m =>
                    { 
                        m.Properties(p => new { p.Id, p.Street, p.Zip, p.City, p.Country });
                        m.ToTable("StudentAdress");
                    });

            base.OnModelCreating(modelBuilder);
        }
    }
}
