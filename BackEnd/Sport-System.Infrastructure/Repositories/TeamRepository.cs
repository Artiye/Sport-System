using Microsoft.EntityFrameworkCore;
using Sport_System.Domain.Entity;
using Sports_System.Infrastructure.Data;
using Sport_System.Application.RepositoryInterfaces;
using Sport_System.Domain.StaticData;
using Sport_System.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SportsManagementSystem.Application.RepositoryInterfaces;

namespace Sport_System.Infrastructure.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Team> AddTeam(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> DeleteTeam(Team team)
        {
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> EditTeam(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> GetTeamById(int id)
        {
            var team = await _context.Teams
                .Include(t => t.Players)
                .Include(t => t.Tournaments)
                .FirstOrDefaultAsync(p => p.TeamId == id);
            return team;
        }

        public async Task<List<Team>> GetTeamsByUserId(string userId)
        {
            var teams = await _context.Teams
                .Include(t => t.Players)
                .Include(t => t.Tournaments)
                .Where(t => t.TeamOwnerId == userId)
                .ToListAsync();
            return teams;
        }

        public async Task<List<Team>> GetTeamsUserPlaysFor(string userId)
        {
            var teams = await _context.Teams
                .Where(t => t.Players.Any(player => player.ApplicationUserId == userId))
                .ToListAsync();
            return teams;
        }

        public async Task<List<Team>> GetAllTeams()
        {
            List<Team> teams = await _context.Teams
                .Include(t => t.Players)
                .Include(t => t.Tournaments)
                .ToListAsync();
            return teams;
        }

        public async Task<Team> GetTeamByName(string name)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Name == name);
            return team;
        }

        public async Task<List<Team>> GetTeamsByPlayer(int playerId)
        {
            var teamsWithPlayer = await _context.Teams
                .Where(team => team.Players != null && team.Players.Any(player => player.PlayerId == playerId))
                .ToListAsync();
            return teamsWithPlayer;
        }

        public async Task<List<Team>> SearchTeams(string searchTerm)
        {
            return await _context.Teams
           .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    p.ShortName.ToLower().Contains(searchTerm.ToLower()) ||
                    p.Location.ToLower().Contains(searchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(searchTerm.ToLower()) ||
                    p.SportName.ToLower().Contains(searchTerm) ||
                    p.YearFounded.ToString().Contains(searchTerm))
                    .ToListAsync();
        }



    }
}

