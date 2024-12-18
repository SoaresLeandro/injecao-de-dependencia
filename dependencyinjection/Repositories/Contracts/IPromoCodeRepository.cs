using dependencyinjection.Models;

namespace dependencyinjection.Repositories.Contracts;

public interface IPromoCodeRepository
{
    Task<PromoCode?> GetPromoCodeAsyc(string promoCode);
}