using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleConfiguration.Models
{
    class PersonEntityConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonEntityConfiguration()
        {
            this.ToTable("PersonBase");

            this.HasKey<string>(k => k.PersonnelNumber);

            this.Property(p => p.Lastname)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(p => p.Firstname)
                .HasMaxLength(100);

            this.Property(p => p.RowVersion)
                .IsRowVersion();
        }
    }
}
