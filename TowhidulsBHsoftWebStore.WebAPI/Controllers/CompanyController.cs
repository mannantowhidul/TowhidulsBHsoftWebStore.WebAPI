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
    public class CompanyController : MyControllerBase
    {
        private CompanyContext _CompanyContext;

        public CompanyController(CompanyContext context)
        {
            _CompanyContext = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            return _CompanyContext.Company.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Company> GetById(int id)
        {
            if (id <= 0)
            {
                return NotFound("Company id must be higher than zero");
            }
            Company company = _CompanyContext.Company.FirstOrDefault(s => s.CompanyId == id);
            if (company == null)
            {
                return NotFound("Company not found");
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Company company)
        {
            if (company == null)
            {
                return NotFound("Company data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _CompanyContext.Company.AddAsync(company);
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
            Company company = _CompanyContext.Company.FirstOrDefault(s => s.CompanyId == id);
            if (company == null)
            {
                return NotFound("No Company found with particular id supplied");
            }
            _CompanyContext.Company.Remove(company);
            await _CompanyContext.SaveChangesAsync();
            return Ok("Company is deleted sucessfully.");
        }
    }
}
