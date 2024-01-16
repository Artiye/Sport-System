using Microsoft.EntityFrameworkCore;
using Sport_System.Models;
using Sport_System.Repositories.Interfaces;
using Sports_System.Data;
using static Sport_System.Repositories.SportRepository;

namespace Sport_System.Repositories
{
    
  
        public class SportRepository : ISportRepository
        {
            private readonly ApplicationDbContext _context;
            public SportRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Sport> AddSport(Sport sport)
            {
                await _context.Sports.AddAsync(sport);
                await _context.SaveChangesAsync();
                return sport;
            }
            public async Task<Sport> DeleteSport(Sport sport)
            {
                _context.Sports.Remove(sport);
                await _context.SaveChangesAsync();
                return sport;
            }

            public async Task<Sport> EditSport(Sport sport)
            {
                _context.Sports.Update(sport);
                await _context.SaveChangesAsync();
                return sport;
            }

            public async Task<Sport> GetSportById(int id)
            {
                var sport = await _context.Sports.FirstOrDefaultAsync(s => s.SportId == id);
                return sport;
            }

            public async Task<List<Sport>> GetAllSports()
            {
                List<Sport> sports = await _context.Sports.ToListAsync();
                return sports;
            }

            public async Task<Sport> GetSport(int id)
            {
                var sport = await _context.Sports.FirstOrDefaultAsync(s => s.SportId == id);
                return sport;
            }

            public async Task<Sport> GetSportByName(string name)
            {
                var sport = await _context.Sports.FirstOrDefaultAsync(s => s.Name == name);
                return sport;
            }
        }
    }

