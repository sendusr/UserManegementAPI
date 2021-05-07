using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Base;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Data;
using UserManagement.ViewModel;
using UserManagement.Hash;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly MyContext myContext;
        private readonly AccountRepository accountRepository;
        public IConfiguration _configuration;
        // private readonly HashingPwd hash;
        public AccountsController(IConfiguration config,AccountRepository accountRepository, MyContext myContext) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.myContext = myContext;
            _configuration = config;
        }
        public string GeneratePassword()
        {

            return "mccdaga123";
        }
        [HttpPost("Register")] //BELUM ADA METHOD ROLLBACK DATABASE KETIKA ADA PENGISIAN TABLE YANG GAGAL!!!!!!!!! -Rangga
        public ActionResult Register(RegisterVM registerVM)
        {
            var checkNIKTerdaftar = myContext.Persons.Where(p => p.NIK == registerVM.NIK);
            if (checkNIKTerdaftar.Count() == 0)
            {
               
                var person = new Person
                {
                    NIK = registerVM.NIK,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.Email,
                    Phone = registerVM.Phone,
                    BirthDate = registerVM.BirthDate,
                    Salary = registerVM.Salary,
                    Email = registerVM.Email
                };
                myContext.Persons.Add(person);
                var addPerson = myContext.SaveChanges();

                var account = new Account
                {
                    NIK = person.NIK,
                    Password = HashingPwd.HashPassword(registerVM.Password)
                };
                myContext.Accounts.Add(account);
                var addAccount = myContext.SaveChanges();

                var accountRole = new AccountRole
                {
                    NIK = person.NIK,
                    RoleID = 1
                };
                myContext.AccountRoles.Add(accountRole);
                var addAccountRole = myContext.SaveChanges();

                var education = new Education
                {
                    GPA = registerVM.GPA,
                    Degree = registerVM.Degree,
                    UniversityID = registerVM.UniversityID
                };
                myContext.Educations.Add(education);
                var addEducation = myContext.SaveChanges();

                var profiling = new Profiling
                {
                    NIK = person.NIK,
                    EducationID = education.EducationID
                };
                myContext.Profilings.Add(profiling);
                myContext.SaveChanges();


                return Ok();




            }
            return NotFound();

        }
        [Authorize]
        [HttpGet("Profile")]
        public ActionResult getAllReg()
        {
            IEnumerable<RegisterVM> model = null;
            model = (from c in myContext.Persons
                     join u in myContext.Accounts on c.NIK equals u.NIK
                     join d in myContext.Profilings on c.NIK equals d.NIK
                     join f in myContext.Educations on d.EducationID equals f.EducationID
                     select new RegisterVM
                     {
                         NIK = c.NIK,
                         FirstName = c.FirstName,
                         LastName = c.LastName,
                         Phone = c.Phone,
                         BirthDate = c.BirthDate,
                         Salary = c.Salary,
                         Email = c.Email,
                         Password = u.Password,
                         GPA = f.GPA,
                         Degree = f.Degree,
                         EducationID = f.EducationID,
                         UniversityID = f.UniversityID

                     }
                ).ToList();
            return Ok(model);
        }
        //[Authorize]
        [Authorize]
        [HttpGet("Profile/{NIK}")]
        public ActionResult getByID(string NIK)
        {
            var model =
             (from c in myContext.Persons
              join u in myContext.Accounts on c.NIK equals u.NIK
              join d in myContext.Profilings on c.NIK equals d.NIK
              join f in myContext.Educations on d.EducationID equals f.EducationID
              where c.NIK == NIK
              select new
              {
                  NIK = c.NIK,
                  FirstName = c.FirstName,
                  LastName = c.LastName,
                  Phone = c.Phone,
                  BirthDate = c.BirthDate,
                  Salary = c.Salary,
                  Email = c.Email,
                  //Password = u.Password,
                  GPA = f.GPA,
                  Degree = f.Degree,
                  EducationID = f.EducationID,
                  UniversityID = f.UniversityID

              }
                ).ToList();
            return Ok(model);
        }
        [HttpGet("Profile2")]//metode join 1 1 (belajar)
        public ActionResult getAllReg2()
        {
            var model = myContext.Persons
                .Join(
                myContext.Accounts,
                pnik => pnik.NIK,
                anik => anik.NIK,
                (pnik, anik) => new
                {
                    Nik = pnik.NIK,
                    FirstName = pnik.FirstName,
                    LastName = pnik.LastName,
                    Phone = pnik.Phone,
                    BirthDate = pnik.BirthDate,
                    Salary = pnik.Salary,
                    Email = pnik.Email,
                    Password = anik.Password

                }
           


                ).ToList();
            return Ok(model);
        }
        //[HttpGet("Loging/{NIK}-{password}")] //SALAH PEMAHAMAN LOGIN!!!! Pertama mengartikan bahwa login pakai GET -Rangga
        //public ActionResult LogIn(string NIK, string password)
        //{
        //    var model =
        //      (from c in myContext.Persons
        //       join u in myContext.Accounts on c.NIK equals u.NIK
        //       join d in myContext.Profilings on c.NIK equals d.NIK
        //       join f in myContext.Educations on d.EducationID equals f.EducationID
        //       where c.NIK == NIK && u.Password == password
        //       select new RegisterVM
        //       {
        //           NIK = c.NIK,
        //           FirstName = c.FirstName,
        //           LastName = c.LastName,
        //           Phone = c.Phone,
        //           BirthDate = c.BirthDate,
        //           Salary = c.Salary,
        //           Email = c.Email,
        //           Password = u.Password,
        //           GPA = f.GPA,
        //           Degree = f.Degree,
        //           EducationID = f.EducationID,
        //           UniversityID = f.UniversityID

        //       }
        //        ).ToList();
        //    return Ok(model);
        //}
        [HttpPost("Login/")]
        public ActionResult Index(LoginVM loginVM)
        {   
            var myPerson = myContext.Persons.FirstOrDefault(u => u.Email == loginVM.Email);

            if(myPerson!= null)
            {
            var myAccount = myContext.Accounts.FirstOrDefault(u => u.NIK == myPerson.NIK);
            var accountRole = myContext.AccountRoles.Where(ar=> ar.NIK==myAccount.NIK).ToList();

                if (myAccount != null && HashingPwd.ValidatePassword(loginVM.Password, myAccount.Password))    //User was found
                {
                    List<Claim> claims = new List<Claim>();
                    foreach (var item in accountRole.Where(n => n.NIK == myAccount.NIK))
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.Role.Name));
                    }

                    claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));
                    claims.Add(new Claim("Id", myPerson.NIK));
                    claims.Add(new Claim("First Name", myPerson.FirstName));
                    claims.Add(new Claim("Last Name", myPerson.LastName));
                    claims.Add(new Claim("Email", loginVM.Email));

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(10), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else return NotFound("Wrong Nik or Password!");
            }
            else return NotFound("Wrong Nik or Password!");
        }
        [Authorize]
        [HttpPost("Changepass")]
        public ActionResult Updatepassword(ChangePassVM changePassVM)
        {
            var person = myContext.Persons.FirstOrDefault(p => p.Email == changePassVM.Email);
            if (person != null)
            {


                var tesNIK = myContext.Accounts.FirstOrDefault(u => u.NIK == person.NIK);

                if (tesNIK != null && HashingPwd.ValidatePassword(changePassVM.OldPassword, tesNIK.Password))
                {

                    tesNIK.Password = HashingPwd.HashPassword(changePassVM.NewPassword);
                    myContext.Entry(tesNIK).State = EntityState.Modified;
                    myContext.SaveChanges();
                    return Ok();

                }
                else return NotFound();

            }
            else  return NotFound("Email Tidak Terdaftar!"); 

        }
        [HttpPost("Forgotpass")]
        public ActionResult ResetPassword(EmailVM emailVM)
        {
            string newRandomPassword = randomgen();
            var person = myContext.Persons.Where(p => p.Email == emailVM.Email).FirstOrDefault();
            if (person != null)
            {
                 var cekAccount = myContext.Accounts.Where(a => a.NIK == person.NIK).FirstOrDefault();

                //var cekAccount = myContext.Accounts.Find(person.NIK);
                cekAccount.Password = HashingPwd.HashPassword(newRandomPassword);
                myContext.Entry(cekAccount).State = EntityState.Modified;
                myContext.SaveChanges();
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("mccsendusr@gmail.com", GeneratePassword()),
                    EnableSsl = true
                };
                client.Send("mccsendusr@gmail.com", emailVM.Email, "reset password", $"Your new password : {newRandomPassword}");

                return Ok();
            }
            else return NotFound("Email Tidak Terdaftar!");
        }
        public string randomgen()
        {
            int length = 7;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }
    }
}
