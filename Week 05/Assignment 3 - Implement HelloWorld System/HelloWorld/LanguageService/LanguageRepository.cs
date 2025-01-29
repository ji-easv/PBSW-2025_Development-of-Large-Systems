namespace LanguageService;

public class LanguageRepository
{
    public IEnumerable<string> GetLanguages()
    {
        return new List<string>
        {
            "en", // English
            "de", // German
            "sk", // Slovak
            "da", // Danish
            "es", // Spanish
            "fr", // French
        };
    }
}