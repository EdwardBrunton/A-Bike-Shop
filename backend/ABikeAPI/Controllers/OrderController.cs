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

    /// <summary>
    /// Retrieve all orders in the database.
    /// </summary>
    /// <response code="200">Success</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet(Name = "GetOrders")]
    public IEnumerable<QueryOrder> Get()
    {
        return _context.Orders.Where(o => !o.IsCompleted && !o.IsDeleted).ToList().Select(o => new QueryOrder(o));
    }

    /// <summary>
    /// Create a new Order.
    /// </summary>
    /// <response code="200">Success</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "CreateOrder")]
    public IActionResult Create(ApiOrder order)
    {
        var newOrder = new DbOrder(order);
        _context.Orders.Add(newOrder);
        _context.SaveChanges();
        return Ok(newOrder);
    }

    /// <summary>
    /// Retrieve a specific order.
    /// </summary>
    /// <response code="200">Success</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet("{id}", Name = "GetOrder")]
    public IActionResult Get(Guid id)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(new QueryOrder(order));
    }
}
