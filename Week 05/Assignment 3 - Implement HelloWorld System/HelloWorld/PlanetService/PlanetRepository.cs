namespace PlanetService;

public class PlanetRepository
{
    private static readonly Dictionary<string, List<string>> PlanetsByLanguage = new()
    {
        { "en", new List<string> { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" } },   // English
        { "de", new List<string> { "Merkur", "Venus", "Erde", "Mars", "Jupiter", "Saturn", "Uranus", "Neptun" } },      // German
        { "sk", new List<string> { "Merkúr", "Venuša", "Zem", "Mars", "Jupiter", "Saturn", "Urán", "Neptún" } },        // Slovak
        { "da", new List<string> { "Merkur", "Venus", "Jorden", "Mars", "Jupiter", "Saturn", "Uranus", "Neptun" } },    // Danish
        { "es", new List<string> { "Mercurio", "Venus", "Tierra", "Marte", "Júpiter", "Saturno", "Urano", "Neptuno" } }, // Spanish
        { "fr", new List<string> { "Mercure", "Vénus", "Terre", "Mars", "Jupiter", "Saturne", "Uranus", "Neptune" } }   // French
    };
    
    private readonly Random _random = new();

    public string GetPlanet(string language)
    {
        if (!PlanetsByLanguage.ContainsKey(language))
        {
            return "Language not supported";
        }

        var planets = PlanetsByLanguage[language];
        int index = _random.Next(planets.Count);
        return planets[index];
    }
}