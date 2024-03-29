﻿using Sport_System.Domain.Models;

namespace Sport_System.Application.RepositoryInterfaces
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
