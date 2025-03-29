using Microsoft.EntityFrameworkCore;
using Online_Learning_App.Domain.Entities;
using Online_Learning_App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_Learning_App.Infrastructure.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> AddAsync(Admin admin)
        {
            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var admin = await _context.Admin.FindAsync(id);
            if (admin == null) return false;

            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _context.Admin
                .Include(a => a.User)
                .Include(a => a.Role)
                .ToListAsync();
        }

        public async Task<Admin> GetByIdAsync(Guid id)
        {
            return await _context.Admin
                .Include(a => a.User)
                .Include(a => a.Role)
                .FirstOrDefaultAsync(a => a.AdminId == id);
        }

        // Implementing GetByUserIdAsync
        public async Task<Admin> GetByUserIdAsync(string userId)
        {

            if (!Guid.TryParse(userId, out var userGuid))
                return null; // or throw an error if invalid ID

            return await _context.Admin
                .Include(a => a.User)
                .Include(a => a.Role)
                        //.FirstOrDefaultAsync(a => a.UserId == userId);
                 .FirstOrDefaultAsync(a => a.UserId == userGuid);

        }
    }
}
