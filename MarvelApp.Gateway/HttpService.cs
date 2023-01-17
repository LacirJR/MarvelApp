using MarvelApp.Gateway.Interfaces;
using MarvelApp.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace MarvelApp.Gateway
{
    public class HttpService : IHttpService
    {
        
        public async Task<Characters> GetCharacters()
        {
            HttpClient client = new();
            HttpRequestMessage request = new(HttpMethod.Get, $"{Configuration.MarvelEndpoint}{Configuration.Get_CharacterEndpoint}{Authorization.StringParams}");
            var response = await client.SendAsync( request );
            var result =  response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode && result == null)
                throw new InvalidOperationException("Não foi possivel realizar a busca pelos personagens.");


            return JsonConvert.DeserializeObject<Characters>(result);
        }
    }
}
