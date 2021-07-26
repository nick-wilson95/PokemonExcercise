using PokemonExcercise.Models;
using System.Threading.Tasks;

namespace PokemonExcercise.Interfaces
{
    public interface IPokemonService
    {
        Task<DomainResponse<PokemonResponse>> GetByName(string name, bool translateDescription);
    }
}
