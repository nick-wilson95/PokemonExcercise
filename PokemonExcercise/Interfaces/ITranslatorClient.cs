using PokemonExcercise.Enumerations;
using PokemonExcercise.Models;
using System.Threading.Tasks;

namespace PokemonExcercise.Interfaces
{
    public interface ITranslatorClient
    {
        Task<TranslationResponse> Translate(Language targetLanguage, string input);
    }
}
