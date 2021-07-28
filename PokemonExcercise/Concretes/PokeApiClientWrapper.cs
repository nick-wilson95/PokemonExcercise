using PokeApiNet;
using PokemonExcercise.Interfaces;
using System.Threading.Tasks;

namespace PokemonExcercise.Concretes
{
    public class PokeApiClientWrapper : IPokeApiClient
    {
        private readonly PokeApiClient pokeApiClient;

        public PokeApiClientWrapper()
        {
            pokeApiClient = new PokeApiClient();
        }

        public async Task<PokemonSpecies> GetPokemonSpeciesByName(string name)
        {
            return await pokeApiClient.GetResourceAsync<PokemonSpecies>(name);
        }
    }
}
