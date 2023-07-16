﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models
{
    public class Cities
    {
        [Key] 
        public int IdCity { get; set; }
        public string Title { get; set; }
        public int IdCountry { get; set; }
        [ForeignKey("IdCountry")]
        public Countries Countries { get; set; }
    }
}
