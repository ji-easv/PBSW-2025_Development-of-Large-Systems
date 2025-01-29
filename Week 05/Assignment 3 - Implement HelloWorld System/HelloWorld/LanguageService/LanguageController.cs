using Microsoft.AspNetCore.Mvc;

namespace LanguageService;

[ApiController]
[Route("[controller]")]
public class LanguageController(ILogger<LanguageController> logger, LanguageService languageService) : ControllerBase
{
    [HttpGet("list")]
    public IEnumerable<string> GetLanguages()
    {
        logger.LogInformation("Getting languages on ${Environment.MachineName}");
        return languageService.GetLanguages();
    }
}