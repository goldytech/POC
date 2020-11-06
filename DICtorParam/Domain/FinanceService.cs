using System;
using System.Threading.Tasks;
using DICtorParam.Infrastructure;
using DICtorParam.Models;
using Microsoft.Extensions.Options;

namespace DICtorParam.Domain
{
   public class FinanceService : IFinanceService
    {
        private readonly string _accountId;

        public FinanceService(IOptions<FinanceServiceOptions> financeServiceOptions)
        {
            _accountId = financeServiceOptions.Value.AccountId;
        }

        /// <inheritdoc />
        public Task<Result<string, Exception>> GetFinanceDocumentAsync()
        {
            return Task.FromResult(Result<string, Exception>.SucceedWith($"{_accountId} => {DocumentId.New()}"));
        }
    }
}