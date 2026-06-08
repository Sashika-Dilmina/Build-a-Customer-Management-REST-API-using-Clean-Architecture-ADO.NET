using System.ComponentModel.DataAnnotations;
using CustomerManagement.Domain.Enums;
using CustomerManagement.Application.Validation;

namespace CustomerManagement.Application.DTOs;

public class CustomerUpdateDto
{
    [Required, StringLength(150)]
    public string CustomerName { get; set; } = string.Empty;

    [StringLength(250)]
    public string? Address { get; set; }

    [Required]
    [DateNotInFuture]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public CustomerType CustomerType { get; set; }

    [EmailAddress, StringLength(150)]
    public string? Email {  get; set; }

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    public bool IsActive { get; set; } = true;
}