using Bogus;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using ViagemAApp.Tests.Factories;
using ViagemApp.Domain.DTO;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;

namespace ViagemApp.Test
{
    public class CompanhiaAereaTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CompanhiaAereaTest(CustomWebApplicationFactory<Program> factory)
        {
            // Usa o client fornecido pela factory para acessar os endpoints da API
            _client = factory.CreateClient();
        }

        // Método para criar um request fictício (fake) usando Bogus
        private CompanhiaAereaDTOInsert CreateRequest()
        {
            var faker = new Faker("pt_BR");
            return new CompanhiaAereaDTOInsert
            {
                Nome = faker.Company.CompanyName()
            };
        }

        // Método para testar a inserção de uma companhia aérea
        [Fact(DisplayName = "Inclusão da Companhia Aérea")]
        public async Task InclusaoAsync()
        {
            var request = CreateRequest(); // Cria o request usando dados fake
            var response = await _client.PostAsync("api/companhiaAerea", TestHelper.CreateContent(request));

            response.EnsureSuccessStatusCode(); // Verifica se a requisição foi bem-sucedida
            var result = await TestHelper.ReadResponseAsync<CompanhiaAereaDTOResponse>(response);

            result?.Nome.Should().NotBeNullOrEmpty(); // Valida o nome retornado
            result?.Nome.Should().Be(request.Nome); // Valida que o nome retornado é igual ao nome enviado
        }

        // Método para testar a atualização de uma companhia aérea
        [Fact(DisplayName = "Alteração da Companhia Aérea")]
        public async Task AlteracaoAsync()
        {
            var request = CreateRequest(); // Cria o request inicial usando dados fake
            var companhiaAerea = await _client.PostAsync("api/companhiaAerea", TestHelper.CreateContent(request));

            companhiaAerea.EnsureSuccessStatusCode(); // Verifica se a criação foi bem-sucedida
            var createdEntity = await TestHelper.ReadResponseAsync<CompanhiaAereaDTOResponse>(companhiaAerea);

            var requestUpdate = CreateRequest(); // Cria um novo request para atualizar a companhia
            CompanhiaAereaDTOUpdate dto = new CompanhiaAereaDTOUpdate
            {
                Id = createdEntity.Id,
                Nome = requestUpdate.Nome
            };

            var response = await _client.PutAsync("api/companhiaAerea", TestHelper.CreateContent(dto));
            response.EnsureSuccessStatusCode(); // Verifica se a atualização foi bem-sucedida

            var result = await TestHelper.ReadResponseAsync<CompanhiaAereaDTOResponse>(response);
            result?.Nome.Should().NotBeNullOrEmpty(); // Valida o nome retornado
            result?.Nome.Should().Be(requestUpdate.Nome); // Valida que o nome foi atualizado corretamente
        }

        // Método para testar a exclusão de uma companhia aérea
        [Fact(DisplayName = "Exclusão da Companhia Aérea")]
        public async Task ExclusaoAsync()
        {
            var request = CreateRequest(); // Cria o request inicial usando dados fake
            var companhiaAerea = await _client.PostAsync("api/companhiaAerea", TestHelper.CreateContent(request));

            companhiaAerea.EnsureSuccessStatusCode(); // Verifica se a criação foi bem-sucedida
            var createdEntity = await TestHelper.ReadResponseAsync<CompanhiaAereaDTOResponse>(companhiaAerea);

            CompanhiaAereaDTODelete dto = new CompanhiaAereaDTODelete
            {
                Id = createdEntity.Id
            };

            var content = TestHelper.CreateContent(dto);
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, "api/companhiaAerea")
            {
                Content = content
            };

            var response = await _client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode(); // Verifica se a exclusão foi bem-sucedida

            var result = await TestHelper.ReadResponseAsync<CompanhiaAereaDTOResponse>(response);
            result?.Id.Should().Be(createdEntity.Id); // Verifica se o ID retornado é o mesmo que foi criado
        }
    }
}
