using Moq;
using PokeApiNet;
using PokemonExcercise.Concretes;
using PokemonExcercise.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace PokemonExcercise.Tests
{
    public class PokemonServiceTests
    {
        private readonly PokemonSpecies testSpecies = new PokemonSpecies
        {
            FlavorTextEntries = new List<PokemonSpeciesFlavorTexts>
            {
                new PokemonSpeciesFlavorTexts
                {
                    Language = new NamedApiResource<Language> { Name = "en" },
                    FlavorText = ""
                }
            }
        };

        private readonly Mock<IPokeApiClient> mockPokeApiClient;
        private readonly Mock<ITranslationService> mockTranslationService;

        public PokemonServiceTests()
        {
            mockPokeApiClient = new Mock<IPokeApiClient>();
            mockPokeApiClient.Setup(x => x.GetPokemonSpeciesByName(It.IsAny<string>()))
                .ReturnsAsync(testSpecies);

            mockTranslationService = new Mock<ITranslationService>();
        }

        [Fact]
        public async void Get_WhenTranslateDescriptionFalse_DoesntCallTranslationService()
        {
            await Service.Get("test");

            mockTranslationService.Verify(x => x.GetTranslatedDescription(It.IsAny<PokemonSpecies>(), It.IsAny<string>()), Times.Never);
        }

        public PokemonService Service => new PokemonService(mockPokeApiClient.Object, mockTranslationService.Object);

        [Fact]
        public async void GetTranslated_WhenTranslateDescriptionTrue_CallsTranslationService()
        {
            await Service.GetTranslated("test");

            mockTranslationService.Verify(x => x.GetTranslatedDescription(It.IsAny<PokemonSpecies>(), It.IsAny<string>()), Times.Once);
        }
    }
}
