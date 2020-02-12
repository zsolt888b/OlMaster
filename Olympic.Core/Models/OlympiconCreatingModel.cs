using Olympic.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Olympic.Core.Models
{
    public class OlympiconCreatingModel
    {
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Forename { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public Sport Sport { get; set; }
        [Required]
        public string Nationality { get; set; }
    }
}
