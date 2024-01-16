using Sport_System.Domain.Entity;
using Sport_System.Application.DTOs.PlayerDTOs;
using Sport_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.RepositoryInterfaces
{
    public interface IPlayerRepository
    {
        Task<Player> AddPlayer(Player player);
        Task<Player> EditPlayer(Player player);
        Task<Player> DeletePlayer(Player player);
        Task<Player> GetPlayerById(int id);
        Task<List<Player>> GetAllPlayers();
        Task<List<Player>> GetAllPlayersByTeam(int id);
        Task<Player> GetPlayer(int id);
        Task<List<Player>> GetPlayersByUser(string id);
        Task<Player> GetPlayerByJerseyNumber(int jerseyNumber);
       
    }
}
