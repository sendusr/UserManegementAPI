using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_university")]
    public class University
    {
      
        public int UniversityID { get; set; }

        [Required(ErrorMessage = "Nama Universitas is required.")]
        public string Nama { get; set; }
        [JsonIgnore]
        public virtual ICollection<Education> Education { get; set; }

    }
}
