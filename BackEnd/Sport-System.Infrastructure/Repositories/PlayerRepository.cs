using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sport_System.Domain.Entity;
using Sports_System.Infrastructure.Data;
using Sport_System.Application.DTOs.PlayerDTOs;
using Sport_System.Application.RepositoryInterfaces;
using Sport_System.Domain.Entity;
using Sport_System.Domain.StaticData;
using Sport_System.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Infrastructure.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PlayerRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Player> AddPlayer(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> DeletePlayer(Player player)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> EditPlayer(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == id);
            return player;
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            List<Player> players = await _context.Players.ToListAsync();
            return players;
        }

        public async Task<Player> GetPlayer(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == id);
            return player;
        }

        public async Task<List<Player>> GetPlayersByUser(string id)
        {
            var players = await _context.Players.Where(p => p.ApplicationUserId == id).ToListAsync();
            return players;
        }

        public async Task<Player> GetPlayerByJerseyNumber(int jerseyNumber)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.JerseyNumber == jerseyNumber);
            return player;
        }

        public async Task<List<Player>> GetAllPlayersByTeam(int id)
        {
            List<Player> players = await _context.Players.Where(p => p.TeamId == id).ToListAsync();
            return players;
        }
        
    }
}
