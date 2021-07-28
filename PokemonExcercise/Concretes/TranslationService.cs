using PokeApiNet;
using PokemonExcercise.Interfaces;
using System.Threading.Tasks;

namespace PokemonExcercise.Concretes
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationClient translatorClient;

        public TranslationService(ITranslationClient translatorClient)
        {
            this.translatorClient = translatorClient;
        }

        public async Task<string> GetTranslatedDescription(PokemonSpecies species, string description)
        {
            var targetLanguage = species.Habitat.Name == "cave" || species.IsLegendary
                ? Enumerations.Language.Yoda
                : Enumerations.Language.Shakespeare;

            var translation = await translatorClient.Translate(description, targetLanguage);

            return translation.Success.Total > 0
                ? translation.Contents.Translated
                : description;
        }
    }
}
