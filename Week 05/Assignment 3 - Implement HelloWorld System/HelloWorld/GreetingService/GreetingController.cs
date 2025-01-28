using Microsoft.AspNetCore.Mvc;

namespace GreetingService;

[ApiController]
[Route("[controller]")]
public class GreetingController(ILogger<GreetingController> logger, GreetingService greetingService) : ControllerBase
{
    [HttpGet(Name = "greeting")]
    public string GetGreeting([FromQuery] string language)
    {
        logger.LogInformation("Getting greeting for language {language} on {machine}", language, Environment.MachineName);
        return greetingService.GetGreeting(language);
    }
}