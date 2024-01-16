using Sport_System.Application.DTOs.SportDTOs;
using Sport_System.Application.Responses;

namespace Sport_System.Application.Services.Interfaces
{
    public interface ISportService
    {
        Task<ApiResponse> AddSport(AddSportDTO dto);
        Task<ApiResponse> EditSport(EditSportDTO dto);
        Task<ApiResponse> DeleteSport(int id);
        Task<GetSportDTO> GetSportById(int id);
        Task<List<GetSportDTO>> GetAllSports();
    }
}
