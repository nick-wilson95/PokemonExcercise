using Microsoft.AspNetCore.Mvc;
using PokemonExcercise.Enumerations;
using PokemonExcercise.Interfaces;
using PokemonExcercise.Models;
using System.Threading.Tasks;

namespace PokemonExcercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            this.pokemonService = pokemonService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<PokemonResponse>> Get(string name)
        {
            var result = await pokemonService.GetByName(name, false);

            if (result.Status == Status.Succeeded) return result.Result;

            return StatusCode(424, $"Something went wrong when trying to get pokemon with name {name}.");
        }

        [HttpGet("translated/{name}")]
        public async Task<ActionResult<PokemonResponse>> GetTranslated(string name)
        {
            var result = await pokemonService.GetByName(name, true);

            if (result.Status == Status.Succeeded) return result.Result;

            return StatusCode(424, $"Something went wrong when trying to get pokemon with name {name}.");
        }
    }
}
