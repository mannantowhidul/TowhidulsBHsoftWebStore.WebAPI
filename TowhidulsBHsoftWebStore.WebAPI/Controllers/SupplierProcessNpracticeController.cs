using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TowhidulsBHsoftWebStore.WebAPI.Models;

namespace TowhidulsBHsoftWebStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierProcessNpracticeController : MyControllerBase
    {
        private CompanyContext _CompanyContext;

        public SupplierProcessNpracticeController(CompanyContext context)
        {
            _CompanyContext = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<SupplierProcessNpractice>> Get()
        {
            return _CompanyContext.SupplierProcessNpractice.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<SupplierProcessNpractice> GetById(int id)
        {
            if (id <= 0)
            {
                return NotFound("Process id must be higher than zero");
            }
            SupplierProcessNpractice company = _CompanyContext.SupplierProcessNpractice.FirstOrDefault(s => s.ProcessId == id);
            if (company == null)
            {
                return NotFound("Process not found");
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]SupplierProcessNpractice company)
        {
            if (company == null)
            {
                return NotFound("Process data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _CompanyContext.SupplierProcessNpractice.AddAsync(company);
            await _CompanyContext.SaveChangesAsync();
            return Ok(company);
        }

        [HttpDelete("deleteByid/{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("Id is not supplied");
            }
            SupplierProcessNpractice company = _CompanyContext.SupplierProcessNpractice.FirstOrDefault(s => s.ProcessId == id);
            if (company == null)
            {
                return NotFound("No Company found with particular id supplied");
            }
            _CompanyContext.SupplierProcessNpractice.Remove(company);
            await _CompanyContext.SaveChangesAsync();
            return Ok("Process is deleted sucessfully.");
        }
    }
}
