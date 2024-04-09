using Infrastructure.KeyVault;
using Infrastructure.KeyVault.Dto;
using Infrastructure.KeyVault.Impl;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzureFunctionCleanArchitetture
{
    public class Api
    {
        private readonly ILogger<Api> _logger;

        private readonly IOptions<KeyVaultDto> _keyVaultSecret;

        public Api(ILogger<Api> logger, IOptions<KeyVaultDto> keyVaultSecret)
        {
            _logger = logger;
            _keyVaultSecret = keyVaultSecret;
        }

        [Function("Function1")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            Console.WriteLine($"Secret Name: {_keyVaultSecret.Value.ConnectionString}");
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
