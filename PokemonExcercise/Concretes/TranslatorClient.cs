using PokemonExcercise.Enumerations;
using PokemonExcercise.Interfaces;
using PokemonExcercise.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokemonExcercise.Concretes
{
    public class TranslatorClient : ITranslatorClient
    {
        private const string Url = "https://api.funtranslations.com";

        public async Task<TranslationResponse> Translate(Language targetLanguage, string input)
        {
            var encodedInput = Uri.EscapeUriString(input);
            var uri = $"{Url}/translate/{targetLanguage.ToString()}.json?text={encodedInput}";

            using var client = new HttpClient();
            var result = await client.GetAsync(uri);

            var translation = await JsonSerializer.DeserializeAsync<TranslationResponse>(await result.Content.ReadAsStreamAsync());

            return translation;
        }
    }
}
