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

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Admin> GetById(int id)
        {
            if (id <= 0)
            {
                return NotFound("Admin id must be higher than zero");
            }
            Admin admin = _adminContext.Admin.FirstOrDefault(s => s.AdminId == id);
            if (admin == null)
            {
                return NotFound("Admin not found");
            }
            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Admin admin)
        {
            if (admin == null)
            {
                return NotFound("Admin data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _adminContext.Admin.AddAsync(admin);
            await _adminContext.SaveChangesAsync();
            return Ok(admin);
        }

        [HttpDelete("deleteByid/{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("Id is not supplied");
            }
            Admin admin = _adminContext.Admin.FirstOrDefault(s => s.AdminId == id);
            if (admin == null)
            {
                return NotFound("No Administrator found with particular id supplied");
            }
            _adminContext.Admin.Remove(admin);
            await _adminContext.SaveChangesAsync();
            return Ok("Buyer is deleted sucessfully.");
        }
    }
}