using Microsoft.AspNetCore.Mvc;
using Online_Learning_APP.Application.DTO;
using Online_Learning_APP.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Online_Learning_App_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // POST: api/admin
        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid admin data.");

            try
            {
                var createdAdmin = await _adminService.CreateAdminAsync(dto);
                return CreatedAtAction(nameof(GetAdminById), new { id = createdAdmin.AdminId }, createdAdmin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/admin/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminById(Guid id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            if (admin == null)
                return NotFound("Admin not found.");

            return Ok(admin);
        }

        // GET: api/admin
        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return Ok(admins);
        }

        // DELETE: api/admin/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(Guid id)
        {
            var result = await _adminService.DeleteAdminAsync(id);
            if (!result)
                return NotFound("Admin not found or already deleted.");

            return NoContent();
        }
    }
}
