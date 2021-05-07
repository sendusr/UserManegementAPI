﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Base;
using UserManagement.Models;
using UserManagement.Repository.Data;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : BaseController<University, UniversityRepository, int>
    {
        public UniversitiesController(UniversityRepository universityRepository) : base(universityRepository)
        {

        }
    }
}
