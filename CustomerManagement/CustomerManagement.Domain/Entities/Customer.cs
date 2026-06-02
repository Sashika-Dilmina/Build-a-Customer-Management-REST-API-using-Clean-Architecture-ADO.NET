using CustomerManagement.Domain.Enums;

namespace CustomerManagement.Domain.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerCode { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string? Address {  get; set; }
    public DateTime DateOfBirth { get; set; }
    public CustomerType CustomerType { get; set; }
    public string? Email {  get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }

}