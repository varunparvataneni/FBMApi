using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBMWebApi.Models;

namespace FBMWebApi.Interfaces
{
    public interface ITeamService
    {
        Dictionary<int, TeamModel> GetTeams();
        TeamModel GetTeamDetails(int TeamID);
        void AddTeam(TeamModel team);
        void UpdateTeamDetails(TeamModel team);
        void DeleteTeam(int TeamID);
    }
}
