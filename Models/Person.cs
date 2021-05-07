using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_persons")]
    public class Person
    {
        

        [Key] //1 line di bawahnya menjadi pk
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public Person(string nik, string firstName, string lastName, string phone, DateTime birthDate, int salary, string email)
        {
            NIK = nik;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            BirthDate = birthDate;
            Salary = salary;
            Email = email;
        }
        public Person() { }

        public virtual Account Account { get; set; }
    }
}
