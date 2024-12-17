using Dapper;
using dependencyinjection.Models;
using dependencyinjection.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace dependencyinjection.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private SqlConnection _sqlConnection;

    public CustomerRepository(SqlConnection sqlConnection) => _sqlConnection = sqlConnection;

    public async Task<Customer?> GetByIdAsync(string customerId)
    {
        string query = $"SELECT Id, Name, Email FROM Customer WHERE ID = @customerId";

        return await _sqlConnection.QueryFirstOrDefaultAsync<Customer>(query, new {id = customerId});
    }
}