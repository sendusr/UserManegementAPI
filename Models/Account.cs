using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_account")]
    public class Account
    {
        [Key]
        [ForeignKey("Person")]
        public string NIK { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [JsonIgnore]
        public virtual Person Person { get; set; }
        [JsonIgnore]
        public virtual Profiling Profiling { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
        public Account() { }
    }
}
