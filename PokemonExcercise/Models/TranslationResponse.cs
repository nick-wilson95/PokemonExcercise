namespace PokemonExcercise.Models
{
    public class TranslationResponse
    {
        public SuccessContents Success { get; set; }
        public TranslationContents Contents { get; set; }
    }

    public class SuccessContents
    {
        public int Total { get; set; }
    }

    public class TranslationContents
    {
        public string Translated { get; set; }
        public string Text { get; set; }
        public string Translation { get; set; }
    }
}
