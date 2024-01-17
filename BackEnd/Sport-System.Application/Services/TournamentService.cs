using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Sport_System.Application.DTOs.TournamentDTOs;
using Sport_System.Application.RepositoryInterfaces;
using Sport_System.Application.Responses;
using Sport_System.Application.Services.Interfaces;
using Sport_System.Application.Utility.Interfaces;
using Sport_System.Domain.Models;
using Sport_System.Domain.StaticData;
using SportsManagementSystem.Application.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ISportRepository _sportRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoSaver _photoSaver;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;

        public TournamentService(ITournamentRepository tournamnetRepository, ISportRepository sportRepository, ITeamRepository teamRepository, IMapper mapper, IPhotoSaver photoSaver, IEmailSender emailSender, UserManager<ApplicationUser> userManager)
        {
            _tournamentRepository = tournamnetRepository;
            _sportRepository = sportRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
            _photoSaver = photoSaver;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        public async Task<ApiResponse> AddTournament(AddTournamentDTO dto)
        {
            if (dto != null)
            {
                if (dto.SportId == null || dto.SportId == 0)
                    return new ApiResponse(400, "The sport type is required");

                var existingTournament = await _tournamentRepository.GetTournamentByName(dto.Name);
                if (existingTournament != null)
                    return new ApiResponse(400, "A tournament with the same name already exists");

                var tournament = _mapper.Map<Tournament>(dto);

                string photoFilePath = await _photoSaver.SavePhoto(dto.Logo);
                tournament.ImageUrl = photoFilePath;

                var sport = await _sportRepository.GetSportById(dto.SportId);
                tournament.SportName = sport.Name;

                await _tournamentRepository.AddTournament(tournament);

                //assigning the role of TeamOwner to the user
                var applicationUser = await _userManager.FindByIdAsync(dto.TournamentAdministratorId);
                if (applicationUser != null && !await _userManager.IsInRoleAsync(applicationUser, UserRoles.TournamentAdministrator))
                    await _userManager.AddToRoleAsync(applicationUser, UserRoles.TournamentAdministrator);

                return new ApiResponse(200, "Tournament was added successfully");
            }
            return new ApiResponse(400, "The Tournament couldn't be added successfully");
        }

        public async Task<ApiResponse> DeleteTournament(int id)
        {
            var tournament = await _tournamentRepository.GetTournamentById(id);
            if (tournament != null)
            {
                await _tournamentRepository.DeleteTournament(tournament);
                var logo = tournament.ImageUrl;

                if (!string.IsNullOrEmpty(tournament.ImageUrl) && File.Exists(logo))
                    File.Delete(logo);

                return new ApiResponse(200, "Tournament got deleted successfully");
            }
            return new ApiResponse(400, "Tournament couldn't be deleted successfully.");
        }

        public async Task<ApiResponse> EditTournament(EditTournamentDTO dto)
        {
            var tournament = await _tournamentRepository.GetTournamentById(dto.TournamentId);
            if (tournament != null)
            {
                var existingTournament = await _tournamentRepository.GetTournamentByName(dto.Name);
                if (existingTournament != null && existingTournament.Name != dto.Name)
                    return new ApiResponse(400, "A tournament with the same name already exists");

                if (tournament.Name == dto.Name && tournament.Description == dto.Description)
                    return new ApiResponse(400, "No changes were made.");

                tournament.Name = dto.Name;
                tournament.Description = dto.Description;

                await _tournamentRepository.EditTournament(tournament);
                return new ApiResponse(200, "Tournament got updated successfully");
            }
            return new ApiResponse(400, "Tournament couldn't be edited successfully.");
        }

        public async Task<ApiResponse> EditTournamentLogo(EditTournamentLogoDTO dto)
        {
            var tournament = await _tournamentRepository.GetTournamentById(dto.TournamentId);
            if (tournament != null)
            {
                if (dto.Logo != null)
                {
                    if (string.Equals(tournament.ImageUrl, dto.Logo.FileName))
                        return new ApiResponse(400, "No changes were made to the tournament logo.");

                    string oldPhotoFilePath = tournament.ImageUrl;
                    string newPhotoFilePath = await _photoSaver.SavePhoto(dto.Logo);
                    tournament.ImageUrl = newPhotoFilePath;

                    if (!string.IsNullOrEmpty(tournament.ImageUrl) && File.Exists(oldPhotoFilePath))
                        File.Delete(oldPhotoFilePath);
                }
                await _tournamentRepository.EditTournament(tournament);
                return new ApiResponse(200, "Tournament Logo got updated successfully");
            }
            return new ApiResponse(400, "Tournament Logo couldn't be edited successfully.");
        }

        public async Task<List<GetTournamentDTO>> GetAllTournaments()
        {
            var tournaments = await _tournamentRepository.GetAllTournaments();
            if (tournaments == null)
                return null;

            var tournamentDTOList = _mapper.Map<List<GetTournamentDTO>>(tournaments);
            return tournamentDTOList;
        }

        public async Task<GetTournamentDTO> GetTournamentById(int id)
        {
            var tournament = await _tournamentRepository.GetTournamentById(id);
            if (tournament == null)
                return null;

            var tournamentDTO = _mapper.Map<GetTournamentDTO>(tournament);
            return tournamentDTO;
        }

        public async Task<List<GetTournamentDTO>> GetTournamentsByUserId(string userId)
        {
            var tournaments = await _tournamentRepository.GetTournamentsByUserId(userId);
            if (tournaments == null)
                return null;

            var tournamentsDTO = _mapper.Map<List<GetTournamentDTO>>(tournaments);
            return tournamentsDTO;
        }

        public async Task<ApiResponse> AddTeamToTournament(int tournamentId, int teamId)
        {
            var tournament = await _tournamentRepository.GetTournamentById(tournamentId);
            var team = await _teamRepository.GetTeamById(teamId);

            if (tournament != null && team != null && tournament.SportId == team.SportId)
            {
                tournament.Teams?.Add(team);

                var updatedTournament = await _tournamentRepository.EditTournament(tournament);
                if (updatedTournament != null)
                    return new ApiResponse(200, "Team added to the tournament successfully");
            }
            return new ApiResponse(400, "Tournament or team not found");
        }

        public async Task<ApiResponse> RemoveTeamFromTournament(int tournamentId, int teamId)
        {
            var tournament = await _tournamentRepository.GetTournamentById(tournamentId);
            var team = await _teamRepository.GetTeamById(teamId);

            if (tournament != null && team != null)
            {
                tournament.Teams?.Remove(team);

                var updatedTournament = await _tournamentRepository.EditTournament(tournament);
                if (updatedTournament != null)
                    return new ApiResponse(200, "Team removed from the tournament successfully");
            }
            return new ApiResponse(400, "Tournament or team not found");
        }

        //search
        public async Task<List<GetTournamentDTO>> SearchTournaments(string searchTerm)
        {
            var searchDBResult = await _tournamentRepository.SearchTournaments(searchTerm);
            if (searchDBResult == null)
                return null;

            var searchDBResultList = _mapper.Map<List<GetTournamentDTO>>(searchDBResult);
            foreach (var dto in searchDBResultList)
            {
                var sport = await _sportRepository.GetSportById(dto.SportId);
                dto.SportName = sport.Name;
            }

            return searchDBResultList;
        }

    }
}
