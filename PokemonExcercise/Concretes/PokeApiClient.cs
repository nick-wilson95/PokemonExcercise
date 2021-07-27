using PokeApiNet;
using PokemonExcercise.Interfaces;
using System.Threading.Tasks;

namespace PokemonExcercise.Concretes
{
    public class PokeApiClientWrapper : IPokeApiClient
    {
        public async Task<PokemonSpecies> GetPokemonSpeciesByName(string name)
        {
            PokeApiClient pokeClient = new PokeApiClient();
            return await pokeClient.GetResourceAsync<PokemonSpecies>(name);
        }
    }
}
