using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyCustomer.Data;
using MyCustomer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCustomer.ViewModels;

namespace MyCustomer.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [Route(template: "customers")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDataContext context)
        {
            var customers = await context.Customers.AsNoTracking().ToListAsync();
            return Ok(customers);
        }

        [HttpGet]
        [Route(template: "customers/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDataContext context,
            [FromRoute] int id)
        {
            var customer = await context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost("customers")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDataContext context,
            [FromBody] CreateCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = new Customer
            {
                Date = DateTime.Now,
                Name = model.Name,
                Address = model.Address
            };

            try
            {
                await context.Customers.AddAsync(customer);
                await context.SaveChangesAsync();
                return Created(uri: $"v1/customer/{customer.Id}", customer);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("customers/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDataContext context,
            [FromBody] CreateCustomerViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
                return NotFound();

            try
            {
                customer.Name = model.Name;
                customer.Address = model.Address;

                context.Customers.Update(customer);
                await context.SaveChangesAsync();

                return Ok(customer);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete(template: "customers/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDataContext context,
            [FromRoute] int id)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }
    }
}