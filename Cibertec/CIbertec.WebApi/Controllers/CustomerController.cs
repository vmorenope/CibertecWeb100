using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace CIbertec.WebApi.Controllers
{
    //[Produces("application/json")] 07.10 se quita al refactorizar con BaseController

    [Route("api/Customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit) : base(unit)
        {
        }

        //07.10 se quita al refactorizar con BaseController
        //private readonly IUnitOfWork _unit;
        //public CustomerController(IUnitOfWork unit)
        //{
        //    _unit = unit;
        //}

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Customers.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetById(int id)
        {
            return Ok(_unit.Customers.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Customers.Insert(customer));
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            if (ModelState.IsValid && _unit.Customers.Update(customer))
                return Ok(new { Message = "The customer is updated" });
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Customer customer)
        {
            if (customer.Id > 0)
                return Ok(_unit.Customers.Delete(customer));
            return BadRequest(new { Message = "Incorrect data." });
        }


        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.Customers.Count());
        }
        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.Customers.PagedList(startRecord, endRecord));
        }
    }
}