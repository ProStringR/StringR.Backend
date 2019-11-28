using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StringR.Backend.DataController;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;

namespace StringR.Backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
     
        private ICustomerDataController _customerDataController;
        
        public CustomerController(IConfiguration configuration)
        {
            _customerDataController = new CustomerDataController(new CustomerDAO(configuration));
        }

        [HttpGet]
        public ActionResult<string> GetAllCustomers()
        {
            try
            {
                return _customerDataController.GetAllCustomers();
            }
            catch (Exception e)
            {
                return BadRequest("Failed... " + e); 
            }
        }

        [HttpGet("{customerId}")]
        public ActionResult<string> GetCustomerById(int customerId)
        {
            try
            {
                return _customerDataController.GetCustomerById(customerId);
            }
            catch (Exception e)
            {
                return BadRequest("Failed... " + e); 
            }
        }
    }
}