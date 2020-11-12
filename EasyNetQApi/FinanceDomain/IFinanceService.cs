using System.Threading.Tasks;

namespace EasyNetQApi.FinanceDomain
{
    public interface IFinanceService
    {
        Task GenerateDocument();
    }
}