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

        public PokemonService Service => new PokemonService(mockPokeApiClient.Object, mockTranslationService.Object);

        [Fact]
        public async void GetByName_WhenTranslateDescriptionTrue_CallsTranslationService()
        {
            await Service.GetByName("test", true);

            mockTranslationService.Verify(x => x.GetTranslatedDescription(It.IsAny<PokemonSpecies>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async void GetByName_WhenTranslateDescriptionFalse_DoesntCallTranslationService()
        {
            await Service.GetByName("test", false);

            mockTranslationService.Verify(x => x.GetTranslatedDescription(It.IsAny<PokemonSpecies>(), It.IsAny<string>()), Times.Never);
        }
    }
}
