using AutoMapper;
using Sport_System.Application.DTOs.SportDTOs;
using Sport_System.Application.RepositoryInterfaces;
using Sport_System.Application.Responses;
using Sport_System.Application.Services.Interfaces;
using Sport_System.Domain.Models;

namespace Sport_System.Application.Services
{
    public class SportService : ISportService
    {
        private readonly ISportRepository _sportRepository;
        private readonly IMapper _mapper;
        public SportService(ISportRepository sportRepository, IMapper mapper)
        {
            _sportRepository = sportRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> AddSport(AddSportDTO dto)
        {
            if (dto != null)
            {
                var existingSport = await _sportRepository.GetSportByName(dto.Name);

                if (existingSport != null)
                    return new ApiResponse(400, "A sport with the same name already exists");

                var sport = _mapper.Map<Sport>(dto);
                await _sportRepository.AddSport(sport);

                return new ApiResponse(200, "Sport got added successfully");
            }
            return new ApiResponse(400, "Invalid input");
        }

        public async Task<ApiResponse> DeleteSport(int id)
        {
            var sport = await _sportRepository.GetSport(id);
            if (sport != null)
            {
                await _sportRepository.DeleteSport(sport);
                return new ApiResponse(200, "Sport got deleted successfully");
            }
            return new ApiResponse(400, "Sport couldn't be deleted successfully.");
        }

        public async Task<ApiResponse> EditSport(EditSportDTO dto)
        {
            var sport = await _sportRepository.GetSport(dto.SportId);
            if (sport != null)
            {
                var existingSport = await _sportRepository.GetSportByName(dto.Name);

                if (existingSport != null)
                    return new ApiResponse(400, "A sport with the same name already exists");

                sport.Name = dto.Name;
                sport.Description = dto.Description;

                await _sportRepository.EditSport(sport);
                return new ApiResponse(200, "Sport updated successfully");
            }
            return new ApiResponse(400, "Sport couldn't be edited successfully.");
        }

        public async Task<List<GetSportDTO>> GetAllSports()
        {
            var sports = await _sportRepository.GetAllSports();
            var sportList = _mapper.Map<List<GetSportDTO>>(sports);
            return sportList;
        }

        public async Task<GetSportDTO> GetSportById(int id)
        {
            var sport = await _sportRepository.GetSport(id);
            var sportDTO = _mapper.Map<GetSportDTO>(sport);
            return sportDTO;
        }
    }
}

