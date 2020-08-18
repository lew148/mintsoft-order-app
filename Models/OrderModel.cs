using System.Collections.Generic;

namespace mintsoft_order_app.Models
{
    public class OrderModel : UserDetails
    {
        public IEnumerable<OrderItemModel> OrderItems { get; set; }
        public string Warehouse { get; set; }
        public string CourierService { get; set; }
        public string OrderNumber { get; set; }
    }
}