using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;
using StringR.Backend.DTO;
using StringR.Backend.DTO.Order;
using StringR.Backend.Models;

namespace StringR.Backend.DataController
{
    public class OrderDataController : IOrderDataController
    {
        private OrderDAO _orderDAO;
        
        public OrderDataController(OrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }
        
        /*
         *
         *    GET
         * 
         */

        public OrderDto GetOrderById(int orderId)
        {
            try
            {
                var dataSet = _orderDAO.GetOrderbyId(orderId);
                var order = new OrderDto(dataSet.Tables[0].Rows[0]);

                order.OrderHistory = GetHistoryForOrder(orderId);

                return order;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<OrderDto> GetAllOrdersForShop(int shopId)
        {
            try
            {
                List<OrderDto> orderDtos = new List<OrderDto>();
                var dataSet = _orderDAO.GetAllOrdersForShop(shopId);

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    orderDtos.Add(new OrderDto(row));
                }

                foreach (var orderDto in orderDtos)
                {
                    orderDto.OrderHistory = GetHistoryForOrder(orderDto.Id);
                }

                return orderDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<OrderDto> GetAllOrdersForShopOnStatus(int shopId, int orderStatus)
        {
            try
            {
                List<OrderDto> orderDtos = new List<OrderDto>();
                var dataSet = _orderDAO.GetAllOrdersForShopOnStatus(shopId, orderStatus);

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    orderDtos.Add(new OrderDto(row));
                }

                foreach (var orderDto in orderDtos)
                {
                    orderDto.OrderHistory = GetHistoryForOrder(orderDto.Id);
                }

                return orderDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private List<OrderHistoryDto> GetHistoryForOrder(int orderId)
        {
            var json = JsonConvert.SerializeObject(_orderDAO.GetOrderHistory(orderId).Tables[0]);
            List<OrderHistoryDto> history = JsonConvert.DeserializeObject<List<OrderHistoryDto>>(json);

            return history;
        }

        public void PostOrder(Order order)
        {
            try
            {
                _orderDAO.PostOrder(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }   
        }

        /*
         *
         *    PUT
         * 
         */
        
        public void PutOrder(int orderId, long transactionDate, bool paidStatus, int orderStatus)
        {
            try
            {
                _orderDAO.PutOrder(orderId, transactionDate, paidStatus, orderStatus);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}