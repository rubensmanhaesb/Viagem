using Bogus;
using FluentAssertions;
using ViagemAApp.Tests.Factories;
using ViagemApp.Application.DTO;


namespace ViagemApp.Test
{
    public class ProgramaFidelidadeTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProgramaFidelidadeTest(CustomWebApplicationFactory<Program> factory)
        {
            // Usa o client fornecido pela factory para acessar os endpoints da API
            _client = factory.CreateClient();
        }

        // Método para criar um request fictício (fake) usando Bogus
        private ProgramaFidelidadeDTOInsert CreateRequest()
        {
            var faker = new Faker("pt_BR");
            return new ProgramaFidelidadeDTOInsert
            {
                Nome = faker.Company.CompanyName()
            };
        }

        // Método para testar a inserção de uma companhia aérea
        [Fact(DisplayName = "Inclusão do Programa de Fidelidade")]
        public async Task InclusaoAsync()
        {
            var request = CreateRequest(); // Cria o request usando dados fake
            var response = await _client.PostAsync("api/programafidelidade", TestHelper.CreateContent(request));

            response.EnsureSuccessStatusCode(); // Verifica se a requisição foi bem-sucedida
            var result = await TestHelper.ReadResponseAsync<ProgramaFidelidadeDTOResponse>(response);

            result?.Nome.Should().NotBeNullOrEmpty(); // Valida o nome retornado
            result?.Nome.Should().Be(request.Nome); // Valida que o nome retornado é igual ao nome enviado
        }

        // Método para testar a atualização de uma companhia aérea
        [Fact(DisplayName = "Alteração do Programa de Fidelidade")]
        public async Task AlteracaoAsync()
        {
            var request = CreateRequest(); // Cria o request inicial usando dados fake
            var programaFidelidade = await _client.PostAsync("api/programafidelidade", TestHelper.CreateContent(request));

            programaFidelidade.EnsureSuccessStatusCode(); // Verifica se a criação foi bem-sucedida
            var createdEntity = await TestHelper.ReadResponseAsync<ProgramaFidelidadeDTOResponse>(programaFidelidade);

            var requestUpdate = CreateRequest(); // Cria um novo request para atualizar a companhia
            ProgramaFidelidadeDTOUpdate dto = new ProgramaFidelidadeDTOUpdate
            {
                Id = createdEntity.Id,
                Nome = requestUpdate.Nome
            };

            var response = await _client.PutAsync("api/programafidelidade", TestHelper.CreateContent(dto));
            response.EnsureSuccessStatusCode(); // Verifica se a atualização foi bem-sucedida

            var result = await TestHelper.ReadResponseAsync<CompanhiaAereaDTOResponse>(response);
            result?.Nome.Should().NotBeNullOrEmpty(); // Valida o nome retornado
            result?.Nome.Should().Be(requestUpdate.Nome); // Valida que o nome foi atualizado corretamente
        }

        // Método para testar a exclusão de uma companhia aérea
        [Fact(DisplayName = "Exclusão do Programa de Fidelidade")]
        public async Task ExclusaoAsync()
        {
            var request = CreateRequest(); // Cria o request inicial usando dados fake
            var proramaFidelidade = await _client.PostAsync("api/programafidelidade", TestHelper.CreateContent(request));

            proramaFidelidade.EnsureSuccessStatusCode(); // Verifica se a criação foi bem-sucedida
            var createdEntity = await TestHelper.ReadResponseAsync<ProgramaFidelidadeDTOResponse>(proramaFidelidade);

            CompanhiaAereaDTODelete dto = new CompanhiaAereaDTODelete
            {
                Id = createdEntity.Id
            };

            var content = TestHelper.CreateContent(dto);
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, "api/programafidelidade")
            {
                Content = content
            };

            var response = await _client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode(); // Verifica se a exclusão foi bem-sucedida

            var result = await TestHelper.ReadResponseAsync<ProgramaFidelidadeDTOResponse>(response);
            result?.Id.Should().Be(createdEntity.Id); // Verifica se o ID retornado é o mesmo que foi criado
        }
    }
}
