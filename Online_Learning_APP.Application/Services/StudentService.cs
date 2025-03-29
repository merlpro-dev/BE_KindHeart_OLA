using System;
using System.Threading.Tasks;
using Online_Learning_App.Domain.Entities;
using Online_Learning_App.Domain.Interfaces;
using Online_Learning_APP.Application.Interfaces;

namespace Online_Learning_APP.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<string> RegisterStudentAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
            return "Student registered successfully!";
        }
    }
}
