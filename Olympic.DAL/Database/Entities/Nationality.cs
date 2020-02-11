using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympic.DAL.Database.Entities
{
    public class Nationality
    {
        public int Id { get; set; }
        public string Country { get; set; }
    }

    public class NationalityConfig : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {

            builder.Property(x => x.Country).IsRequired();

            builder.HasData(
                new Nationality { Id = 1, Country = "USA" },
                new Nationality { Id = 2, Country = "GRB" },
                new Nationality { Id = 3, Country = "HUH" },
                new Nationality { Id = 4, Country = "FR" }
            );
        }
    }
}
