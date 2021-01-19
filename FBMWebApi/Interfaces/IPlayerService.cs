using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBMWebApi.Models;

namespace FBMWebApi.Interfaces
{
    public interface IPlayerService
    {
        Dictionary<int, PlayerModel> GetPlayersList();
        PlayerModel GetPlayerDetails(int PlayerID);
        void AddPlayer(PlayerModel player);
        void UpdatePlayerDetails(PlayerModel player);
        void DeletePlayer(int PlayerID);
    }
}
