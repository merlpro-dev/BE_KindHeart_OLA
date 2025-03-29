using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Learning_App.Domain.Entities;
using Online_Learning_App.Domain.Interfaces; // Your IClassGroupRepository location
using Online_Learning_App.Infrastructure;

namespace Online_Learning_App.Infrastructure.Repository
{
    public class ClassGroupRepository : IClassGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public ClassGroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ClassGroup> AddAsync(ClassGroup classGroup)
        {
            _context.ClassGroups.Add(classGroup);
            await _context.SaveChangesAsync();
            return classGroup;
        }

        public async Task<ClassGroup?> GetByIdAsync(Guid classGroupId)
        {
            return await _context.ClassGroups
                .Include(cg => cg.Students)
                .Include(cg => cg.Activities)
                .Include(cg => cg.ClassGroupSubjects)
                .FirstOrDefaultAsync(cg => cg.ClassGroupId == classGroupId);
        }

        public async Task<IEnumerable<ClassGroup>> GetAllAsync()
        {
            return await _context.ClassGroups.ToListAsync();
        }

        public async Task<bool> AdminExistsAsync(Guid adminId)
        {
            return await _context.Admin.AnyAsync(a => a.AdminId == adminId);
        }
    }
}
