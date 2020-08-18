using System;
using System.Collections.Generic;
using System.Linq;
using mintsoft_order_app.Models;
using Newtonsoft.Json;

namespace mintsoft_order_app.Services
{
    public interface IOrderService
    {
        bool Order(UserDetails request);
    }

    public class OrderService : IOrderService
    {
        public bool Order(UserDetails request)
        {
            var order = ConstructModelFromRequest(request);
            AddNonUserFacingDetails(order);
            var response = ApiHelper.SendOrderToMintSoftApi(order);
            var responseObject = JsonConvert.DeserializeObject<IEnumerable<ApiResponse>>(response);
            return responseObject.First().Success == "true";
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

        private static void AddNonUserFacingDetails(OrderModel model)
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
        }
    }
}