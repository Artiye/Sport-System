using Sport_System.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.RepositoryInterfaces
{
    public interface ITournamentRepository
    {
        Task<Tournament> AddTournament(Tournament tournament);
        Task<Tournament> EditTournament(Tournament tournament);
        Task<Tournament> DeleteTournament(Tournament tournament);
        Task<Tournament> GetTournamentById(int id);
        Task<List<Tournament>> GetAllTournaments();
        Task<List<Tournament>> GetTournamentsByUserId(string userId);
        Task<Tournament> GetTournamentByName(string name);
        Task<List<Tournament>> SearchTournaments(string searchTerm);
    }
}
