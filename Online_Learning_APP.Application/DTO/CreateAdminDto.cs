using System;

namespace Online_Learning_APP.Application.DTO
{
    public class CreateAdminDto
    {
        /// <summary>
        /// Admin's email address (optional)
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Admin's username (optional)
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// The ID of the user this admin account is linked to (required)
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The role assigned to this admin (optional)
        /// </summary>
        public Guid? RoleId { get; set; }
    }
}
