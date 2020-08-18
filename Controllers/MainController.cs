using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mintsoft_order_app.Models;
using mintsoft_order_app.Services;

namespace mintsoft_order_app.Controllers
{
    [ApiController]
    [Route("/api")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ICountryService countryService;

        public OrderController(IOrderService orderService, ICountryService countryService)
        {
            this.orderService = orderService;
            this.countryService = countryService;
        }

        [HttpPost]
        [Route("order")]
        public void Order([FromForm] UserDetails request) => orderService.Order(request);

        [HttpGet]
        [Route("countries")] 
        public IEnumerable<string> GetAllCountries() => countryService.GetAllCountries();
    }
}