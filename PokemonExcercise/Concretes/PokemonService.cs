using PokemonExcercise.Enumerations;
using PokemonExcercise.Interfaces;
using PokemonExcercise.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonExcercise.Concretes
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokeApiClient pokeApiClient;
        private readonly ITranslationService translationService;

        public PokemonService(IPokeApiClient pokeApiClient, ITranslationService translationService)
        {
            this.pokeApiClient = pokeApiClient;
            this.translationService = translationService;
        }

        public async Task<DomainResponse<PokemonResponse>> GetByName(string name, bool translateDescription)
        {
            try
            {
                var species = await pokeApiClient.GetPokemonSpeciesByName(name);

                var description = species.FlavorTextEntries.FirstOrDefault(x => x.Language.Name == "en")?.FlavorText
                    .Replace("\n", " ")
                    .Replace("\f", " ");

                if (description != null && translateDescription) description = await translationService.GetTranslatedDescription(species, description);

                var pokemonResponse = new PokemonResponse(species.Name, description, species.Habitat.Name, species.IsLegendary);

                return new DomainResponse<PokemonResponse> { Result = pokemonResponse };
            }
            catch
            {
                // Log the error here
                return new DomainResponse<PokemonResponse> { Status = Status.Failed };
            }
        }
    }
}
