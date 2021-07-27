using PokeApiNet;
using System.Threading.Tasks;

namespace PokemonExcercise.Interfaces
{
    public interface IPokeApiClient
    {
        Task<PokemonSpecies> GetPokemonSpeciesByName(string name);
    }
}
