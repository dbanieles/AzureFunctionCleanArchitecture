using Infrastructure.KeyVault;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TemplateServiceName.Service.Api
{
    public class Api
    {
        private readonly ILogger<Api> _logger;

        private readonly IOptions<KeyVaultSecret> _keyVaultSecret;

        public Api(ILogger<Api> logger, IOptions<KeyVaultSecret> keyVaultSecret)
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
