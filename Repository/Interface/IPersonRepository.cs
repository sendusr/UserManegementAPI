using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.ViewModel;

namespace UserManagement.Repository.Interface
{
    interface IPersonRepository
    {
        IEnumerable<Person> Get(); //ienum penampung kumpulan data, sifat nya seperti foreach
        Person Get(string NIK);
        Person Insert(Person person);
        Person Update(Person person);
        Person Delete(string NIK);

        PersonVM GetFirstName(string NIK);
        IEnumerable<PersonVM> GetALL();
        IEnumerable<PersonVM> GetCoba();
        //IEnumerable<Person> GetALL2();
    }
}
