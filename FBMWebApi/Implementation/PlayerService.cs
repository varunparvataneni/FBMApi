using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBMWebApi.Interfaces;
using FBMWebApi.Models;

namespace FBMWebApi.Implementation
{
    public class PlayerService : IPlayerService
    {

        private readonly Dictionary<int, PlayerModel> _PlayerContext;

        /// <summary>
        /// Constructor
        /// </summary>
        public PlayerService()
        {
            _PlayerContext = new Dictionary<int, PlayerModel>();
        }

        /// <summary>
        /// Get Players
        /// </summary>
        /// <returns>List of Players</returns>
        public Dictionary<int, PlayerModel> GetPlayersList()
        {
            if (!_PlayerContext.Any())
            {
                //Add one sample
                _PlayerContext.Add(1,new PlayerModel {PlayerID=1,PlayerName = "John", SurName = "van duk", TeamID =1});
            }
            return _PlayerContext;
        }

        /// <summary>
        /// Get specific Player details
        /// </summary>
        /// <param name="PlayerID"></param>
        /// <returns>Book info</returns>
        public PlayerModel GetPlayerDetails(int PlayerID)
        {
            return _PlayerContext.FirstOrDefault(x => x.Key == PlayerID).Value;
        }

        /// <summary>
        /// Add Player
        /// </summary>
        /// <param name="Player"></param>
        public void AddPlayer(PlayerModel player)
        {
            player.PlayerID = _PlayerContext.Count + 1;
            _PlayerContext.Add(player.PlayerID, player);
        }

        /// <summary>
        /// Update Player
        /// </summary>
        /// <param name="Player"></param>
        public void UpdatePlayerDetails(PlayerModel player)
        {
            _PlayerContext.Remove(player.PlayerID);
            _PlayerContext.Add(player.PlayerID, player);
        }

        /// <summary>
        /// Delete Player
        /// </summary>
        /// <param name="PlayerID"></param>
        public void DeletePlayer(int PlayerID)
        {
            _PlayerContext.Remove(PlayerID);
        }
    }
}
