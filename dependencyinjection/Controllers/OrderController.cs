using dependencyinjection.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace dependencyinjection.Controllers;

public class OrderController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public OrderController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [Route("v1/orders")]
    [HttpPost]
    public async Task<IActionResult> Place(string customerId)
    {
        var customer = _customerRepository.GetByIdAsync(customerId);

        if(customer is null)
            return NotFound();

        return Ok();
    }
}