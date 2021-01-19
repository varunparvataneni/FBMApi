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
    public class StadiumController : ControllerBase
    {

        private readonly IStadiumService _StadiumServices;

        public StadiumController(IStadiumService StadiumServices)
        {
            _StadiumServices = StadiumServices;
        }

        /// <summary>
        /// Action to Get All StadiumsList
        /// </summary>
        [HttpGet]
        public ActionResult Get()
        {
            List<StadiumModel> result = new List<StadiumModel>();
            var Stadiums = _StadiumServices.GetStadiumsList();
            foreach (var item in Stadiums)
            {
                result.Add(item.Value);
            }
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Action to Get specific Stadium Details with ID
        /// </summary>
        /// <param name="id"></param>       
        [HttpGet("{StadiumID}", Name = "GetStadium")]
        public IActionResult Get(int StadiumID)
        {
            var GetStadium = _StadiumServices.GetStadiumDetails(StadiumID);
            return new OkObjectResult(GetStadium);
        }

        /// <summary>
        /// Action to Load the Stadium
        /// </summary>
        /// <param name="Customer"></param>      
        [HttpPost]
        public IActionResult Post(StadiumModel Stadium)
        {
            bool Stadiumexist = _StadiumServices.GetStadiumsList().Any(x=>x.Value.StadiumName == Stadium.StadiumName);
            if (!Stadiumexist)
            {
                using (var scope = new TransactionScope())
                {
                    _StadiumServices.AddStadium(Stadium);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = Stadium.StadiumID }, Stadium);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Stadium already exist" });
        }

        /// <summary>
        /// Action to Update Stadium Details
        /// </summary>
        /// <param name="Customer"></param>      
        [HttpPut]
        public IActionResult Put(int StadiumID, StadiumModel Stadium)
        {
            StadiumModel StadiumDetails = _StadiumServices.GetStadiumDetails(StadiumID);
            if (StadiumDetails != null)
            {
                using (var scope = new TransactionScope())
                {
                    Stadium.StadiumID = StadiumID;
                    _StadiumServices.UpdateStadiumDetails(Stadium);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Action to Delete Stadium
        /// </summary>
        /// <param name="id"></param>      
        [HttpDelete("{StadiumID}")]
        public IActionResult Delete(int StadiumID)
        {
            StadiumModel StadiumDetails = _StadiumServices.GetStadiumDetails(StadiumID);
            if (StadiumDetails != null)
            {
                _StadiumServices.DeleteStadium(StadiumID);
                return new OkResult();
            }
            return NotFound();
        }
    }
}