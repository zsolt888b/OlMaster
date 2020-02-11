using Olympic.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympic.Core.Models
{
    public class SearchModel
    {
        public string Name { get; set; }
        public Sport? Sport { get; set; }
        public int? Age { get; set; }
    }
}
