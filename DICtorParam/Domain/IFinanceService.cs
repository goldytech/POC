using System;
using System.Threading.Tasks;
using DICtorParam.Infrastructure;

namespace DICtorParam.Domain
{
    public interface IFinanceService
    {
        Task<Result<string, Exception>> GetFinanceDocumentAsync();
    }
}