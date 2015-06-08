using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Models
{
    public class UserProfile : IdentityUser
    {
        public virtual UserProfileInfo UserProfileInfo { get; set; }
    }

    public class UserProfileInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }

    public class DbContext : IdentityDbContext<UserProfile>
    {
        public DbContext() :
            base("BerthaContext")
        {
        }
    }
}
