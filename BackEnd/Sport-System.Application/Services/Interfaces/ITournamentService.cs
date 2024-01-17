using Sport_System.Application.DTOs.TournamentDTOs;
using Sport_System.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Services.Interfaces
{
    public interface ITournamentService
    {
        Task<ApiResponse> AddTournament(AddTournamentDTO dto);
        Task<ApiResponse> EditTournament(EditTournamentDTO dto);
        Task<ApiResponse> EditTournamentLogo(EditTournamentLogoDTO dto);
        Task<ApiResponse> DeleteTournament(int id);
        Task<GetTournamentDTO> GetTournamentById(int id);
        Task<List<GetTournamentDTO>> GetAllTournaments();
        Task<List<GetTournamentDTO>> GetTournamentsByUserId(string userId);
        Task<ApiResponse> AddTeamToTournament(int tournamentId, int teamId);
        Task<ApiResponse> RemoveTeamFromTournament(int teamId, int playerId);
        Task<List<GetTournamentDTO>> SearchTournaments(string searchTerm);
    }
}
