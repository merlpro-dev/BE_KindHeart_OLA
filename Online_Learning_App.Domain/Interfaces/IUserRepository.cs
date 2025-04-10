using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Learning_App.Domain.Entities;

namespace Online_Learning_App.Domain.Interfaces
{
    public interface IUserRepository
    {
<<<<<<< HEAD
        //Task DeleteAsync(object existingUser);
        //Task GetByIdAsync(string id);
        //Task<ApplicationUser> GetUserByUsernameAsync(string username);
        //Task UpdateAsync(object existingUser);
        //Task<bool> ValidatePasswordAsync(ApplicationUser user, string password);

        Task<ApplicationUser> GetByIdAsync(string id);                        // ✅ Returns ApplicationUser
        Task<ApplicationUser> GetUserByUsernameAsync(string username);       // ✅ Already good
        Task UpdateAsync(ApplicationUser existingUser);                      // ✅ Strongly typed
       Task DeleteAsync(ApplicationUser existingUser);                      // ✅ Strongly typed
       Task<bool> ValidatePasswordAsync(ApplicationUser user, string password);
        

=======
        Task<ApplicationUser> GetUserByUsernameAsync(string username);
        Task<bool> ValidatePasswordAsync(ApplicationUser user, string password);
>>>>>>> a0811f2 (Add project files.)
    }
}
