using PokeApiNet;
using System.Threading.Tasks;

namespace PokemonExcercise.Interfaces
{
    public interface ITranslationService
    {
        Task<string> GetTranslatedDescription(PokemonSpecies species, string description);
    }
}
