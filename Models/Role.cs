using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }

    }
}
