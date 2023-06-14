using AppleShop.Ordering.API.DTOs;
using AppleShop.Ordering.API.Infrastructure.Repository;
using AppleShop.Ordering.API.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppleShop.Ordering.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<OrderDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderRepository.GetAll();

            var result = ApiResponse<IEnumerable<OrderDto>>.Success(orders);

            return Ok(result);
        }

        [HttpGet("getStatistic")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<OrderStatisticDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetStatistic()
        {
            var orders = await _orderRepository.GetStatistic();

            var result = ApiResponse<IEnumerable<OrderStatisticDto>>.Success(orders);

            return Ok(result);
        }
    }
}
