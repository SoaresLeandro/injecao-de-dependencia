using dependencyinjection.Models;
using dependencyinjection.Repositories.Contracts;
using dependencyinjection.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace dependencyinjection.Controllers;

public class OrderController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IPromoCodeRepository _promoCodeRepository;
    private readonly IDeliveryFeeService _deliveryFeeService;

    public OrderController(ICustomerRepository customerRepository, IDeliveryFeeService deliveryFeeService, IPromoCodeRepository promoCodeRepository)
    {
        _customerRepository = customerRepository;
        _deliveryFeeService = deliveryFeeService;
        _promoCodeRepository = promoCodeRepository;
    }

    [Route("v1/orders")]
    [HttpPost]
    public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        if(customer is null)
            return NotFound();

        var deliveryFee = await _deliveryFeeService.GetDeliveryFeeAsync(zipCode);
        var cupon = await _promoCodeRepository.GetPromoCodeAsyc(promoCode);
        var discount = cupon?.Value ?? 0;
        var order = new Order(deliveryFee, discount, new List<Product>());

        var mensagem = $"Pediddo {order.Code} gerado com sucesso!";
        return Ok(mensagem);
    }
}