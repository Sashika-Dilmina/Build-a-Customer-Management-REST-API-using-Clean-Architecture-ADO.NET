using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Domain,Entities;

namespace CustomerManagement.Application.Services;

public class CustomerService : IcustomerService

{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
        => _repository = repository;

    public async Task<CustomerResponseDto?> CreateAsync(CustomerCreateDto dto)
    {
        var entity = new CustomerService
        {
            CustomerName = dto.CustomerName,
            Address = dto.Address,
            DateOfBirth = dto.DateOfBirth,
            CustomerType = dto.CustomerType,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber
        };

        var created = await _repository.CreateAsync(entity);
        return created is null ? null : MapToDto(created);
    }

    public async Task<bool> UpdateAsync(int id, CustomerUpdateDto dto)

    {
        var existing = await _repository.GetAllAsync(id);
        if (existing is null) return false;

        existing.CustomerName = dto.CustomerName;
        existing.Address = dto.Address;
        existing.DateOfBirth = dto.DateOfBirth;
        existing.CustomerType = dto.CustomerType;
        existing.Email = dto.Email;
        existing.PhoneNumber = dto.PhoneNumber;
        existing.IsActive = dto.IsActive;

        return await _repository.UpdateAsync(existing);
    
    }

    public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);

    public async Task<CustomerResponseDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : MapToDto(entity);
    }

    public async Task<IEnumerable<CustomerResponseDto>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        return list.Select(MapToDto);
    }

    private static CustomerResponseDto MapToDto(CustomerManagement c) => new()

    {
        CustomerId = c.CustomerId,
        CustomerCode = c.CustomerCode,
        CustomerName = c.CustomerName,
        Address = c.Address,
        DateOfBirth = c.DateOfBirth,
        CustomerType = c.CustomerType,
        Email = c.Email,
        PhoneNumber = c.PhoneNumber,
        IsActive = c.IsActive,
        CreatedDate = c.CreatedDate,

    };

}