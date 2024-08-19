using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace ABikeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{

    private readonly ILogger<OrdersController> _logger;
    private readonly OrderContext _context;

    public OrdersController(ILogger<OrdersController> logger, OrderContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetOrders")]
    public IEnumerable<Order> Get()
    {
        return _context.Orders.Where(o => !o.IsCompleted && !o.IsDeleted).ToList();
    }

    [HttpPost(Name = "CreateOrder")]
    public IActionResult Create(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
        return Ok(order);
    }

    [HttpGet("{id}", Name = "GetOrder")]
    public IActionResult Get(Guid id)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }
}
