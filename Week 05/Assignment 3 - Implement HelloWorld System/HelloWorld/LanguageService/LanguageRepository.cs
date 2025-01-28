namespace LanguageService;

public class LanguageRepository
{
    public IEnumerable<string> GetLanguages()
    {
        return new List<string>
        {
            "English",
            "Spanish",
            "French",
            "Mandarin Chinese",
            "Hindi",
            "Arabic",
            "Portuguese",
            "Bengali",
            "Russian",
            "Japanese",
            "German",
            "Korean",
            "Italian",
            "Turkish",
            "Dutch",
            "Swedish",
            "Polish",
            "Thai",
            "Vietnamese",
            "Greek"
        };
    }
}