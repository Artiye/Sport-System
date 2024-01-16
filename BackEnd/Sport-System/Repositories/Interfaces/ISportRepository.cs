using Sport_System.Models;

namespace Sport_System.Repositories.Interfaces
{
    public interface ISportRepository
    {
        Task<Sport> AddSport(Sport sport);
        Task<Sport> EditSport(Sport sport);
        Task<Sport> DeleteSport(Sport sport);
        Task<Sport> GetSportById(int id);
        Task<List<Sport>> GetAllSports();
        Task<Sport> GetSport(int id);
        Task<Sport> GetSportByName(string name);
    }
}
