using System;
using System.Collections.Generic;
using System.Text;

namespace Olympic.Core.Models
{
    public class OlympiconListModel
    {
        public string Nationality { get; set; }
        public ICollection<OlympiconModel> Olympicons { get; set; }

        public OlympiconListModel()
        {
            Olympicons = new HashSet<OlympiconModel>();
        }
    }
}
