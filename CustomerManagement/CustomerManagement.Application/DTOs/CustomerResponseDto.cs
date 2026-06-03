using CustomerManagement.Domain.Enums;

namespace CustomerManagement.Application.DTOs;

public class CustomerResponseDto
{
    public int CustomerId { get; set; }
    public string CustomerCode { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string? Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public CustomerType CustomerType { get; set; }
    public string CustomerTypeName => CustomerType.ToString();
    public string? Email {  get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate {  get; set; }
}

