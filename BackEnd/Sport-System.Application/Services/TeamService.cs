using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sport_System.Application.DTOs.TeamDTOs;
using Sport_System.Application.RepositoryInterfaces;
using Sport_System.Application.Responses;
using Sport_System.Application.Services.Interfaces;
using Sport_System.Application.Utility.Interfaces;
using Sport_System.Domain.Entity;
using Sport_System.Domain.Models;
using Sport_System.Domain.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SportsManagementSystem.Application.RepositoryInterfaces;

namespace Sport_System.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
     
        private readonly ISportRepository _sportRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoSaver _photoSaver;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeamService(ITeamRepository teamRepository,  ISportRepository sportRepository, IMapper mapper, IPhotoSaver photoSaver, UserManager<ApplicationUser> userManager)
        {
            _teamRepository = teamRepository;
            
            _sportRepository = sportRepository;
            _mapper = mapper;
            _photoSaver = photoSaver;
            _userManager = userManager;
        }

        public async Task<ApiResponse> AddTeam(AddTeamDTO dto)
        {
            if (dto != null)
            {
                var existingTeam = await _teamRepository.GetTeamByName(dto.Name);
                if (existingTeam != null)
                    return new ApiResponse(400, "A team with the same name already exists");

                var team = _mapper.Map<Team>(dto);
                team.Registered_At = DateTime.UtcNow;

                var sport = await _sportRepository.GetSportById(dto.SportId);
                team.SportName = sport.Name;

                string photoFilePath = await _photoSaver.SavePhoto(dto.Logo);
                team.LogoUrl = photoFilePath;

                await _teamRepository.AddTeam(team);

                //assigning the role of TeamOwner to the user
                var applicationUser = await _userManager.FindByIdAsync(dto.TeamOwnerId);
                if (applicationUser != null && !await _userManager.IsInRoleAsync(applicationUser, UserRoles.TeamOwner))
                    await _userManager.AddToRoleAsync(applicationUser, UserRoles.TeamOwner);

                return new ApiResponse(200, "Team got added successfully");
            }
            return new ApiResponse(400, "The team coulnd't be added successfully");
        }

        public async Task<ApiResponse> EditTeam(EditTeamDTO dto)
        {
            var team = await _teamRepository.GetTeamById(dto.TeamId);
            if (team != null)
            {
                var existingTeam = await _teamRepository.GetTeamByName(dto.Name);
                if (existingTeam != null && existingTeam.Name != dto.Name)
                    return new ApiResponse(400, "A team with the same name already exists");

                if (team.Name == dto.Name &&
                    team.ShortName == dto.ShortName &&
                    team.Description == dto.Description &&
                    team.Location == dto.Location &&
                    team.YearFounded == dto.YearFounded)
                { return new ApiResponse(400, "No changes were made."); }

                team.Name = dto.Name;
                team.ShortName = dto.ShortName;
                team.Description = dto.Description;
                team.Location = dto.Location;
                team.YearFounded = dto.YearFounded;

                await _teamRepository.EditTeam(team);
                return new ApiResponse(200, "Team got updated successfully");
            }
            return new ApiResponse(400, "Team couldn't be edited successfully.");
        }

        public async Task<ApiResponse> EditTeamLogo(EditTeamLogoDTO dto)
        {
            var team = await _teamRepository.GetTeamById(dto.TeamId);
            if (team != null)
            {
                if (dto.Logo != null)
                {
                    if (string.Equals(team.LogoUrl, dto.Logo.FileName))
                        return new ApiResponse(400, "No changes were made to the team logo.");

                    string oldPhotoFilePath = "../../../FrontEnd/public" + team.LogoUrl;
                    string newPhotoFilePath = await _photoSaver.SavePhoto(dto.Logo);
                    team.LogoUrl = newPhotoFilePath;

                    if (!string.IsNullOrEmpty(team.LogoUrl) && File.Exists(oldPhotoFilePath))
                        File.Delete(oldPhotoFilePath);
                }
                await _teamRepository.EditTeam(team);
                return new ApiResponse(200, "Team Logo got updated successfully");
            }
            return new ApiResponse(400, "Team Logo couldn't be edited successfully.");
        }

        public async Task<ApiResponse> DeleteTeam(int id)
        {
            var team = await _teamRepository.GetTeamById(id);
            if (team != null)
            {
                await _teamRepository.DeleteTeam(team);
                var logo = "../../../FrontEnd/public" + team.LogoUrl;

                if (!string.IsNullOrEmpty(team.LogoUrl) && File.Exists(logo))
                    File.Delete(logo);

                return new ApiResponse(200, "Team got deleted successfully");
            }
            return new ApiResponse(400, "Team couldn't be deleted successfully.");
        }

        public async Task<GetTeamDTO> GetTeamById(int id)
        {
            var team = await _teamRepository.GetTeamById(id);
            if (team == null)
                return null;

            var teamDTO = _mapper.Map<GetTeamDTO>(team);
            return teamDTO;
        }

        public async Task<List<GetTeamDTO>> GetTeamsByUserId(string userId)
        {
            var teams = await _teamRepository.GetTeamsByUserId(userId);
            if (teams == null)
                return null;

            var teamsDTO = _mapper.Map<List<GetTeamDTO>>(teams);
            return teamsDTO;
        }

        public async Task<List<GetTeamDTO>> GetTeamsUserPlaysFor(string userId)
        {
            var teams = await _teamRepository.GetTeamsUserPlaysFor(userId);
            if (teams == null)
                return null;

            var teamsDTO = _mapper.Map<List<GetTeamDTO>>(teams);
            return teamsDTO;
        }

        public async Task<List<GetTeamDTO>> GetAllTeams()
        {
            var teams = await _teamRepository.GetAllTeams();
            if (teams == null)
                return null;

            var teamDTOList = _mapper.Map<List<GetTeamDTO>>(teams);
            return teamDTOList;
        }

        public async Task<List<GetTeamDTO>> GetTeamsByPlayer(int playerId)
        {
            var teamsWithPlayer = await _teamRepository.GetTeamsByPlayer(playerId);
            var teamsDTO = _mapper.Map<List<GetTeamDTO>>(teamsWithPlayer);
            return teamsDTO;
        }

        public async Task<List<GetTeamDTO>> SearchTeams(string searchTerm)
        {
            var searchDBResult = await _teamRepository.SearchTeams(searchTerm);
            if (searchDBResult == null)
                return null;

            var searchDBResultList = _mapper.Map<List<GetTeamDTO>>(searchDBResult);
            return searchDBResultList;
        }

       
    }
}

