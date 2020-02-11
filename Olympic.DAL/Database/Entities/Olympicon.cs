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
                new Olympicon { Id = 1, Surname = "Doe", Forename = "John", Birthday= new DateTime(1995, 6, 30), Age= (DateTime.Now.Year-(new DateTime(1995,6,30)).Year) ,Sport=Sport.Archery, NationalityId=1},
                new Olympicon { Id = 2, Surname = "Doe", Forename = "Jane", Birthday = new DateTime(1990, 5, 10), Age = (DateTime.Now.Year - (new DateTime(1990, 5, 10)).Year), Sport = Sport.Canoe, NationalityId=1},
                new Olympicon { Id = 3, Surname = "Cycl", Forename = "Er", Birthday = new DateTime(1996, 11, 10), Age = (DateTime.Now.Year - (new DateTime(1995, 11, 10)).Year), Sport = Sport.Cycling, NationalityId=2},
                new Olympicon { Id = 4, Surname = "Fig", Forename = "Ther", Birthday = new DateTime(1995, 7, 30), Age = (DateTime.Now.Year - (new DateTime(1995, 7, 30)).Year), Sport = Sport.Judo, NationalityId=3}
            );
        }
    }
}
