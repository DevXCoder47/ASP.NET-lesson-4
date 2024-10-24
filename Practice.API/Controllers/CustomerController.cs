using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.API.ServiceInterfaces;

namespace Practice.API.Controllers
{
    [Route("customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService service;
        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }
        [HttpGet("all")]
        public ActionResult<List<Customer>> Get()
        {
            return Ok(service.GetCustomers());
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer? customer = service.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }
        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.AddCustomer(customer);
                    return Created($"customers/{customer.Id}", service.GetCustomerById(customer.Id));
                }
                catch
                {
                    return BadRequest("Ids can't be the same");
                }
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (service.DeleteCustomerById(id))
                return NoContent();
            return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, Customer customer)
        {
            customer.Id = id;
            if (service.EditCustomerById(id, customer))
                return Ok(customer);
            return BadRequest("There is no such id");
        }
    }
}
