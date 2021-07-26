namespace PokemonExcercise.Models
{
    public class TranslationResponse
    {
        public bool Success { get; set; }
        public TranslationContents Contents { get; set; }
    }

    public class TranslationContents
    {
        public string Translated { get; set; }
        public string Text { get; set; }
        public string Translation { get; set; }
    }
}
