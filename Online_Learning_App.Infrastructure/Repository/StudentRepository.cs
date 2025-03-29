using Microsoft.EntityFrameworkCore;
using Online_Learning_App.Domain.Entities;
using Online_Learning_App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_Learning_App.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

       // public async Task<Student> AddAsync(Student student)
       public async Task AddAsync(Student student)

        {
           // _context.Students.Add(student);
            await _context.SaveChangesAsync();
          //  return student;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(s => s.User)
                .Include(s => s.Role)
                .Include(s => s.ClassGroup)
                .Include(s => s.Submissions)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _context.Students
                .Include(s => s.User)
                .Include(s => s.Role)
                .Include(s => s.ClassGroup)
                .Include(s => s.Submissions)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> GetByUserIdAsync(Guid userId)
        {
            return await _context.Students
                .Include(s => s.User)
                .Include(s => s.Role)
                .Include(s => s.ClassGroup)
                .FirstOrDefaultAsync(s => s.UserId == userId);
        }
    }
}
