using System.Numerics;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace BoxBack.Domain.Models.Services
{
    public class GeoNamesEstadosModel
    {
        public int TotalResultsCount { get; set; }

        public ICollection<GeoName> Geonames { get; set; }
    }

    public class GeoName
    {
        public string AdminCode1 { get; set; }
        public string Lng { get; set; }
        public Int64 GeonameId { get; set; }
        public string ToponymName { get; set; }
        public string CountryId { get; set; }
        public string Fcl { get; set; }
        public BigInteger Population { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string FclName { get; set; }
        public AdminCodes1 AdminCodes1 { get; set; }
        public string CountryName { get; set; }
        public string FcodeName { get; set; }
        public string AdminName1 { get; set; }
        public string Lat { get; set; }
        public string Fcode { get; set; }
        public int? NumberOfChildren { get; set; }
    }

    public class AdminCodes1
    {
        public string ISO3166_2 { get; set; }
    }
}