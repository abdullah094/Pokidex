using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pokedex.Api.Models;

namespace Pokedex.Api.Clients
{
    public class PokemonClient : IPokemonClient
    {
        // The Uri of the api to call
        internal static string ApiUrl { get; } = "https://pokeapi.co/api/v2";

        // The endpoint to get the information needed
        private string PokemonSpecesEndPoint { get; } = "/pokemon-species/";

        public async Task<PokemonSpecies> GetPokemonAsync(string pokemonName)
        {
            using HttpClient client = new HttpClient();
            string uri = ApiUrl + PokemonSpecesEndPoint + pokemonName;

            // In case i want to use specific TLS protocol
            // ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2

            // In case we want to add somethis in the header
            // example and authorization key
            // client.DefaultRequestHeaders.Add("key", "value");

            PokemonSpecies pokemonSpecies = null;
            HttpResponseMessage response = await client.GetAsync(requestUri: uri);

            // if response is ok convert the content to Dto object
            if (response.IsSuccessStatusCode)
                pokemonSpecies = JsonConvert.DeserializeObject<PokemonSpecies>(await response.Content.ReadAsStringAsync());

            return pokemonSpecies;
        }
    }
}