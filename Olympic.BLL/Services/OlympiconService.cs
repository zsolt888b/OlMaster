using Microsoft.EntityFrameworkCore;
using Olympic.Core.Models;
using Olympic.Core.Models.Enums;
using Olympic.Core.Services;
using Olympic.DAL.Database;
using Olympic.DAL.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympic.BLL.Services
{
    public class OlympiconService : IOlympiconService
    {
        private readonly OlympicDbContext _context;
        public OlympiconService(OlympicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OlympiconModel>> GetOlympicons()
        {
            var Olympicons = await _context.Olympicons.Include(x=>x.Nationality).ToListAsync();

            var returnModel = new List<OlympiconModel>();

            foreach (var item in Olympicons)
            {
                var addItem = new OlympiconModel
                {
                    Id = item.Id,
                    Forename = item.Forename,
                    Surname = item.Surname,
                    Nationality = item.Nationality.Country,
                    Sport = item.Sport
                };
                returnModel.Add(addItem);
            }

            return returnModel.OrderBy(x => x.Nationality);
        }

        public async Task<IEnumerable<OlympiconListModel>> GetOlympiconsByNationality()
        {
            var Olympicons = await _context.Olympicons.Include(x => x.Nationality).GroupBy(y => y.Nationality.Country).ToListAsync();

            var returnModel = new List<OlympiconListModel>();

            foreach (var group in Olympicons)
            {
                var add = new OlympiconListModel { Nationality = group.Key };
                foreach (var item in group.ToList())
                {
                    var addItem = new OlympiconModel
                    {
                        Id = item.Id,
                        Forename = item.Forename,
                        Surname = item.Surname,
                        Nationality = item.Nationality.Country,
                        Sport = item.Sport
                    };
                    add.Olympicons.Add(addItem);
                }
                returnModel.Add(add);
            }
            return returnModel;
        }

        public async Task<IEnumerable<OlympiconListModel>> Search(SearchModel model)
        {
            
            var olympicons = await _context.Olympicons.Include(x=>x.Nationality).ToListAsync();
            var returnModel = new List<OlympiconListModel>();

            if (model != null)
            {
                if (model.Age.HasValue)
                    olympicons = olympicons.Where(x => x.Age == model.Age).ToList();
                if (!string.IsNullOrEmpty(model.Name))
                    olympicons = olympicons.Where(x => (x.Surname + " " + x.Forename).Contains(model.Name)).ToList();
                if (model.Sport.HasValue)
                    olympicons = olympicons.Where(x => x.Sport == model.Sport).ToList();
            }

            var olympiconsbynations = olympicons.GroupBy(x => x.Nationality.Country);

            foreach (var group in olympiconsbynations)
            {
                var add = new OlympiconListModel { Nationality = group.Key };
                foreach (var item in group.ToList())
                {
                    var addItem = new OlympiconModel
                    {
                        Id = item.Id,
                        Forename = item.Forename,
                        Surname = item.Surname,
                        Nationality = item.Nationality.Country,
                        Sport = item.Sport
                    };
                    add.Olympicons.Add(addItem);
                }
                returnModel.Add(add);
            }

            return returnModel;
        }


        public async Task<OlympiconDetailedModel> GetOlympicon(int id)
        {
            var Olympicon = await _context.Olympicons.Include(x => x.Nationality).FirstOrDefaultAsync(y => y.Id == id);
            var latest = await _context.Medals.Where(x => x.OlympiconId == id).OrderBy(y => y.Place).FirstOrDefaultAsync();
            var returnModel = new OlympiconDetailedModel
            {
                Age = Olympicon.Age,
                Id = Olympicon.Id,
                Birthday = Olympicon.Birthday,
                Forename = Olympicon.Forename,
                Nationality = Olympicon.Nationality.Country,
                Surname = Olympicon.Surname,
                Sport = Olympicon.Sport
            };

            if (latest != null)
            {
                returnModel.Latestyear = latest.Year.ToString();
                returnModel.Latestplacing = latest.Place.ToString();
            }


            return returnModel;
        }

        public async Task<int> NewOlympicon(OlympiconCreatingModel model)
        {

            var nat = await _context.Nationalities.Where(x=>x.Id==model.Nationality).FirstOrDefaultAsync();

            var newOlympicon = new Olympicon
            {
                Forename = model.Forename,
                Surname = model.Surname,
                Age = DateTime.Now.Year - model.Birthday.Year,
                Birthday = model.Birthday,
                Nationality = nat,
                Sport = model.Sport
            };

            _context.Olympicons.Add(newOlympicon);

            await _context.SaveChangesAsync();

            return newOlympicon.Id;
        }

        public async Task Edit(int id, OlympiconCreatingModel model)
        {

            var editedOlympicon = await _context.Olympicons.SingleOrDefaultAsync(x => x.Id == id);
            if (editedOlympicon == null)
                return;

            var nat = await _context.Nationalities.Where(x => x.Id == model.Nationality).FirstOrDefaultAsync();

            editedOlympicon.Birthday = model.Birthday;
            editedOlympicon.Forename = model.Forename;
            editedOlympicon.Nationality = nat;
            editedOlympicon.Sport = model.Sport;
            editedOlympicon.Surname = model.Surname;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NationalityModel>> GetNations()
        {
            var nations = await _context.Nationalities.ToListAsync();

            var returnModel = new List<NationalityModel>();

            foreach(var nat in nations)
            {
                returnModel.Add(new NationalityModel { Id=nat.Id, Country=nat.Country});
            }

            return returnModel;
        }
    }
}
