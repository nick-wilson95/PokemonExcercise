using PokemonExcercise.Enumerations;
using PokemonExcercise.Interfaces;
using PokemonExcercise.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokemonExcercise.Concretes
{
    public class TranslationClient : ITranslationClient
    {
        private const string Url = "https://api.funtranslations.com";

        public async Task<TranslationResponse> Translate(string input, Language targetLanguage)
        {
            var encodedInput = Uri.EscapeUriString(input);
            var uri = $"{Url}/translate/{targetLanguage.ToString()}.json?text={encodedInput}";

            using var client = new HttpClient();
            var result = await client.GetAsync(uri);

            if (!result.IsSuccessStatusCode)
            {
                return new TranslationResponse {
                    Success = new SuccessContents { Total = 0 }
                };
            }

            var responseString = await result.Content.ReadAsStringAsync();

            var translation = JsonSerializer.Deserialize<TranslationResponse>(
                responseString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return translation;
        }
    }
}
