using PokemonExcercise.Models;
using System.Threading.Tasks;

namespace PokemonExcercise.Interfaces
{
    public interface IPokemonService
    {
        Task<DomainResponse<PokemonResponse>> Get(string name);
        Task<DomainResponse<PokemonResponse>> GetTranslated(string name);
    }
}
