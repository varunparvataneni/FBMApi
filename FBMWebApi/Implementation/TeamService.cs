using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBMWebApi.Interfaces;
using FBMWebApi.Models;

namespace FBMWebApi.Implementation
{
    public class TeamService : ITeamService
    {

        private readonly Dictionary<int, TeamModel> _TeamContext;

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamService()
        {
            _TeamContext = new Dictionary<int, TeamModel>();
        }

        /// <summary>
        /// Get Teams
        /// </summary>
        /// <returns>List of Teams</returns>
        public Dictionary<int, TeamModel> GetTeams()
        {
            if (!_TeamContext.Any())
            {
                //Add one sample
                _TeamContext.Add(1,new TeamModel { TeamID =1,TeamName = "John", TeamLocation = "Centurion", StadiumID=1});
            }
            return _TeamContext;
        }

        /// <summary>
        /// Get specific Team details
        /// </summary>
        /// <param name="TeamID"></param>
        /// <returns>Book info</returns>
        public TeamModel GetTeamDetails(int TeamID)
        {
            return _TeamContext.FirstOrDefault(x => x.Key == TeamID).Value;
        }

        /// <summary>
        /// Add team
        /// </summary>
        /// <param name="Team"></param>
        public void AddTeam(TeamModel team)
        {
            team.TeamID = _TeamContext.Count + 1;
            _TeamContext.Add(team.TeamID, team);
        }

        /// <summary>
        /// Update Team
        /// </summary>
        /// <param name="Team"></param>
        public void UpdateTeamDetails(TeamModel team)
        {
            _TeamContext.Remove(team.TeamID);
            _TeamContext.Add(team.TeamID, team);
        }

        /// <summary>
        /// Delete Team
        /// </summary>
        /// <param name="TeamID"></param>
        public void DeleteTeam(int TeamID)
        {
            _TeamContext.Remove(TeamID);
        }
    }
}
