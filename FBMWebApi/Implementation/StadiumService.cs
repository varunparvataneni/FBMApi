using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBMWebApi.Models;
using FBMWebApi.Interfaces;

namespace FBMWebApi.Implementation
{
    public class StadiumService : IStadiumService
    {
        private readonly Dictionary<int, StadiumModel> _StadiumContext;

        /// <summary>
        /// Constructor
        /// </summary>
        public StadiumService()
        {
            _StadiumContext = new Dictionary<int, StadiumModel>();
        }

        /// <summary>
        /// Get Stadiums
        /// </summary>
        /// <returns>List of Stadiums</returns>
        public Dictionary<int, StadiumModel> GetStadiumsList()
        {
            if (!_StadiumContext.Any())
            {
                //Add one sample
                _StadiumContext.Add(1, new StadiumModel { StadiumID = 1, StadiumName = "Centurion"});
            }
            return _StadiumContext;
        }

        /// <summary>
        /// Get specific Stadium details
        /// </summary>
        /// <param name="StadiumID"></param>
        /// <returns>Book info</returns>
        public StadiumModel GetStadiumDetails(int StadiumID)
        {
            return _StadiumContext.FirstOrDefault(x => x.Key == StadiumID).Value;
        }

        /// <summary>
        /// Add Stadium
        /// </summary>
        /// <param name="Stadium"></param>
        public void AddStadium(StadiumModel Stadium)
        {
            Stadium.StadiumID = _StadiumContext.Count + 1;
            _StadiumContext.Add(Stadium.StadiumID, Stadium);
        }

        /// <summary>
        /// Update Stadium
        /// </summary>
        /// <param name="Stadium"></param>
        public void UpdateStadiumDetails(StadiumModel Stadium)
        {
            _StadiumContext.Remove(Stadium.StadiumID);
            _StadiumContext.Add(Stadium.StadiumID, Stadium);
        }

        /// <summary>
        /// Delete Stadium
        /// </summary>
        /// <param name="StadiumID"></param>
        public void DeleteStadium(int StadiumID)
        {
            _StadiumContext.Remove(StadiumID);
        }

    }
}
