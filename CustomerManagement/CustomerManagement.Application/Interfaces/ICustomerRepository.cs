using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Application.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> CreateAsync(Customer customer);
    Task<bool> UpdatedAsync(Customer customer);
    Task<bool> DeleteAsync(int customerId);
    Task<Customer?> GetByIdAsync(int customerId);
    Task<IEnumerable<Customer>> GetAllAsync();
}