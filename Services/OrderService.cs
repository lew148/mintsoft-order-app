using System;
using System.Collections.Generic;
using mintsoft_order_app.Models;

namespace mintsoft_order_app.Services
{
    public interface IOrderService
    {
        void Order(UserDetails request);
    }

    public class OrderService : IOrderService
    {
        public void Order(UserDetails request)
        {
            var order = ConstructModelFromRequest(request);
            AddNonUserFacingDetails(order);
            var s = ApiHelper.SendOrderToMintSoftApi(order);
            Console.Write(s);
        }

        private static OrderModel ConstructModelFromRequest(UserDetails request)
        {
            return new OrderModel
            {
                Country = request.Country,
                Title = request.Title,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Address1 = request.Address1,
                Town = request.Town,
                PostCode = request.PostCode,
                Comments = request.Comments
            };
        }

        private static OrderModel AddNonUserFacingDetails(OrderModel model)
        {
            model.OrderItems = new List<OrderItemModel>
            {
                new OrderItemModel
                {
                    ProductId = MintSoftConstants.ProductId,
                    Quantity = MintSoftConstants.Quantity
                }
            };
            model.Warehouse = MintSoftConstants.Warehouse;
            model.CourierService = MintSoftConstants.CourierService;
            model.OrderNumber = new Random().Next(1000000).ToString();
            return model;
        }

        private OrderModel TestModel()
        {
            return new OrderModel
            {
                OrderItems = new List<OrderItemModel>
                {
                    new OrderItemModel
                    {
                        ProductId = 10587,
                        Quantity = 1
                    }
                },
                Title = "MR",
                FirstName = "FIRST NAME",
                LastName = "LAST NAME",
                Address1 = "First Line Address",
                Town = "Town or City",
                PostCode = "PostCode or ZipCode",
                Country = "GB",
                Email = "my@email.com",
                Phone = "01245123456",
                CourierService = "DPD Next Day",
                Warehouse = "Main Warehouse",
                Comments = "Please pack in a safe box",
                OrderNumber = "MY ORDER NUMBER"
            };
        }
    }
}