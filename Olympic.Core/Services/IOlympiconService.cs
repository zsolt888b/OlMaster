using Olympic.Core.Models;
using Olympic.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Olympic.Core.Services
{
    public interface IOlympiconService
    {
        Task<IEnumerable<OlympiconModel>> GetOlympicons();
        Task<OlympiconDetailedModel> GetOlympicon(int id);
        Task<int> NewOlympicon(OlympiconCreatingModel model);
        Task Edit(int id, OlympiconCreatingModel model);
        Task<IEnumerable<OlympiconListModel>> Search(SearchModel model);
        Task<IEnumerable<OlympiconListModel>> GetOlympiconsByNationality();
        Task<IEnumerable<NationalityModel>> GetNations();
    }
}
