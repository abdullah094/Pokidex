using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Api.Dtos;
using Pokedex.Api.Models;
using Pokedex.Api.Clients;
using Pokedex.Api.Utility;

namespace Pokedex.Api.Controllers
{
    [ApiController]
    [Route("api/v1/pokemon")]
    public class PokemonController : ControllerBase
    {
        private IPokemonClient _pokemonPublicApi;
        private IFunnyTranslationClient _funnyTranslationPublicApi;

        public PokemonController(IPokemonClient pokemonPublicApi, IFunnyTranslationClient funnyTranslationPublicApi)
        {
            _funnyTranslationPublicApi = funnyTranslationPublicApi;
            _pokemonPublicApi = pokemonPublicApi;
        }

        // GET api/v1/pokemon/{pokemonName}
        /// <summary>
        /// Gets the basic pokemon Information
        /// </summary>
        /// <param name="pokemonName">pokemon Name</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{pokemonName}")]
        public async Task<ActionResult<PokemonDto>> GetPokemon(string pokemonName)
        {
            if (string.IsNullOrEmpty(pokemonName))
                return BadRequest();

            PokemonSpecies pokemonSpecies = await _pokemonPublicApi.GetPokemonAsync(pokemonName);

            if (pokemonSpecies == null)
                return NotFound();

            return pokemonSpecies.AsDto();

        }

        // GET api/v1/pokemon/translation/{pokemonName}
        /// <summary>
        /// Translated Pokemon Description based on habitat
        /// </summary>
        /// <param name="pokemonName">pokemon Name</param>
        /// <returns></returns>
        [HttpGet]
        [Route("translation/{pokemonName}")]
        public async Task<ActionResult<PokemonDto>> GetPokemonTranslation(string pokemonName)
        {
            if (string.IsNullOrEmpty(pokemonName))
                return BadRequest();

            PokemonDto pokemonDto = await _funnyTranslationPublicApi.GetPokemonTranslationAsync(pokemonName);

            if (pokemonDto == null)
                return NotFound();

            return pokemonDto;
        }
    }
}
