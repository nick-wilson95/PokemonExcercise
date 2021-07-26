using PokemonExcercise.Enumerations;

namespace PokemonExcercise.Models
{
    public class DomainResponse<T>
    {
        public T Result { get; set; }
        public Status Status { get; set; } = Status.Succeeded;
    }
}
