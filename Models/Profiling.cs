using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_profiling")]
    public class Profiling
    {
        [Key]
        [ForeignKey("Account")]
        public string NIK { get; set; }
        public int EducationID { get; set; }
        [JsonIgnore]
        public virtual Education Education { get; set; }
         [JsonIgnore]
        public virtual Account Account { get; set; }
        public Profiling() { }

    }
}
