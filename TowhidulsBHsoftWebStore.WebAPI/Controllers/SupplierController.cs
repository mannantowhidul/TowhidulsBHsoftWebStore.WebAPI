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
    public class SupplierController : MyControllerBase
    {
        private CompanyContext _adminContext;

        public SupplierController(CompanyContext context)
        {
            _adminContext = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Supplier>> Get()
        {
            return _adminContext.Supplier.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Supplier> GetById(int id)
        {
            if (id <= 0)
            {
                return NotFound("Student id must be higher than zero");
            }
            Supplier Supplier = _adminContext.Supplier.FirstOrDefault(s => s.SupplierID == id);
            if (Supplier == null)
            {
                return NotFound("Supplier not found");
            }
            return Ok(Supplier);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Supplier Supplier)
        {
            if (Supplier == null)
            {
                return NotFound("Supplier data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _adminContext.Supplier.AddAsync(Supplier);
            await _adminContext.SaveChangesAsync();
            return Ok(Supplier);
        }

        [HttpDelete("deleteByid/{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("Id is not supplied");
            }
            Supplier Supplier = _adminContext.Supplier.FirstOrDefault(s => s.SupplierID == id);
            if (Supplier == null)
            {
                return NotFound("No Supplier found with particular id supplied");
            }
            _adminContext.Supplier.Remove(Supplier);
            await _adminContext.SaveChangesAsync();
            return Ok("Supplier is deleted sucessfully.");
        }
    }
}
