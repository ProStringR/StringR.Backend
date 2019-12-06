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
    public class OrderController : ControllerBase
    {
        
        private IOrderDataController _orderDataController;
        
        public OrderController(IConfiguration configuration)
        {
            _orderDataController = new OrderDataController(new OrderDAO(configuration));
        }
        
        /*
         *
         *    GET
         * 
         */
        
        [HttpGet]
        public ActionResult<string> Get()
        {
            return BadRequest("Not implemented...");
        }

        [HttpGet("{orderId}")]
        public ActionResult<string> GetOrderById(int orderId)
        {
            try
            {
                return _orderDataController.GetOrderById(orderId);
            }
            catch (Exception e)
            {
                return BadRequest("Failed... " + e);
            }
        }

        [HttpGet("shop/{shopId}")]
        public ActionResult<string> GetAllOrdersForShop(int shopId)
        {
            try
            {
                return _orderDataController.GetAllOrdersForShop(shopId);
            }
            catch (Exception e)
            {
                return BadRequest("Failed... " + e);

            }
        }
        
        [HttpGet("shop/{shopId}/{orderStatus}")]
        public ActionResult<string> GetAllOrdersForShop(int shopId, int orderStatus)
        {
            try
            {
                return _orderDataController.GetAllOrdersForShopOnStatus(shopId, orderStatus);
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
        [HttpPost]
        public ActionResult PostOrder([FromBody] Order order)
        {
            try
            {
                _orderDataController.PostOrder(order);
                return Ok("The order has been placed successfully");
            }
            catch (Exception e)
            {
                return NotFound("Something went wrong placing the order");
            }
        }

        /*
         *
         *    PUT
         * 
         */

        [HttpPut]
        public ActionResult PutOrder([FromBody] OrderTransaction orderTransaction)
        {
            try
            {
                _orderDataController.PutOrder(orderTransaction.OrderId, orderTransaction.TransactionDate, orderTransaction.PaidStatus, orderTransaction.OrderStatus);
                return Ok("Your order is now updated");
            }
            catch (Exception e)
            {
                return NotFound("Something went wrong during the updating process");
            }
        }
    }
}