using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pokedex.Api.Dtos;
using Pokedex.Api.Models;
using Pokedex.Api.Utility;

namespace Pokedex.Api.Clients
{
    public class FunnyTranslationClient : IFunnyTranslationClient
    {
        // The Uri of the api to call
        internal static string ApiUrl { get; } = "https://api.funtranslations.com";

        // The endpoint for the yoda translation
        private string YodaTranslationEndPoint { get; } = "/translate/yoda.json";

        // The endpoint for the Shakespear translation
        private string ShakespearTranslationEndPoint { get; } = "/translate/shakespeare.json";

        public IPokemonClient _pokemonClient;

        public FunnyTranslationClient(IPokemonClient pokemonClient)
        {
            _pokemonClient = pokemonClient;
        }

        // GET /
        /// <summary>
        /// Returns pokemon basic information with the Funny
        /// translation as it's description
        /// </summary>
        /// <param name="pokemonName">Name of the pokemon</param>
        /// <returns></returns>
        public async Task<PokemonDto> GetPokemonTranslationAsync(string pokemonName)
        {
            using HttpClient client = new HttpClient();

            // In case i want to use specific TLS protocol
            // ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2

            // In case we want to add something in the header
            // example and authorization key
            // client.DefaultRequestHeaders.Add("key", "value");
            PokemonSpecies pokemonSpecies = await _pokemonClient.GetPokemonAsync(pokemonName);

            if (pokemonSpecies == null)
                return null;

            // Read the first description of the pokemon that is not empty
            PokemonSpeciesFlavorTexts pokemonSpeciesFlavorTexts = pokemonSpecies.FlavorTextEntries
                .FirstOrDefault(x => x.FlavorText != string.Empty);

            if (pokemonSpeciesFlavorTexts == null)
                return null;

            string uri = string.Empty;

            if (pokemonSpecies.Habitat.Name == "cave" || pokemonSpecies.IsLegendary)
                uri = ApiUrl + YodaTranslationEndPoint;
            else
                uri = ApiUrl + ShakespearTranslationEndPoint;

            // adding the text to translate to the querystring
            // removing \n and \f because it prevents from getting the text translated (the translated test is the same as original)
            uri += "?text=" + pokemonSpeciesFlavorTexts.FlavorText.Replace("\n", " ").Replace("\f", " ");

            HttpResponseMessage response = await client.GetAsync(requestUri: uri);

            TranslationApiResponse translationApiResponse;

            // if response is ok convert the content to Dto object
            if (response.IsSuccessStatusCode)
            {
                translationApiResponse = JsonConvert.DeserializeObject<TranslationApiResponse>(await response.Content.ReadAsStringAsync());

                // exchanging the original description with the translation
                return pokemonSpecies.AsDto(translationApiResponse.Contents.Translated);
            }
            else
                return pokemonSpecies.AsDto();


        }

    }
}
