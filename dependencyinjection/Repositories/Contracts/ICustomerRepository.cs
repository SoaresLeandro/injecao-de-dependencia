using dependencyinjection.Models;

namespace dependencyinjection.Repositories.Contracts;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(string customerId);
}