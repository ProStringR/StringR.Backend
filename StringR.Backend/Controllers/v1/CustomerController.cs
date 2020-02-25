using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StringR.Backend.DataController;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;
using StringR.Backend.Models;

namespace StringR.Backend.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
     
        private ICustomerDataController _customerDataController;
        
        public CustomerController(IConfiguration configuration)
        {
            _customerDataController = new CustomerDataController(new CustomerDAO(configuration));
        }
        
        /*
         *
         *    GET
         * 
         */

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
        
        /*
         *
         *    POST
         * 
         */
         
        [AllowAnonymous]
        [HttpPost]
        public ActionResult PostCustomer([FromBody] Customer customer)
        {
            try
            {
                _customerDataController.PostCustomer(
                    customer.FirstName, 
                    customer.LastName, 
                    customer.Email, 
                    customer.PhoneNumber, 
                    customer.UserId, 
                    customer.Password, 
                    customer.PreferredStringTypeId, 
                    customer.PreferredTensionVertical, 
                    customer.PreferredTensionHorizontal);

                return Ok("The customer is saved successfully");
            }
            catch (Exception e)
            {
                return NotFound("Something went wrong saving the customer");
            }
        }

    }
}