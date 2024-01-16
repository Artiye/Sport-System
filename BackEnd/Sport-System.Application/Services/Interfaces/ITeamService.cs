using Sport_System.Application.DTOs.TeamDTOs;
using Sport_System.Application.Responses;

using Sport_System.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Services.Interfaces
{
    public interface ITeamService
    {
        Task<ApiResponse> AddTeam(AddTeamDTO dto);
        Task<ApiResponse> EditTeam(EditTeamDTO dto);
        Task<ApiResponse> EditTeamLogo(EditTeamLogoDTO dto);
        Task<ApiResponse> DeleteTeam(int id);
        Task<GetTeamDTO> GetTeamById(int id);
        Task<List<GetTeamDTO>> GetAllTeams();
        Task<List<GetTeamDTO>> SearchTeams(string searchTerm);
    }
}
