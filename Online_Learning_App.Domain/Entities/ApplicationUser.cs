using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> a0811f2 (Add project files.)
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Online_Learning_App.Domain.Entities
{
<<<<<<< HEAD
    public class ApplicationUser: IdentityUser<Guid>
    {
        public virtual Role Role { get; set; }
        public Guid? RoleId { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;

        public virtual Student Student { get; set; }
         public Guid? ClassgroupId { get; set; }
        // public virtual Teacher Teacher { get; set; }
=======
    public class ApplicationUser: IdentityUser
    {
>>>>>>> a0811f2 (Add project files.)
    }
}
