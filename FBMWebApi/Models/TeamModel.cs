using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FBMWebApi.Models
{
    public class TeamModel
    {
        [JsonIgnore]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string TeamLocation { get; set; }
        public int StadiumID { get; set; }

    }
}
