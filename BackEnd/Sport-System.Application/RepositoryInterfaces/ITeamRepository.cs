using Microsoft.EntityFrameworkCore;
using Sport_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SportsManagementSystem.Application.RepositoryInterfaces
{
    public interface ITeamRepository
    {
        Task<Team> AddTeam(Team team);
        Task<Team> EditTeam(Team team);
        Task<Team> DeleteTeam(Team team);
        Task<Team> GetTeamById(int id);
        Task<List<Team>> GetTeamsByUserId(string userId);
        Task<List<Team>> GetTeamsUserPlaysFor(string userId);
        Task<List<Team>> GetAllTeams();
        Task<Team> GetTeamByName(string name);
        Task<List<Team>> GetTeamsByPlayer(int playerId);
        Task<List<Team>> SearchTeams(string searchTerm);
    }
}
