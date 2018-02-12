using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI._1._0.Core.Model
{
    public class ExtendedUser:IdentityUser
    {
        public ExtendedUser()
        {
            Addresses = new List<Address>();
        }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public virtual ICollection<Address> Addresses { get;private set; }
    }
}