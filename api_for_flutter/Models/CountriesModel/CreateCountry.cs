﻿namespace api_for_flutter.Models.CountriesModel
{
    public class CreateCountry
    {
        public string Title { get; set; }
        public string? Flag { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }
        public int Active { get; set; }
    }
}
