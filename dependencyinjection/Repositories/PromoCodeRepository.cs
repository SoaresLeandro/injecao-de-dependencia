using Dapper;
using dependencyinjection.Models;
using dependencyinjection.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace dependencyinjection.Repositories;

public class PromoCodeRepository : IPromoCodeRepository
{
    private readonly SqlConnection _sqlConnection;

    public PromoCodeRepository(SqlConnection sqlConnection) => _sqlConnection = sqlConnection;

    public async Task<PromoCode?> GetPromoCodeAsyc(string promoCode)
    {
        var query = $"SELECT * FROM PROMO_CODES WHERE CODE={promoCode}";
        return await _sqlConnection.QueryFirstOrDefaultAsync<PromoCode>(query);
    }
}
