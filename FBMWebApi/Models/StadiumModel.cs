using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FBMWebApi.Models
{
    public class StadiumModel
    {
        [JsonIgnore]
        public int StadiumID { get; set; }
        public string StadiumName { get; set; }
    }
}
