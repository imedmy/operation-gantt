
// define metadata class for validators

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
// using MiniProject10.Models;
using System.Data.Objects;
using System.Text;
using Geo1;
using CityDist;

namespace GeodeticDistance.Models
{
    public class CitySelection
    {
        public static double CalculateDist(string city1, string city2)
        {
            MiniProjectEntities2 cntlst2 = new MiniProjectEntities2();
            var ListQry1 = cntlst2.CityLocations.Where(CityLocation => CityLocation.City == city1)
                           .Select(CityLocation => CityLocation.Latitude).First();
            var ListQry2 = cntlst2.CityLocations.Where(CityLocation => CityLocation.City == city1)
                           .Select(CityLocation => CityLocation.Longitude).First();
            var ListQry3 = cntlst2.CityLocations.Where(CityLocation => CityLocation.City == city2)
                           .Select(CityLocation => CityLocation.Latitude).First();
            var ListQry4 = cntlst2.CityLocations.Where(CityLocation => CityLocation.City == city2)
                           .Select(CityLocation => CityLocation.Longitude).First();
            double result = GeoCodeCalc.CalcDistance(ListQry1, ListQry2, ListQry3, ListQry4);
            return result;
        }
    }

    [MetadataType(typeof(CityData))]
    public partial class CityLocation
    {
        // ...
    }

    // metadata class for Student (partial definitions here and in StudentModel.Designer.cs
    public class CityData
    {
        [Required]
        public String Country { get; set; }

        [Required]
        public String City { get; set; }

        [Required]
        public float Latitude { get; set; }

        [Required]
        public float Longitude { get; set; }
    }
}