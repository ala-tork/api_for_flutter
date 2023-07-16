﻿using System.ComponentModel.DataAnnotations;

namespace api_for_flutter.Models.CategoryModels
{
    public class Categories
    {
        [Key]
        public int IdCateg { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int? idparent { get; set; }
        public int Active { get; set; }
        public List<Categories> Children { get; set; }
    }

}
