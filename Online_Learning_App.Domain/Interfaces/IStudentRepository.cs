using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Learning_App.Domain.Entities;

namespace Online_Learning_App.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task AddAsync(Student student);
        // Optionally: Add other methods like GetByIdAsync, DeleteAsync, etc.
        Task<Student> GetByUserIdAsync(Guid userId);
    }
}
