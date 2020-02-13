using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olympic.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympic.DAL.Database.Entities
{
    public class Olympicon
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public Sport Sport { get; set; }
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        public ICollection<Medal> Medals { get; set; }
    }

    public class OlympiconConfig : IEntityTypeConfiguration<Olympicon>
    {
        public void Configure(EntityTypeBuilder<Olympicon> builder)
        {
            builder.HasMany(x => x.Medals)
               .WithOne(y => y.Olympicon)
               .HasForeignKey(y => y.OlympiconId);

            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Forename).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.Sport).IsRequired();
            builder.Property(x => x.Age).IsRequired();


            builder.HasData(
                new Olympicon { Id = 1, Surname = "Doe", Forename = "John", Birthday = new DateTime(1995, 6, 30), Age = 24, Sport = Sport.Archery, NationalityId = 1 },
                new Olympicon { Id = 2, Surname = "Doe", Forename = "Jane", Birthday = new DateTime(1990, 5, 10), Age = 29, Sport = Sport.Canoe, NationalityId = 1 },
                new Olympicon { Id = 3, Surname = "Cycl", Forename = "Er", Birthday = new DateTime(1996, 11, 10), Age = 23, Sport = Sport.Cycling, NationalityId = 2 },
                new Olympicon { Id = 4, Surname = "Fig", Forename = "Ther", Birthday = new DateTime(1995, 7, 30), Age = 24, Sport = Sport.Judo, NationalityId = 3 },
                new Olympicon { Id = 5, Surname = "Someone", Forename = "Else", Birthday = new DateTime(1990, 7, 30), Age = 29, Sport = Sport.Archery, NationalityId = 3 },
                new Olympicon { Id = 6, Surname = "Random", Forename = "Person", Birthday = new DateTime(1995, 7, 30), Age = 24, Sport = Sport.Rowing, NationalityId = 3 },
                new Olympicon { Id = 7, Surname = "Surname", Forename = "Forename", Birthday = new DateTime(1995, 7, 30), Age = 24, Sport = Sport.Judo, NationalityId = 4 }
            );
        }
    }
}
