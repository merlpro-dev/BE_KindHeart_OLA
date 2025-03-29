using Online_Learning_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_Learning_App.Domain.Interfaces
{
    public interface IAdminRepository
    {
        //Task<Admin> GetByIdAsync(Guid id);
        //Task<IEnumerable<Admin>> GetAllAsync();
        //Task<Admin> AddAsync(Admin admin);
        //Task<bool> DeleteAsync(Guid id);
        //Task<Admin> GetByUserIdAsync(string userId);
        // Task GetByUserIdAsync(Guid id);

        Task<Admin> GetByIdAsync(Guid id);
        Task<IEnumerable<Admin>> GetAllAsync();
        Task<Admin> AddAsync(Admin admin);
        Task<bool> DeleteAsync(Guid id);

        // GetByUserIdAsync
        Task<Admin> GetByUserIdAsync(string userId);

    }
}
