﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Repository.Interface
{
   public interface IRepository<Entity, Key> where Entity : class
    {
        IEnumerable<Entity> Get(); //ienum penampung kumpulan data, sifat nya seperti foreach
        Entity Get(Key key);
        int Insert(Entity entity);
        int Update(Entity entity);
        int Delete(Key key);
    }
}
