using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>Database model</summary>
public class DbOrder
{
    public DbOrder() {}

    public DbOrder(ApiOrder order)
    {
        CustomerName = order.CustomerName;
        PhoneNumber = order.PhoneNumber;
        Email = order.Email;
        BikeBrand = order.BikeBrand;
        ServiceType = order.ServiceType;
        DueDate = order.DueDate;
        Notes = order.Notes;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BikeBrand { get; set; }
    public string ServiceType { get; set; }
    public DateTime DueDate { get; set; }
    public string? Notes { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsCompleted { get; set; } = false;
}

/// <summary>Query response model</summary>
public class QueryOrder
{
    public QueryOrder(DbOrder order)
    {
        Id = order.Id;
        CustomerName = order.CustomerName;
        PhoneNumber = order.PhoneNumber;
        Email = order.Email;
        BikeBrand = order.BikeBrand;
        ServiceType = order.ServiceType;
        DueDate = order.DueDate;
        Notes = order.Notes;
        IsDeleted = order.IsDeleted;
        IsCompleted = order.IsCompleted;
    }

    public Guid Id { get; set; }
    /// <example>Hanna Engen</example>
    public string CustomerName { get; set; }
    /// <example>91021684</example>
    public string PhoneNumber { get; set; }
    /// <example>hanna.engen@outlook.com</example>
    public string Email { get; set; }
    /// <example>Hutch BMX</example>
    public string BikeBrand { get; set; }
    /// <example>Chain replacement</example>
    public string ServiceType { get; set; }
    public DateTime DueDate { get; set; }
    /// <example>The chain broke</example>
    public string? Notes { get; set; }
    /// <example>false</example>
    public bool IsDeleted { get; set; }
    /// <example>false</example>
    public bool IsCompleted { get; set; }
}

/// <summary>Create model</summary>
public class ApiOrder
{
    public ApiOrder() {}

    /// <example>Aksel Solberg</example>
    public string CustomerName { get; set; }
    /// <example>97622371</example>
    public string PhoneNumber { get; set; }
    /// <example>aksel.solberg@outlook.com</example>
    public string Email { get; set; }
    /// <example>Ridley</example>
    public string BikeBrand { get; set; }
    /// <example>Brake Maintenance</example>
    public string ServiceType { get; set; }
    public DateTime DueDate { get; set; }
    /// <example>Brakes are ineffective</example>
    public string? Notes { get; set; }
}
