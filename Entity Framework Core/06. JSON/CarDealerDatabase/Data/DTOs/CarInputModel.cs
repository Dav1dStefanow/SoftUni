using CarDealerDatabase.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerDatabase.Data.DTOs
{
    public class CarInputModel
    {
        [JsonProperty("make")]
        public string Make { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("traveledDistance")]
        public int TraveledDistance { get; set; }
        [JsonProperty("partsId")]
        public ICollection<int> PartsId { get; set; }
    }
}
