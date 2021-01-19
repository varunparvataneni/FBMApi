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
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerService _PlayerServices;

        public PlayerController(IPlayerService PlayerServices)
        {
            _PlayerServices = PlayerServices;
        }

        /// <summary>
        /// Action to Get All PlayersList
        /// </summary>
        [HttpGet]
        public ActionResult Get()
        {
            List<PlayerModel> result = new List<PlayerModel>();
            var Players = _PlayerServices.GetPlayersList();
            foreach (var item in Players)
            {
                result.Add(item.Value);
            }
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Action to Get specific Player Details with ID
        /// </summary>
        /// <param name="id"></param>       
        [HttpGet("{PlayerID}", Name = "GetPlayer")]
        public IActionResult Get(int PlayerID)
        {
            var GetPlayer = _PlayerServices.GetPlayerDetails(PlayerID);
            return new OkObjectResult(GetPlayer);
        }

        /// <summary>
        /// Action to Load the Player
        /// </summary>
        /// <param name="Customer"></param>      
        [HttpPost]
        public IActionResult Post(PlayerModel Player)
        {
            bool Playerexist = _PlayerServices.GetPlayersList().Any(x => x.Value.PlayerName == Player.PlayerName);
            if (!Playerexist)
            {
                using (var scope = new TransactionScope())
                {
                    _PlayerServices.AddPlayer(Player);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = Player.PlayerID }, Player);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Player already exist" });
        }

        /// <summary>
        /// Action to Update Player Details
        /// </summary>
        /// <param name="Customer"></param>      
        [HttpPut]
        public IActionResult Put(int PlayerID ,PlayerModel Player)
        {
            PlayerModel PlayerDetails = _PlayerServices.GetPlayerDetails(PlayerID);
            if (PlayerDetails != null)
            {
                using (var scope = new TransactionScope())
                {
                     Player.PlayerID = PlayerID;
                    _PlayerServices.UpdatePlayerDetails(Player);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Action to Delete Player
        /// </summary>
        /// <param name="id"></param>      
        [HttpDelete("{PlayerID}")]
        public IActionResult Delete(int PlayerID)
        {
            PlayerModel PlayerDetails = _PlayerServices.GetPlayerDetails(PlayerID);
            if (PlayerDetails != null)
            {
                _PlayerServices.DeletePlayer(PlayerID);
                return new OkResult();
            }
            return NotFound();
        }
    }
}