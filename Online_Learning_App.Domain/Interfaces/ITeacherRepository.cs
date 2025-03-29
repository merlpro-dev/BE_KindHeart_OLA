using System;
using System.Threading.Tasks;
using Online_Learning_App.Domain.Entities;

namespace Online_Learning_App.Domain.Interfaces
{
    public interface ITeacherRepository
    {
        Task<Teacher?> GetByUserIdAsync(Guid userId);
        Task AddAsync(Teacher teacher);
    }
}
