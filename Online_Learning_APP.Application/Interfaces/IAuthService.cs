using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Learning_APP.Application.DTO;

namespace Online_Learning_APP.Application.Interfaces
{
    public interface IAuthService
    {
<<<<<<< HEAD
        //Task<bool> AuthenticateUserAsync(LoginDTO loginDto);
        Task<(bool IsAuthenticated, string? Role)> AuthenticateUserAsync(LoginDTO loginDto);
=======
        Task<bool> AuthenticateUserAsync(LoginDTO loginDto);
>>>>>>> a0811f2 (Add project files.)
    }
}
