using AutoMapper;
using Sport_System.Application.DTOs.IdentityDTOs;
using Sport_System.Application.DTOs.SportDTOs;
using Sport_System.Domain.Models;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Sport_System.MappingProfiles
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Sport, AddSportDTO>().ReverseMap();
            CreateMap<Sport, EditSportDTO>().ReverseMap();
            CreateMap<Sport, GetSportDTO>().ReverseMap();

            CreateMap<RegisterDTO, ApplicationUser>().ReverseMap();
            CreateMap<LoginDTO, ApplicationUser>().ReverseMap();
        }
    }
}
