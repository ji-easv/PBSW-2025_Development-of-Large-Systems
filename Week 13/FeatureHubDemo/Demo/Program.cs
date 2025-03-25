// See https://aka.ms/new-console-template for more information

using FeatureHubSDK;

FeatureLogging.DebugLogger += (sender, s) => Console.WriteLine("DEBUG: " + s); 
FeatureLogging.TraceLogger += (sender, s) => Console.WriteLine("TRACE: " + s); 
FeatureLogging.InfoLogger += (sender, s) => Console.WriteLine("INFO: " + s); 
FeatureLogging.ErrorLogger += (sender, s) => Console.WriteLine("ERROR: " + s);

var config = new EdgeFeatureHubConfig("http://featurehub:8085", "c7b84b3b-3519-4a6b-81ea-43aea955a9bc/w13mfztrgetCpXfgeFqKIWLWyesSmCFn0CSOc7Zj");
var context = await config
    .NewContext()
    .UserKey("user3")
    .Build();

await Task.Run(() =>
{
    if (context.IsEnabled("TimelyGreetings"))
    {
        var currentTime = DateTime.Now;
        switch (currentTime.Hour)
        {
            case >= 6 and < 12:
                Console.WriteLine("Good Morning");
                break;
            case >= 12 and < 18:
                Console.WriteLine("Good Afternoon");
                break;
            case >= 18 and < 22:
                Console.WriteLine("Good Evening");
                break;
            default:
                Console.WriteLine("Good Night");
                break;
        }
    }
    else
    {
        Console.WriteLine("Hello World");
    }
});

