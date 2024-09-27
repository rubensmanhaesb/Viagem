using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ViagemApp.Test
{
    public static class TestHelper
    {
        /// <summary>
        /// Método para serializar os dados que serão enviados para um endpoint da API
        /// </summary>
        public static StringContent CreateContent<T>(T obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Método para deserializar a resposta da API de forma assíncrona
        /// </summary>
        public static async Task<T?> ReadResponseAsync<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
