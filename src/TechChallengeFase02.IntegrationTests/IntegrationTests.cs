using Microsoft.AspNetCore.Mvc.Testing;

namespace TechChallengeFase02.IntegrationTests
{
    public class ApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ApiIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            _client.BaseAddress = new Uri("https://fiap-api-f5c7a3duarhhcnfy.eastus2-01.azurewebsites.net"); // Nome do serviço do Docker
        }

        [Fact]
        public async Task Test_GetContacts_ReturnsSuccess()
        {
            var response = await _client.GetAsync("/api/contatos/buscar-todos");  // URL da sua API
            response.EnsureSuccessStatusCode();  // Valida se o status é 200 OK

            var content = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(content); 

            Console.WriteLine("Test_GetContacts_ReturnsSuccess passou com sucesso!");
        }
    }
}