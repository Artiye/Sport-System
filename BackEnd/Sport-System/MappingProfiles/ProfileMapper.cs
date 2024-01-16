using AutoMapper;
using Sport_System.DTOs.SportDTOs;
using Sport_System.Models;
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

        }
    }
}
