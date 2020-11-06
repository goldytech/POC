using System;
using System.Threading.Tasks;
using DICtorParam.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DICtorParam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {
        private IFinanceService _financeService;
       private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IOptions<FinanceServiceOptions> _financeServiceOptions;

       public FinanceController(IServiceProvider serviceProvider, IOptions<FinanceServiceOptions> financeServiceOptions, ILoggerFactory loggerFactory)
        {
            //    _logger = logger;
            _serviceProvider = serviceProvider;
            _financeServiceOptions = financeServiceOptions;
            _logger = loggerFactory.CreateLogger<FinanceService>();
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetDocument(string accountId)
        {

            _logger.LogInformation(accountId);
            _financeServiceOptions.Value.AccountId = accountId;
            _financeService = _serviceProvider.GetRequiredService<IFinanceService>();
            var result = await _financeService.GetFinanceDocumentAsync();
          //  
            return Ok(result.SuccessValue);
        }
    }
}
