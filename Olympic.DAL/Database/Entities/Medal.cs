using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympic.DAL.Database.Entities
{
    public class Medal
    {
        public int Id { get; set; }
        public int OlympiconId { get; set; }
        public Olympicon Olympicon { get; set; }
        public int Place { get; set; }
        public int Year { get; set; }
    }

    public class MedalConfig : IEntityTypeConfiguration<Medal>
    {
        public void Configure(EntityTypeBuilder<Medal> builder)
        {

            builder.Property(x => x.Place).IsRequired();
            builder.Property(x => x.Year).IsRequired();



            builder.HasData(
                new Medal { Id = 1, OlympiconId = 1, Place = 3, Year = 2008 },
                new Medal { Id = 2, OlympiconId = 1, Place = 1, Year = 2016 },
                new Medal { Id = 3, OlympiconId = 2, Place = 2, Year = 2012 },
                new Medal { Id = 4, OlympiconId = 3, Place = 3, Year = 2008 }
            );
        }
    }
}
