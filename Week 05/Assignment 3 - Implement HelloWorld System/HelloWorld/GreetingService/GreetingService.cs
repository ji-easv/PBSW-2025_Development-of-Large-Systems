namespace GreetingService;

public class GreetingService(GreetingRepository greetingRepository)
{
    public string GetGreeting(string language)
    {
        return greetingRepository.GetGreeting(language);
    }
}