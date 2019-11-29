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
    }
}