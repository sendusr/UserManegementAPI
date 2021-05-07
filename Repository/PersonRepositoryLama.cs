using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Interface;
using UserManagement.ViewModel;

namespace UserManagement.Repository
{
    public class PersonRepositoryLama : IPersonRepository
    {
        private readonly MyContext conn;// = new MyContext();
        public PersonRepositoryLama(MyContext conn)
        {
            this.conn = conn;
        }
       
        

        public Person Insert(Person person)
        {
            conn.Persons.Add(person);//menyimpan ke database
            var result = conn.SaveChanges();//menyimpan
            return person;
        }
        public Person Delete(string NIK)
        {
            var delPerson = conn.Persons.Find(NIK);
            conn.Persons.Remove(delPerson);
            var result = conn.SaveChanges();
            return delPerson;
        }

        public Person Update(Person person)
        {
            //entitty state.modified
            conn.Persons.Update(person);
            var result = conn.SaveChanges();
            return person;
        }
        public Person Get(string NIK)
        {
            var ces = conn.Persons.Find(NIK);

            if (conn.Persons.Any(o => o.NIK == NIK))
            {
                return ces;
            }
            return ces;

        }

        public PersonVM GetFirstName(string NIK)
        {
            var cek =  conn.Persons.Find(NIK);
            PersonVM person = new PersonVM();
            person.FirstName = cek.FirstName;
            person.NIK = cek.NIK;
            person.Salary = cek.Salary;
            return person;
        }
        public IEnumerable<PersonVM> GetCoba()
        {

            IEnumerable<Person> persons = new List<Person>();
            List<PersonVM> personVM = new List<PersonVM>();
            persons = conn.Persons.ToList();
            foreach (var item in persons)
            {
                PersonVM personList = new PersonVM();
                personList.NIK = item.NIK;
                personList.FirstName = item.FirstName;
                personList.Salary = item.Salary;           
                personVM.Add(personList);
                

            }

            return personVM;
        }

        public IEnumerable<PersonVM> GetALL()
        {
            IEnumerable<Person> persons = new List<Person>();
            persons = conn.Persons.ToList();
            var cek = persons.Where(p => p.Salary >= 900000)
            
               .Select(p => new PersonVM()
                {
                  
                    FirstName = p.FirstName,
                    NIK = p.NIK,

                  //  Salary = p.Salary

                });
            return cek;
        }
        public IEnumerable<Person> Get()
        {
            IEnumerable<Person> persons = new List<Person>();
            persons = conn.Persons.ToList();

            return persons;
        }

        
        //public IEnumerable<Person> GetALL2()
        //{
        //    IEnumerable<Person> persons = new List<Person>();
        //   // List<PersonVM> personVM = new List<PersonVM>();
        //    persons = conn.Persons.ToList();
        //    var cek = persons.
        //        Select(p => new PersonV()
        //        {
        //            FirstName = p.FirstName,
        //            NIK = p.NIK
        //        });
        //    return cek;
        //}

        //IEnumerable<Person> IPersonRepository.GetALL2()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
