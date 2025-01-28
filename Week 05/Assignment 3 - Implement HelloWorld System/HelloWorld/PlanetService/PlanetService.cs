namespace PlanetService;

public class PlanetService(PlanetRepository planetRepository)
{
    public string GetPlanet(string name)
    {
        return planetRepository.GetPlanet(name);
    }
}