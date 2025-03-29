using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Learning_APP.Application.DTO;
using Online_Learning_App.Domain.Entities;
using Online_Learning_App.Domain.Interfaces;
using Online_Learning_APP.Application.Interfaces;


namespace Online_Learning_App.Domain.Interfaces
{
    public interface IClassGroupService
    {
        Task<ClassGroup> CreateClassGroupAsync(ClassGroupCreateDto classGroupDto);
        Task<List<ClassGroup>> GetAllClassGroupsAsync();
    }
}
