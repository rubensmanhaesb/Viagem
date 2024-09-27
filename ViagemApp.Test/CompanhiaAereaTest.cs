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

        // M�todo para criar um request fict�cio (fake) usando Bogus
        private CompanhiaAereaDTOInsert CreateRequest()
        {
            var faker = new Faker("pt_BR");
            return new CompanhiaAereaDTOInsert
            {
                Nome = faker.Company.CompanyName()
            };
        }

        // M�todo para testar a inser��o de uma companhia a�rea
        [Fact(DisplayName = "Inclus�o da Companhia A�rea")]
        public async Task InclusaoAsync()
        {
            var request = CreateRequest(); // Cria o request usando dados fake
            var response = await _client.PostAsync("api/companhiaAerea", TestHelper.CreateContent(request));

            response.EnsureSuccessStatusCode(); // Verifica se a requisi��o foi bem-sucedida
            var result = await TestHelper.ReadResponseAsync<CompanhiaAereaDTOResponse>(response);

            result?.Nome.Should().NotBeNullOrEmpty(); // Valida o nome retornado
            result?.Nome.Should().Be(request.Nome); // Valida que o nome retornado � igual ao nome enviado
        }

        // M�todo para testar a atualiza��o de uma companhia a�rea
        [Fact(DisplayName = "Altera��o da Companhia A�rea")]
        public async Task AlteracaoAsync()
        {
            var request = CreateRequest(); // Cria o request inicial usando dados fake
            var companhiaAerea = await _client.PostAsync("api/companhiaAerea", TestHelper.CreateContent(request));

            companhiaAerea.EnsureSuccessStatusCode(); // Verifica se a cria��o foi bem-sucedida
            var createdEntity = await TestHelper.ReadResponseAsync<CompanhiaAereaDTOResponse>(companhiaAerea);

            var requestUpdate = CreateRequest(); // Cria um novo request para atualizar a companhia
            CompanhiaAereaDTOUpdate dto = new CompanhiaAereaDTOUpdate
            {
                Id = createdEntity.Id,
                Nome = requestUpdate.Nome
            };

            var response = await _client.PutAsync("api/companhiaAerea", TestHelper.CreateContent(dto));
            response.EnsureSuccessStatusCode(); // Verifica se a atualiza��o foi bem-sucedida

            var result = await TestHelper.ReadResponseAsync<CompanhiaAereaDTOResponse>(response);
            result?.Nome.Should().NotBeNullOrEmpty(); // Valida o nome retornado
            result?.Nome.Should().Be(requestUpdate.Nome); // Valida que o nome foi atualizado corretamente
        }

        // M�todo para testar a exclus�o de uma companhia a�rea
        [Fact(DisplayName = "Exclus�o da Companhia A�rea")]
        public async Task ExclusaoAsync()
        {
            var request = CreateRequest(); // Cria o request inicial usando dados fake
            var companhiaAerea = await _client.PostAsync("api/companhiaAerea", TestHelper.CreateContent(request));

            companhiaAerea.EnsureSuccessStatusCode(); // Verifica se a cria��o foi bem-sucedida
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
            response.EnsureSuccessStatusCode(); // Verifica se a exclus�o foi bem-sucedida

            var result = await TestHelper.ReadResponseAsync<CompanhiaAereaDTOResponse>(response);
            result?.Id.Should().Be(createdEntity.Id); // Verifica se o ID retornado � o mesmo que foi criado
        }
    }
}
