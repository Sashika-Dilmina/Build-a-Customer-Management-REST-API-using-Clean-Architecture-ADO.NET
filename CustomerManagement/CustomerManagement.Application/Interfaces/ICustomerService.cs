using CustomerManagement.Application.DTOs;

namespace CustomerManagement.Application.Interfaces;

public interface ICustomerService
{
    Task<CustomerResponseDto?> CreateAsync(CustomerCreateDto dto);
    Task<bool> UpdateAsync(int id, CustomerUpdateDto dto);
    Task<bool> DeleteAsync(int id);
    Task<CustomerResponseDto?> GetByIdAsync(int id);
    Task<IEnumerable<CustomerResponseDto>> GetAllAsync();
}