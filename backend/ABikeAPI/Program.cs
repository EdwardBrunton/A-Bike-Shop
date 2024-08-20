using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ABikeApi", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Development",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                          policy.WithOrigins("http://127.0.0.1:3000").AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<OrderContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await LoadInitialOrders(app);

app.Run();

static async Task LoadInitialOrders(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<OrderContext>();
    if (!db.Orders.Any())
    {
        List<DbOrder> orders =
        [
            new DbOrder {
                CustomerName = "Oliver Johansen",
                PhoneNumber = "98062910",
                Email = "oliver.johanson@gmail.com",
                BikeBrand = "Ridley",
                ServiceType = "Brake maintenance",
                DueDate = new DateTime(2024, 9, 21),
                Notes = "Brakes are squeaky",
            },
            new DbOrder {
                CustomerName = "Hanna Engen",
                PhoneNumber = "91021684",
                Email = "hanna.engen@outlook.com",
                BikeBrand = "Hutch BMX",
                ServiceType = "Chain replacement",
                DueDate = new DateTime(2024, 9, 27),
            },
            new DbOrder {
                CustomerName = "Malin Dahl",
                PhoneNumber = "96814187",
                Email = "malin.dahl@gmail.com",
                BikeBrand = "Whippet",
                ServiceType = "Wheel adjustment",
                DueDate = new DateTime(2024, 9, 25),
                Notes = "Front wheel is off balance",
            },
        ];
        db.Orders.AddRange(orders);
        await db.SaveChangesAsync();
    }
}
