using System.Data;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Enums;
using CustomerManagement.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace CustomerManagement.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDbConnectionFactory _factory;

    public CustomerRepository(IDbConnectionFactory factory) => _factory = factory;

    public async Task<Customer?> CreateAsync(Customer customer)
    {
        using var connection = _factory.CreateConnection();
        using var command = new SqlCommand("dbo.usp_Customer_Insert", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
        command.Parameters.AddWithValue("@Address", (object?)customer.Address ?? DBNull.Value);
        command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
        command.Parameters.AddWithValue("@CustomerType", (byte)customer.CustomerType);
        command.Parameters.AddWithValue("@Email", (object?)customer.Email ?? DBNull.Value);
        command.Parameters.AddWithValue("@PhoneNumber", (object?)customer.PhoneNumber ?? DBNull.Value);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        return await reader.ReadAsync() ? MapToCustomer(reader) : null;
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
        using var connection = _factory.CreateConnection();
        using var command = new SqlCommand("dbo.usp_Customer_Update", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
        command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
        command.Parameters.AddWithValue("@Address", (object?)customer.Address ?? DBNull.Value);
        command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
        command.Parameters.AddWithValue("@CustomerType", (byte)customer.CustomerType);
        command.Parameters.AddWithValue("@Email", (object?)customer.Email ?? DBNull.Value);
        command.Parameters.AddWithValue("@PhoneNumber", (object?)customer.PhoneNumber ?? DBNull.Value);
        command.Parameters.AddWithValue("@IsActive", customer.IsActive);

        await connection.OpenAsync();
        var result = await command.ExecuteScalarAsync();  
        return result is not null && Convert.ToInt32(result) > 0;
    }

    public async Task<bool> DeleteAsync(int customerId)
    {
        using var connection = _factory.CreateConnection();
        using var command = new SqlCommand("dbo.usp_Customer_Delete", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.AddWithValue("@CustomerId", customerId);

        await connection.OpenAsync();
        var result = await command.ExecuteScalarAsync();
        return result is not null && Convert.ToInt32(result) > 0;
    }

    public async Task<Customer?> GetByIdAsync(int customerId)
    {
        using var connection = _factory.CreateConnection();
        using var command = new SqlCommand("dbo.usp_Customer_GetById", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.AddWithValue("@CustomerId", customerId);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        return await reader.ReadAsync() ? MapToCustomer(reader) : null;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customers = new List<Customer>();

        using var connection = _factory.CreateConnection();
        using var command = new SqlCommand("dbo.usp_Customer_GetAll", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
            customers.Add(MapToCustomer(reader));

        return customers;
    }

    private static Customer MapToCustomer(SqlDataReader reader) => new()
    {
        CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
        CustomerCode = reader.GetString(reader.GetOrdinal("CustomerCode")),
        CustomerName = reader.GetString(reader.GetOrdinal("CustomerName")),
        Address = reader["Address"] as string,
        DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
        CustomerType = (CustomerType)reader.GetByte(reader.GetOrdinal("CustomerType")),
        Email = reader["Email"] as string,
        PhoneNumber = reader["PhoneNumber"] as string,
        IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
        CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"))
    };
}