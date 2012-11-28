
// define metadata class for validators

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MiniProject10.Models;
using System.Data.Objects;
using System.Text;
using Geo1;

namespace MiniProject10.Models
{
    public class CitySelection
    {
        public static List<String> Countries
        {
            get
            {
                MiniProjectEntities cntlst = new MiniProjectEntities();

                var CountryLst = new List<String>();
                var ListQry = cntlst.CityLocations.OrderBy(CityLocation => CityLocation.Country)
                               .Select(CityLocation => CityLocation.Country).Distinct();
                foreach (var name in ListQry)
                {
                    CountryLst.Add(name);
                }

                return CountryLst;
            }
        }

        public static List<String> Cities2(string countrytemp)
        {
            MiniProjectEntities cntlst2 = new MiniProjectEntities();
            var CityLst = new List<String>();
            var ListQry = cntlst2.CityLocations.Where(CityLocation => CityLocation.Country == countrytemp)
                            .OrderBy(CityLocation => CityLocation.City)
                           .Select(CityLocation => CityLocation.City);
            foreach (var name in ListQry)
            {
                CityLst.Add(name);
            }
            return CityLst;
        }

        public static double CalculateDist(string country1, string city1, string country2, string city2)
        {
            MiniProjectEntities cntlst2 = new MiniProjectEntities();
            var ListQry1 = cntlst2.CityLocations.Where(CityLocation => CityLocation.Country == country1 
                            && CityLocation.City == city1)
                           .Select(CityLocation => CityLocation.Latitude).First();
            var ListQry2 = cntlst2.CityLocations.Where(CityLocation => CityLocation.Country == country1
                            && CityLocation.City == city1)
                           .Select(CityLocation => CityLocation.Longitude).First();
            var ListQry3 = cntlst2.CityLocations.Where(CityLocation => CityLocation.Country == country2
                            && CityLocation.City == city2)
                           .Select(CityLocation => CityLocation.Latitude).First();
            var ListQry4 = cntlst2.CityLocations.Where(CityLocation => CityLocation.Country == country2
                            && CityLocation.City == city2)
                           .Select(CityLocation => CityLocation.Longitude).First();
            double result = GeoCodeCalc.CalcDistance(ListQry1, ListQry2, ListQry3, ListQry4);
            return result;
        }
    }

    [MetadataType(typeof(CityMetadata))]
    public partial class CityLocation
    {
        // ...
    }

    // metadata class for CityLocation (partial definitions here and in Model1.Designer.cs)
    public class CityMetadata
    {
        [Required]
        public String Country { get; set; }

        [Required]
        public String City { get; set; }

        [Required]
        [Range(-180, 180, ErrorMessage = "Latitude must be in range -180..180!")]
        public float Latitude { get; set; }

        [Required]
        [Range(-180, 180, ErrorMessage = "Longitude must be in range -180..180!")]
        public float Longitude { get; set; }
    }
}