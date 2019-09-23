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
    public class BuyerRequestSubmissionController : MyControllerBase
    {
        private CompanyContext _CompanyContext;

        public BuyerRequestSubmissionController(CompanyContext context)
        {
            _CompanyContext = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<BuyerRequestSubmission>> Get()
        {
            return _CompanyContext.BuyerRequestSubmission.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<BuyerRequestSubmission> GetById(int id)
        {
            if (id <= 0)
            {
                return NotFound("Request id must be higher than zero");
            }
            BuyerRequestSubmission company = _CompanyContext.BuyerRequestSubmission.FirstOrDefault(s => s.RequestId == id);
            if (company == null)
            {
                return NotFound("Request not found");
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]BuyerRequestSubmission company)
        {
            if (company == null)
            {
                return NotFound("Request data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _CompanyContext.BuyerRequestSubmission.AddAsync(company);
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
            BuyerRequestSubmission company = _CompanyContext.BuyerRequestSubmission.FirstOrDefault(s => s.RequestId == id);
            if (company == null)
            {
                return NotFound("No Request found with particular id supplied");
            }
            _CompanyContext.BuyerRequestSubmission.Remove(company);
            await _CompanyContext.SaveChangesAsync();
            return Ok("Request is deleted sucessfully.");
        }
    }
}
