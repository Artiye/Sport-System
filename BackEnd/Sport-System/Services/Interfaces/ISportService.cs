using Sport_System.DTOs.SportDTOs;
using Sport_System.Responses;

namespace Sport_System.Services.Interfaces
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
