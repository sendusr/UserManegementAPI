using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Repository.Interface;

namespace UserManagement.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repo;
        public BaseController(Repository repository)
        {
            this.repo = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Entity> entities = repo.Get();
            return Ok(entities);
        }

        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            repo.Insert(entity);
            return Ok(); //mengembalikan data yang di input(di display di body)
        }
        [HttpPut]
        public ActionResult Update(Entity entity)
        {
            repo.Update(entity);
            return Ok();
        }
        [HttpDelete("{KEY}")]
        public ActionResult Delete(Key key)
        {
         
            Entity entity = repo.Get(key);
            if (entity == null)
            {
                return NotFound($"Error! {key} salah! data tidak ditemukan");
            }
            else
            {
                repo.Delete(key);
                return Ok();
            }


        }
        [HttpGet("{KEY}")]
        public ActionResult Get(Key key)
        {

            Entity entity = repo.Get(key);
            if (entity == null)
            {
                return NotFound($"Error! {key} salah! data tidak ditemukan");
            }
            return Ok(entity);
            
        }
    }
}
