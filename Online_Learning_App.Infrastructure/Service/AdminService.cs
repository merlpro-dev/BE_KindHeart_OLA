using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Learning_App.Infrastructure; // For ApplicationDbContext
using Online_Learning_APP.Application.DTO; // For AdminDto, CreateAdminDto
using Online_Learning_APP.Application.Interfaces; // For IAdminService
using Online_Learning_App.Domain.Entities; // For Admin
//using Online_Learning_APP.Application.DTO;
//using Online_Learning_APP.Application.Interfaces;
//using Online_Learning_App.Domain.Entities;
//using Online_Learning_App.Infrastructure; // where ApplicationDbContext lives


namespace Online_Learning_APP.Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminDto> CreateAdminAsync(CreateAdminDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
                throw new Exception("User not found.");

            if (dto.RoleId.HasValue)
            {
                var role = await _context.Roles.FindAsync(dto.RoleId.Value);
                if (role == null)
                    throw new Exception("Role not found.");
            }

            var admin = new Admin
            {
                AdminId = Guid.NewGuid(),
                Email = dto.Email,
                UserName = dto.UserName,
                UserId = dto.UserId,
                RoleId = dto.RoleId
            };

            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();

            return new AdminDto
            {
                AdminId = admin.AdminId,
                Email = admin.Email,
                UserName = admin.UserName,
                RoleId = admin.RoleId,
                UserId = admin.UserId
            };
        }

        public async Task<AdminDto> GetAdminByIdAsync(Guid adminId)
        {
            var admin = await _context.Admin
                .Include(a => a.Role)
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.AdminId == adminId);

            if (admin == null)
                return null;

            return new AdminDto
            {
                AdminId = admin.AdminId,
                Email = admin.Email,
                UserName = admin.UserName,
                RoleId = admin.RoleId,
                UserId = admin.UserId
            };
        }

        public async Task<IEnumerable<AdminDto>> GetAllAdminsAsync()
        {
            var admins = await _context.Admin.ToListAsync();

            return admins.Select(admin => new AdminDto
            {
                AdminId = admin.AdminId,
                Email = admin.Email,
                UserName = admin.UserName,
                RoleId = admin.RoleId,
                UserId = admin.UserId
            });
        }

        public async Task<bool> DeleteAdminAsync(Guid adminId)
        {
            var admin = await _context.Admin.FindAsync(adminId);
            if (admin == null)
                return false;

            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
