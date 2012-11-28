using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GeodeticDistance.Models;

namespace CityDist
{
    //public class CityDistService : IDistService
    public class Service1 : IDistService
    {

        public double GetDist(string city1, string city2) 
        {
            try
            {
                double result = CitySelection.CalculateDist(city1, city2);
                return (result);
            }

            catch
            {
                throw new FaultException("City details not in database");
            }
        }
    }
}
    
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             


   

