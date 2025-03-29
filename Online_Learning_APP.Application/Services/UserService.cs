using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Online_Learning_App.Domain.Entities;
using Online_Learning_App.Domain.Interfaces;
using Online_Learning_APP.Application.DTO;
using Online_Learning_APP.Application.Interfaces;
using System.Threading.Tasks;


namespace AuthenticationApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        //private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IAdminRepository _adminRepository;

        public UserService(
            UserManager<ApplicationUser> userManager, 
            RoleManager<Role> roleManager,
            IStudentRepository studentRepository, //added 25.3.25
            ITeacherRepository teacherRepository,  //added 25.3.25
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _studentRepository = studentRepository; //  added 25.3.25
            _teacherRepository = teacherRepository; //  added 25.3.25
            _userRepository = userRepository;
        }

        public async Task<string> RegisterUserAsync(
            string username, 
            string email, 
            string password, 
            string roleName,
            string firstName, 
            string lastName,
            Guid? ClassgroupID)
        {
            // Check if the role exists
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return "Role does not exist!";
            }

            // Create a new user
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                RoleId= role.Id,
                FirstName=firstName,
                LastName=lastName,
            };

            // Create the user with hashed password
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                return "User creation failed!";
            }

            // Assign the role to the user
          
            await _userManager.AddToRoleAsync(user, roleName);

            if (role.Name == "Student")
            {
                // Check if the student already exists
               var existingStudent = await _studentRepository.GetByUserIdAsync(user.Id);


                //  var existingStudent = await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == user.Id);
                if (existingStudent == null)  // Only add if the student doesn't already exist
                {

                    var student = new Student
                    {
                        Id = Guid.NewGuid(),  // use Guid.NewGuid() instead of new Guid()
                        Email = user.Email,
                        UserName = user.UserName,
                        ClassLevel = "One",
                        UserId = user.Id,
                        ClassGroupId = ClassgroupID
                    };

                    await _studentRepository.AddAsync(student);  //  Replaces _context
                }
            }
            else if (role.Name == "Admin")
            {
                // Check if the teacher already exists

                var existingTeacher = await _teacherRepository.GetByUserIdAsync(user.Id);


                if (existingTeacher == null)  // Only add if the teacher doesn't already exist
                {
                    var admin = new Admin
                    {
                        AdminId = Guid.NewGuid(),  // Generate a new AdminId
                        Email = user.Email,
                        UserName = user.UserName,
                        UserId = user.Id
                    };

                    await _adminRepository.AddAsync(admin);  // Use repository instead of _context
                }
            }
            else if (role.Name == "Teacher")
            {
               var existingTeacher = await _teacherRepository.GetByUserIdAsync(user.Id);
                if (existingTeacher == null)
                {
                    var teacher = new Teacher
                    {
                        Id = Guid.NewGuid(),
                        Email = user.Email,
                        UserName = user.UserName,
                        UserId = user.Id
                    };
                    await _teacherRepository.AddAsync(teacher);
                }
            }
            // Ensure your ApplicationUser entity has a RoleId property
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password); // Correct hashing

            return "User registered successfully!";
        }

        public async Task<ApplicationUser> GetProfileAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

        //public async Task<bool> UpdateUserAsync(String id, ApplicationUser updatedUser)
        //{
        //    var existingUser = await _userRepository.GetByIdAsync(id);
        //    if (existingUser == null)
        //        return false;

        //    existingUser.FirstName = updatedUser.FirstName;
        //    existingUser.LastName = updatedUser.LastName;
        //    existingUser.Email = updatedUser.Email;
        //    existingUser.UserName = updatedUser.UserName;
        //    existingUser.RoleId = updatedUser.RoleId;
        //    existingUser.ClassgroupId = updatedUser.ClassgroupId;

        //    await _userRepository.UpdateAsync(existingUser);
        //    return true;
        //}
        public async Task<bool> UpdateUserAsync(string id, ProfileDTO updatedProfile)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                return false;

            existingUser.FirstName = updatedProfile.FirstName;
            existingUser.LastName = updatedProfile.LastName;
            existingUser.Email = updatedProfile.Email;
            existingUser.UserName = updatedProfile.UserName;
            //existingUser.RoleId = updatedProfile.RoleId;
            existingUser.RoleId = Guid.TryParse(updatedProfile.RoleId, out var roleGuid)
                ? roleGuid
                : (Guid?)null;
            existingUser.ClassgroupId = updatedProfile.ClassgroupId;

            await _userRepository.UpdateAsync(existingUser);
            return true;
        }

        public async Task<bool> DeleteUserAsync(String id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                return false;

            await _userRepository.DeleteAsync(existingUser);
            return true;
        }



    }
}
