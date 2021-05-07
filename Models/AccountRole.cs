using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    public class AccountRole
    {
        public string NIK { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        public int RoleID { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
