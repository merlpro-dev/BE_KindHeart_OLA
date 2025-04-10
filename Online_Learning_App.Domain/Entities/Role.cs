using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Online_Learning_App.Domain.Entities
{
<<<<<<< HEAD
    public class Role : IdentityRole<Guid>
    {
        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
      //  public ICollection<ApplicationUser> Users { get; set; }
=======
    public class Role : IdentityRole
    {
>>>>>>> a0811f2 (Add project files.)
    }
}
