using Microsoft.EntityFrameworkCore;
using Sport_System.Application.RepositoryInterfaces;
using Sport_System.Domain.Models;
using Sports_System.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Infrastructure.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly ApplicationDbContext _context;
        public TournamentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tournament> AddTournament(Tournament tournament)
        {
            await _context.Tournaments.AddAsync(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }

        public async Task<Tournament> DeleteTournament(Tournament tournament)
        {
            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }

        public async Task<Tournament> EditTournament(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }

        public async Task<List<Tournament>> GetAllTournaments()
        {
            List<Tournament> tournaments = await _context.Tournaments
                .Include(t => t.Teams)
                .ToListAsync();
            return tournaments;
        }

        public async Task<Tournament> GetTournamentById(int id)
        {
            var tournament = await _context.Tournaments
                 .Include(t => t.Teams)
                 .FirstOrDefaultAsync(p => p.TournamentId == id);
            return tournament;
        }

        public async Task<List<Tournament>> GetTournamentsByUserId(string userId)
        {
            var tournaments = await _context.Tournaments
                .Include(t => t.Teams)
                .Where(t => t.TournamentAdministratorId == userId)
                .ToListAsync();
            return tournaments;
        }

        public async Task<Tournament> GetTournamentByName(string name)
        {
            var tournament = await _context.Tournaments
                 .Include(t => t.Teams)
                 .FirstOrDefaultAsync(p => p.Name == name);
            return tournament;
        }
        public async Task<List<Tournament>> SearchTournaments(string searchTerm)
        {
            return await _context.Tournaments
           .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(searchTerm.ToLower()) ||
                    p.SportName.ToLower().Contains(searchTerm))
                    .ToListAsync();
        }
    }
}
