namespace LanguageService;

public class LanguageService(LanguageRepository languageRepository)
{
    public IEnumerable<string> GetLanguages()
    {
        return languageRepository.GetLanguages();
    }
}