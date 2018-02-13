using Identity.Core.Entities;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WebUI._1._0.Core.Model
{
    public class ExtendedUser:IdentityUser
    {        
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ExtendedUser, int> manager)
        {            
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);         
            return userIdentity;
        }
    }
}