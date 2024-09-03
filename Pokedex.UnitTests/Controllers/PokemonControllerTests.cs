using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pokedex.Api.Clients;
using Pokedex.Api.Controllers;
using Pokedex.Api.Dtos;
using Xunit;

namespace Pokedex.UnitTests.Controllers
{
    public class PokemonControllerTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task GetPokemon_pokemonNameEmptyOrNull_ExpectedBadRequest(string pokemonName)
        {
            //Arrange
            var pokemonClientStub = new Mock<IPokemonClient>();
            var funnyTranslationStub = new Mock<IFunnyTranslationClient>();

            var controller = new PokemonController(pokemonClientStub.Object, funnyTranslationStub.Object);

            //Act
            var result = await controller.GetPokemon(pokemonName);

            //Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Theory]
        [InlineData("mewthree")]
        [InlineData("piqaciu")]
        [InlineData("bulbsor")]
        public async Task GetPokemon_pokemonNameWithRandomCaracters_ExpectedNotFound(string pokemonName)
        {
            //Arrange
            var pokemonClientStub = new Mock<IPokemonClient>();
            var funnyTranslationStub = new Mock<IFunnyTranslationClient>();

            var controller = new PokemonController(pokemonClientStub.Object, funnyTranslationStub.Object);
            
            //Act
            var result = await controller.GetPokemon(pokemonName);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        /*[Theory]
        [InlineData("mewtwo")]
        [InlineData("pikachu")]
        [InlineData("ditto")]
        public async Task GetPokemon_pokemonNameWithPkemonNames_ExpectedFound(string pokemonName)
        {
            //Arrange
            var pokemonClientStub = new Mock<IPokemonClient>();
            var funnyTranslationStub = new Mock<IFunnyTranslationClient>();

            var controller = new PokemonController(pokemonClientStub.Object, funnyTranslationStub.Object);

            //Act
            var result = await controller.GetPokemon(pokemonName);

            //Assert
            Assert.IsType<PokemonDto>(result.Value);
        }*/

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task GetPokemonTranslation_pokemonNameEmptyOrNull_ExpectedBadRequest(string pokemonName)
        {
            //Arrange
            var pokemonClientStub = new Mock<IPokemonClient>();
            var funnyTranslationStub = new Mock<IFunnyTranslationClient>();

            var controller = new PokemonController(pokemonClientStub.Object, funnyTranslationStub.Object);

            //Act
            var result = await controller.GetPokemon(pokemonName);

            //Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Theory]
        [InlineData("mewthree")]
        [InlineData("piqaciu")]
        [InlineData("bulbsor")]
        public async Task GetPokemonTranslation_pokemonNameWithRandomCaracters_ExpectedNotFound(string pokemonName)
        {
            //Arrange
            var pokemonClientStub = new Mock<IPokemonClient>();
            var funnyTranslationStub = new Mock<IFunnyTranslationClient>();

            var controller = new PokemonController(pokemonClientStub.Object, funnyTranslationStub.Object);

            //Act
            var result = await controller.GetPokemon(pokemonName);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        /*[Theory]
        [InlineData("mewtwo")]
        [InlineData("pikachu")]
        [InlineData("ditto")]
        public async Task GetPokemonTranslation_pokemonNameWithPkemonNames_ExpectedFound(string pokemonName)
        {
            //Arrange
            var pokemonClientStub = new Mock<IPokemonClient>();
            var funnyTranslationStub = new Mock<IFunnyTranslationClient>();

            var controller = new PokemonController(pokemonClientStub.Object, funnyTranslationStub.Object);

            //Act
            var result = await controller.GetPokemon(pokemonName);

            //Assert
            Assert.IsType<PokemonDto>(result.Value);
        }*/
    }
}