using System.ComponentModel.DataAnnotations;
using CustomerManagement.Domain.Enums;

namespace CustomerManagement.Application.DTOs;

public class CustomerCreateDto
{
    [Required, StringLength(150)]
    public string CustomerName { get; set; } = string.Empty;

    [StringLength(250)]
    public string? Address { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public CustomerType {  get; set; }

    [EmailAddress, StringLength(150)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? PhoneNumber { get; set; }
}