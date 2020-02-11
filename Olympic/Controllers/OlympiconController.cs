using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Olympic.Core.Models;
using Olympic.Core.Models.Enums;
using Olympic.Core.Services;

namespace Olympic.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/olympicons")]
    [ApiController]
    public class OlympiconController : Controller
    {
        public IOlympiconService OlympiconService { get; set; }

        public OlympiconController(IOlympiconService olympiconService)
        {
            OlympiconService = olympiconService;
        }

        [HttpGet]
        public async Task<IEnumerable<OlympiconModel>> GetOlympicons()
            => await OlympiconService.GetOlympicons();

        [HttpGet("nations")]
        public async Task<IEnumerable<OlympiconListModel>> GetOlympiconsByNationality()
            => await OlympiconService.GetOlympiconsByNationality();

        [HttpGet("search")]
        public async Task<IEnumerable<OlympiconListModel>> Search([FromQuery]SearchModel model)
            => await OlympiconService.Search(model);
        [HttpGet("search2")]
        public async Task<IEnumerable<OlympiconListModel>> Search2([FromQuery(Name = "age")]int? age, [FromQuery(Name = "name")]string name, [FromQuery(Name = "sport")]Sport? sport)
            => await OlympiconService.Search2(age,name,sport);

        [HttpGet("{id}")]
        public async Task<OlympiconDetailedModel> GetOlympicon([FromRoute]int id)
            => await OlympiconService.GetOlympicon(id);

        [HttpPost]
        public async Task<int> NewOlympicon([FromBody]OlympiconCreatingModel model)
            => await OlympiconService.NewOlympicon(model);

        [HttpPut("{id}")]
        public async Task Edit([FromRoute]int id, [FromBody]OlympiconCreatingModel model)
            => await OlympiconService.Edit(id, model);

        [HttpGet("nation")]
        public async Task<IEnumerable<NationalityModel>> GetNationalities()
            => await OlympiconService.GetNations();
    }
}