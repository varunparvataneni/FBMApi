using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBMWebApi.Models;

namespace FBMWebApi.Interfaces
{
    public interface IStadiumService
    {
        Dictionary<int, StadiumModel> GetStadiumsList();
        StadiumModel GetStadiumDetails(int StadiumID);
        void AddStadium(StadiumModel Stadium);
        void UpdateStadiumDetails(StadiumModel Stadium);
        void DeleteStadium(int StadiumID);
    }
}
