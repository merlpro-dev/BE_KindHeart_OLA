using System;

namespace Online_Learning_APP.Application.DTO
{
    public class AdminDto
    {
        /// <summary>
        /// Unique identifier for the admin (primary key)
        /// </summary>
        public Guid AdminId { get; set; }

        /// <summary>
        /// Admin's email address
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Admin's display or login username
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Role assigned to this admin (nullable)
        /// </summary>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// User account linked to this admin
        /// </summary>
        public Guid UserId { get; set; }
    }
}
