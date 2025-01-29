using Microsoft.AspNetCore.Mvc;

namespace PlanetService;

[ApiController]
[Route("[controller]")]
public class PlanetController(ILogger<PlanetController> logger, PlanetService planetService) : ControllerBase
{
    [HttpGet]
    public string GetPlanet([FromQuery] string language)
    {
        logger.LogInformation("Getting planet on {machine}", Environment.MachineName);
        return planetService.GetPlanet(language);
    }
}