using AutoMapper;
using Sport_.Application.DTOs.PlayerDTOs;
using Sport_System.Application.DTOs.IdentityDTOs;
using Sport_System.Application.DTOs.IdentityUserDTOs;
using Sport_System.Application.DTOs.PlayerDTOs;
using Sport_System.Application.DTOs.SportDTOs;
using Sport_System.Application.DTOs.TeamDTOs;
using Sport_System.Application.DTOs.TournamentDTOs;
using Sport_System.Domain.Entity;
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
            CreateMap<GetUserDto, ApplicationUser>().ReverseMap();

            CreateMap<Team, AddTeamDTO>().ReverseMap();
            CreateMap<Team, EditTeamDTO>().ReverseMap();
            CreateMap<Team, GetTeamDTO>().ReverseMap();
            CreateMap<Team, GetOnlyTeamDTO>().ReverseMap();

            CreateMap<Player, AddPlayerDTO>().ReverseMap();
            CreateMap<Player, EditPlayerDTO>().ReverseMap();
            CreateMap<Player, GetPlayerDTO>().ReverseMap();

            CreateMap<Tournament, AddTournamentDTO>().ReverseMap();
            CreateMap<Tournament, EditTournamentDTO>().ReverseMap();
            CreateMap<Tournament, GetTournamentDTO>().ReverseMap();
            CreateMap<Tournament, GetOnlyTournamentDTO>().ReverseMap();
        }
    }
}
