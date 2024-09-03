using System.Threading.Tasks;
using Pokedex.Api.Models;

namespace Pokedex.Api.Clients
{
    public interface IPokemonClient
    {
        /// <summary>
        /// The uri of the api to call
        /// </summary>
        static string ApiUrl { get; }

        /// <summary>
        /// Returns pokemon basic information
        /// </summary>
        /// <param name="pokemonName">Name of the pokemon</param>
        /// <returns></returns>
        Task<PokemonSpecies> GetPokemonAsync(string pokemonName);
    }
}
