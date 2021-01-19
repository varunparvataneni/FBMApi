using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using FBMWebApi.Models;
using FBMWebApi.Interfaces;

namespace FBMWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly ITeamService _TeamServices;

        public TeamController(ITeamService TeamServices)
        {
            _TeamServices = TeamServices;
        }

        /// <summary>
        /// Action to Get All TeamsList
        /// </summary>
        [HttpGet]
        public ActionResult Get()
        {
            List<TeamModel> result = new List<TeamModel>();
            var Teams = _TeamServices.GetTeams();
            foreach (var item in Teams)
            {
                result.Add(item.Value);
            }
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Action to Get specific Team Details with ID
        /// </summary>
        /// <param name="id"></param>       
        [HttpGet("{TeamID}", Name = "GetTeam")]
        public IActionResult Get(int TeamID)
        {
            var GetTeam = _TeamServices.GetTeamDetails(TeamID);
            return new OkObjectResult(GetTeam);
        }

        /// <summary>
        /// Action to Load the Team
        /// </summary>
        /// <param name="Customer"></param>      
        [HttpPost]
        public IActionResult Post(TeamModel Team)
        {
            bool Teamexist = _TeamServices.GetTeams().Any(x => x.Value.TeamName == Team.TeamName);
            if (!Teamexist)
            {
                using (var scope = new TransactionScope())
                {
                    _TeamServices.AddTeam(Team);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = Team.TeamID }, Team);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Team already exist" });
        }

        /// <summary>
        /// Action to Update Team Details
        /// </summary>
        /// <param name="Customer"></param>      
        [HttpPut]
        public IActionResult Put(int TeamID,TeamModel Team)
        {
            TeamModel TeamDetails = _TeamServices.GetTeamDetails(TeamID);
            if (TeamDetails != null)
            {
                using (var scope = new TransactionScope())
                {
                     Team.TeamID = TeamID;
                    _TeamServices.UpdateTeamDetails(Team);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Action to Delete Team
        /// </summary>
        /// <param name="id"></param>      
        [HttpDelete("{TeamID}")]
        public IActionResult Delete(int TeamID)
        {
            TeamModel TeamDetails = _TeamServices.GetTeamDetails(TeamID);
            if (TeamDetails != null)
            {
                _TeamServices.DeleteTeam(TeamID);
                return new OkResult();
            }
            return NotFound();
        }
    }
}