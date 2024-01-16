using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sport_.Application.DTOs.PlayerDTOs;
using Sport_System.Application.DTOs.PlayerDTOs;
using Sport_System.Application.RepositoryInterfaces;
using Sport_System.Application.Responses;
using Sport_System.Application.Services.Interfaces;
using Sport_System.Application.Utility.Interfaces;
using Sport_System.Domain.Entity;
using Sport_System.Domain.Models;
using Sport_System.Application.DTOs.PlayerDTOs;
using Sport_System.Application.RepositoryInterfaces;
using Sport_System.Application.Responses;
using Sport_System.Application.Services.Interfaces;
using Sport_System.Application.Utility;
using Sport_System.Domain.Entity;
using Sport_System.Domain.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SportsManagementSystem.Application.RepositoryInterfaces;

namespace SportsManagementSystem.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayerService(IPlayerRepository playerRepository, ITeamRepository teamRepository, IMapper mapper, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task<ApiResponse> AddPlayer(AddPlayerDTO dto)
        {
            if (dto != null)
            {
                var existingJerseyNumber = await _playerRepository.GetPlayerByJerseyNumber(dto.JerseyNumber);

                if (existingJerseyNumber != null)
                    return new ApiResponse(400, "A player with the same Jersey Number already exists");

                if (string.IsNullOrEmpty(dto.Position))
                    return new ApiResponse(400, "Invalid player position");

                var player = _mapper.Map<Player>(dto);
                player.Registered_At = DateTime.UtcNow;

                await _playerRepository.AddPlayer(player);

                return new ApiResponse(200, "Player got added successfully");
            }
            return new ApiResponse(400, "The player coulnd't be added successfully");
        }

        public async Task<ApiResponse> EditPlayer(EditPlayerDTO dto)
        {
            var player = await _playerRepository.GetPlayer(dto.PlayerId);
            var team = await _teamRepository.GetTeamById((int)player.TeamId);

            if (player != null)
            {
                var existingJerseyNumber = await _playerRepository.GetPlayerByJerseyNumber(dto.JerseyNumber);
                if (existingJerseyNumber != null && player.JerseyNumber != existingJerseyNumber.JerseyNumber && team.Players.Any(player => player.JerseyNumber == dto.JerseyNumber))
                    return new ApiResponse(400, "A player with the same Jersey Number already exists");

                if (player.JerseyNumber == dto.JerseyNumber &&
                    player.Position == dto.Position)
                { return new ApiResponse(400, "No changes were made."); }


                if (string.IsNullOrEmpty(dto.Position))
                    return new ApiResponse(400, "Invalid player position");

                player.Position = dto.Position;
                player.JerseyNumber = dto.JerseyNumber;

                await _playerRepository.EditPlayer(player);
                return new ApiResponse(200, "Player updated successfully");
            }
            return new ApiResponse(400, "Player couldn't be edited successfully.");
        }

        public async Task<ApiResponse> DeletePlayer(int id)
        {
            var player = await _playerRepository.GetPlayer(id);
            if (player != null)
            {
                await _playerRepository.DeletePlayer(player);
                return new ApiResponse(200, "Player got deleted successfully");
            }
            return new ApiResponse(400, "Player couldn't be deleted successfully.");
        }

        public async Task<GetPlayerDTO> GetPlayerById(int id)
        {
            var player = await _playerRepository.GetPlayer(id);
            var playerDTO = _mapper.Map<GetPlayerDTO>(player);
            return playerDTO;
        }

        public async Task<List<GetPlayerDTO>> GetAllPlayers()
        {
            var players = await _playerRepository.GetAllPlayers();
            var playerList = _mapper.Map<List<GetPlayerDTO>>(players);
            return playerList;
        }

        public async Task<List<GetPlayerDTO>> GetPlayersByUser(string id)
        {
            var player = await _playerRepository.GetPlayersByUser(id);
            var playersDTO = _mapper.Map<List<GetPlayerDTO>>(player);
            return playersDTO;
        }

        public async Task<List<GetPlayerDTO>> GetAllPlayersByTeam(int id)
        {
            var players = await _playerRepository.GetAllPlayersByTeam(id);
            var playerList = _mapper.Map<List<GetPlayerDTO>>(players);
            return playerList;
        }
       
        

       

       

       
    }
}
