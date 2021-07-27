using Moq;
using PokeApiNet;
using PokemonExcercise.Concretes;
using PokemonExcercise.Interfaces;
using PokemonExcercise.Models;
using Xunit;
using Language = PokemonExcercise.Enumerations.Language;

namespace PokemonExcercise.Tests
{
    public class TranslationServiceTests
    {
        private TranslationResponse testTranslationResponse = new TranslationResponse
        {
            Success = new SuccessContents { Total = 1 },
            Contents = new TranslationContents { Translated = "" }
        };

        [Theory]
        [InlineData(true, "urban", Language.Yoda)]
        [InlineData(false, "cave", Language.Yoda)]
        [InlineData(false, "urban", Language.Shakespeare)]
        public async void GetTranslatedDescription_UsesCorrectTranslator(bool isLegendary, string habitat, Language expectedTargetLanguage)
        {
            var mockTranslationClient = new Mock<ITranslationClient>();
            mockTranslationClient.Setup(x => x.Translate(It.IsAny<Language>(), It.IsAny<string>()))
                .ReturnsAsync(testTranslationResponse);

            var service = new TranslationService(mockTranslationClient.Object);

            var species = new PokemonSpecies { IsLegendary = isLegendary, Habitat = new NamedApiResource<PokemonHabitat> { Name = habitat } };

            await service.GetTranslatedDescription(species, "test");

            mockTranslationClient.Verify(x => x.Translate(It.IsAny<Language>(), It.IsAny<string>()), Times.Once);
            mockTranslationClient.Verify(x => x.Translate(expectedTargetLanguage, It.IsAny<string>()), Times.Once);
        }
    }
}
