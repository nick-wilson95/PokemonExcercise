using PokemonExcercise.Enumerations;
using PokemonExcercise.Models;
using System.Threading.Tasks;

namespace PokemonExcercise.Interfaces
{
    public interface ITranslationClient
    {
        Task<TranslationResponse> Translate(string input, Language targetLanguage);
    }
}
