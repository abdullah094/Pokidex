using System.Linq;
using Pokedex.Api.Dtos;
using Pokedex.Api.Models;

namespace Pokedex.Api.Utility
{
    public static class Extensions
    {
        public static PokemonDto AsDto(this PokemonSpecies pokemon)
        {
            PokemonSpeciesFlavorTexts pokemonSpeciesFlavorTexts = pokemon.FlavorTextEntries
            .FirstOrDefault();

            return new PokemonDto
            {
                Name = pokemon.Name,
                Description = (pokemonSpeciesFlavorTexts != null) ? pokemonSpeciesFlavorTexts.FlavorText : string.Empty,
                Habitat = pokemon.Habitat.Name,
                IsLegendary = pokemon.IsLegendary
            };
        }

        public static PokemonDto AsDto(this PokemonSpecies pokemon, string translatedDescription)
        {
            return new PokemonDto
            {
                Name = pokemon.Name,
                Description = translatedDescription,
                Habitat = pokemon.Habitat.Name,
                IsLegendary = pokemon.IsLegendary
            };
        }
    }
}
