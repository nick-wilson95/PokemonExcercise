using PokeApiNet;
using PokemonExcercise.Enumerations;
using PokemonExcercise.Interfaces;
using PokemonExcercise.Models;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokemonExcercise.Concretes
{
    public class PokemonService : IPokemonService
    {
        private readonly ITranslatorClient translatorClient;

        public PokemonService(ITranslatorClient translatorClient)
        {
            this.translatorClient = translatorClient;
        }

        public async Task<DomainResponse<PokemonResponse>> GetByName(string name, bool translateDescription)
        {
            try
            {
                PokeApiClient pokeClient = new PokeApiClient();
                var species = await pokeClient.GetResourceAsync<PokemonSpecies>(name);

                var description = species.FlavorTextEntries.FirstOrDefault(x => x.Language.Name == "en")?.FlavorText
                    .Replace("\n", " ")
                    .Replace("\f", " ");

                if (description != null && translateDescription) description = await GetTranslatedDescription(species, description);

                var pokemonResponse = new PokemonResponse(species.Name, description, species.Habitat.Name, species.IsLegendary);

                return new DomainResponse<PokemonResponse> { Result = pokemonResponse };
            }
            catch
            {
                return new DomainResponse<PokemonResponse> { Status = Status.Failed };
            }
        }

        private async Task<string> GetTranslatedDescription(PokemonSpecies species, string description)
        {
            var targetLanguage = species.Habitat.Name == "cave" || species.IsLegendary
                ? Enumerations.Language.Yoda
                : Enumerations.Language.Shakespeare;
            
            var translation = await translatorClient.Translate(targetLanguage, description);

            return translation.Success
                ? translation.Contents.Translated
                : description;
        }
    }
}
