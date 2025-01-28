namespace GreetingService;

public class GreetingRepository
{
    private static readonly Dictionary<string, string> GreetingsByLanguage = new()
    {
        { "en", "Hello" },           // English
        { "de", "Hallo" },           // German
        { "sk", "Ahoj" },            // Slovak
        { "da", "Hej" },             // Danish
        { "es", "Hola" },            // Spanish
        { "fr", "Bonjour" }          // French
    };

    public string GetGreeting(string language)
    {
        return GreetingsByLanguage.TryGetValue(language, out var greeting) 
            ? greeting 
            : "Language not supported";
    }
}