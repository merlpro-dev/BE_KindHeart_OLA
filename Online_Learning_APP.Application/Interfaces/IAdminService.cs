using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Online_Learning_APP.Application.DTO;

namespace Online_Learning_APP.Application.Interfaces
{
    public interface IAdminService
    {
        Task<AdminDto> CreateAdminAsync(CreateAdminDto createAdminDto);
        Task<AdminDto> GetAdminByIdAsync(Guid adminId);
        Task<IEnumerable<AdminDto>> GetAllAdminsAsync();
        Task<bool> DeleteAdminAsync(Guid adminId);
    }
}
