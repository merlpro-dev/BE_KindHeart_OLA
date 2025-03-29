using System.Threading.Tasks;
using Online_Learning_App.Domain.Entities;

namespace Online_Learning_APP.Application.Interfaces
{
    public interface IStudentService
    {
        Task<string> RegisterStudentAsync(Student student);
    }
}
