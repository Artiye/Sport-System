using Sport_.Application.DTOs.PlayerDTOs;
using Sport_System.Application.DTOs.PlayerDTOs;
using Sport_System.Application.Responses;
using Sport_System.Application.DTOs.PlayerDTOs;
using Sport_System.Application.Responses;
using Sport_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<ApiResponse> AddPlayer(AddPlayerDTO dto);
        Task<ApiResponse> EditPlayer(EditPlayerDTO dto);
        Task<ApiResponse> DeletePlayer(int id);
        Task<GetPlayerDTO> GetPlayerById(int id);
        Task<List<GetPlayerDTO>> GetPlayersByUser(string id);
        Task<List<GetPlayerDTO>> GetAllPlayers();
        Task<List<GetPlayerDTO>> GetAllPlayersByTeam(int id);
       


    }
}
