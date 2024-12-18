using dependencyinjection.Services.Contracts;
using RestSharp;

namespace dependencyinjection.Services;

public class DeliveryFeeService : IDeliveryFeeService
{
    public async Task<decimal> GetDeliveryFeeAsync(string zipCode)
    {
        var client = new RestClient("");
        var request = new RestRequest().AddJsonBody(new { zipCode = zipCode });

        var response = await client.PostAsync<decimal>(request);

        return response <= 5 ? 5 : response;
    }
}