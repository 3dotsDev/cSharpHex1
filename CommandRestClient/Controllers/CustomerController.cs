using System.Collections.Generic;
using Domain.BusinessObjects;
using LeftDriver.Adapter.Rest;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CommandRestClient.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerController _hexController;

        public CustomerController(ICustomerController controller)
        {
            _hexController = controller;
        }

        //>> http://localhost:5000/api/customer/
        [HttpGet]
        public IEnumerable<Customer> GetAllCustomer()
        {
            return _hexController.List();
        }

        [HttpGet("/{id:int}")]
        public Customer GetCustomerById(int id)
        {
            return _hexController.GetById(id);
        }

        //>> http://localhost:5000/api/customer?lastname=reto&firstname=test
        [HttpPut()]
        public Customer CreateCustomer(string firstName, string lastname)
        {
            return _hexController.Register(lastname, firstName);
        }

        [HttpPatch("/{id:int}/up")]
        public IActionResult UpgradeCustomer(int id)
        {
            if (_hexController.Upgrade(id))
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPatch("/{id:int}/down")]
        public IActionResult DowngradeCustomer(int id)
        {
            if (_hexController.Downgrade(id))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}