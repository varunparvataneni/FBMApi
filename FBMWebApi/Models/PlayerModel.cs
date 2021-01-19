using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FBMWebApi.Models
{
    public class PlayerModel
    {
        [JsonIgnore]
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string SurName { get; set; }
        public string Height { get; set; }
        public int TeamID { get; set; }
    }
}
