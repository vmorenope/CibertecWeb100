﻿using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace CIbertec.WebApi.Controllers
{
    [Route("api/Order")]
    public class OrderController : BaseController
    {
        public OrderController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Orders.GetList());
        }

        [HttpGet]
        [Route("id:int")]
        public ActionResult GetById(int id)
        {
            return Ok(_unit.Orders.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Orders.Insert(order));
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Order order)
        {
            if (ModelState.IsValid && _unit.Orders.Update(order))
                return Ok(new { Message = "The ordes is updated" });
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Order order)
        {
            if (order.Id > 0)
                return Ok(_unit.Orders.Delete(order));
            return BadRequest(new { Message = "Incorrect data." });
        }
    }

}