using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TowhidulsBHsoftWebStore.WebAPI.Models;

namespace TowhidulsBHsoftWebStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : MyControllerBase
    {
        private CompanyContext _adminContext;

        public AdminController(CompanyContext context)
        {
            _adminContext = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Admin>> Get()
        {
            return _adminContext.Admin.ToList();
        }
    }
}