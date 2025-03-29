using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Online_Learning_App.Domain.Entities;
using Online_Learning_App.Domain.Interfaces;
using Online_Learning_APP.Application.DTO;
using Online_Learning_APP.Application.Interfaces;

namespace Online_Learning_App.Application.Services
{
    public class ClassGroupService : IClassGroupService
    {
        private readonly IClassGroupRepository _classGroupRepository;

        public ClassGroupService(IClassGroupRepository classGroupRepository)
        {
            _classGroupRepository = classGroupRepository;
        }

        public async Task<ClassGroup> CreateClassGroupAsync(ClassGroupCreateDto classGroupDto)
        {
            // Check if Admin exists
            var adminExists = await _classGroupRepository.AdminExistsAsync(classGroupDto.AdminId);
            if (!adminExists)
                throw new Exception("Admin not found");

            // Create and save the new class group
            var classGroup = new ClassGroup
            {
                ClassGroupId = Guid.NewGuid(),
                ClassName = classGroupDto.ClassName,
                AdminId = classGroupDto.AdminId
            };

            return await _classGroupRepository.AddAsync(classGroup);
        }

        public async Task<List<ClassGroup>> GetAllClassGroupsAsync()
        {
            var groups = await _classGroupRepository.GetAllAsync();
            return new List<ClassGroup>(groups); // converting from IEnumerable to List
        }
    }
}
