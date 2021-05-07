using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_education")]
    public class Education
    {
        public int EducationID { get; set; }

        [Required(ErrorMessage = "Degree harus diisi!.")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "GPA harus diisi!.")]
        public string GPA { get; set; }
        public int UniversityID { get; set; }
       // [JsonIgnore]
        public virtual University University { get; set; }
        [JsonIgnore]
        public virtual ICollection<Profiling> Profiling { get; set; }
       
        public Education() { }
    }
}
