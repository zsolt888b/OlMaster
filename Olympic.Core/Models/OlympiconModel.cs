using Olympic.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympic.Core.Models
{
    public class OlympiconModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public Sport Sport { get; set; }
        public string Nationality { get; set; }
    }
}
