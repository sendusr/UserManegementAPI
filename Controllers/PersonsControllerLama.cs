using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository;
using UserManagement.ViewModel;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsControllerLama : ControllerBase
    {
        private readonly PersonRepositoryLama personRepository;
        public PersonsControllerLama(PersonRepositoryLama personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpPost]
        public ActionResult Post(Person person)
        {
           // personRepository.Insert(person);
            return Ok(personRepository.Insert(person)); //mengembalikan data yang di input(di display di body)
        }
        [HttpPut]
        public ActionResult Update(Person person)
        {
            
            return Ok(personRepository.Update(person));
        } 
        [HttpDelete("{NIK}")]
        public ActionResult Delete(string NIK)
        {
            //Response.StatusCode = 400;
            //var error = new Error();  // Create class Error() w/ prop
            //error.ErrorID = 123;
            //error.Level = 2;
            //error.Message = "You broke the Internet!";
            Person persons = personRepository.Get(NIK);
            if (persons == null)
            {
                 return NotFound("Error! Nik salah! data tidak ditemukan");
                //return Json(error, JsonRequestBehavior.AllowGet);
                //return JsonR(error, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Ok(personRepository.Delete(NIK));
            }
        
            
        }
        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Person> persons = personRepository.Get();
            return Ok(persons);
        }

        [HttpGet("GetFirstName/{NIK}")]
        public ActionResult GetFirstName(string NIK)
        {
            //Person persons2 = personRepository.Get(NIK);
            PersonVM persons = personRepository.GetFirstName(NIK);
            if (persons != null)
            {
               
                return Ok(persons);
            }
            else
            {
                return NotFound("Error! NIK Salah! Data tidak ditemkuan.");
            }
        } 
        [HttpGet("GetALL")]
        

        public ActionResult GetALL()
        {
            IEnumerable<PersonVM> persons = personRepository.GetALL();
            if (persons == null)
            {
                return NotFound("Error! Data Belum Ada");
            }
            return Ok(persons);
        }
        [HttpGet("GetCoba")]
        public ActionResult GetCoba()
        {
            IEnumerable<PersonVM> persons = personRepository.GetCoba();
            if (persons == null)
            {
                return NotFound("Error! Data Belum Ada");
            }
            return Ok(persons);
        }
        
        
        
        [HttpGet("{NIK}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Person))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get(string NIK)
        {
            
            Person persons = personRepository.Get(NIK);
            if (persons ==null)
            {
                return NotFound("Error! Nik salah! data tidak ditemukan");
            }

            


            return Ok(persons);
            // return NotFound
           // var c = persons(HttpStatusCode.NotFound, "Foo does not exist.");
        }
    }
}
