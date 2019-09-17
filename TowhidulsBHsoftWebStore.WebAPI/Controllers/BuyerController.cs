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
    public class BuyerController : MyControllerBase
    {
        private CompanyContext _adminContext;

        public BuyerController(CompanyContext context)
        {
            _adminContext = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Buyer>> Get()
        {
            return _adminContext.Buyer.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Buyer> GetById(int id)
        {
            if (id <= 0)
            {
                return NotFound("Student id must be higher than zero");
            }
            Buyer buyer =  _adminContext.Buyer.FirstOrDefault(s => s.BuyerID == id);
            if (buyer == null)
            {
                return NotFound("Buyer not found");
            }
            return Ok(buyer);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Buyer buyer)
        {
            if (buyer == null)
            {
                return NotFound("Buyer data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _adminContext.Buyer.AddAsync(buyer);
            await _adminContext.SaveChangesAsync();
            return Ok(buyer);
        }

        [HttpDelete("deleteByid/{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("Id is not supplied");
            }
            Buyer buyer = _adminContext.Buyer.FirstOrDefault(s => s.BuyerID == id);
            if (buyer == null)
            {
                return NotFound("No Buyer found with particular id supplied");
            }
            _adminContext.Buyer.Remove(buyer);
            await _adminContext.SaveChangesAsync();
            return Ok("Buyer is deleted sucessfully.");
        }
    }
}
