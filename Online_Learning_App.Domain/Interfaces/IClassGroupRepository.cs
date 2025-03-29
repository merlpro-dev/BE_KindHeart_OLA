using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Online_Learning_App.Domain.Entities;

namespace Online_Learning_App.Domain.Interfaces
{
    public interface IClassGroupRepository
    {
        Task<ClassGroup> AddAsync(ClassGroup classGroup);
        Task<ClassGroup?> GetByIdAsync(Guid classGroupId);
        Task<IEnumerable<ClassGroup>> GetAllAsync();
        Task<bool> AdminExistsAsync(Guid adminId);
    }
}
