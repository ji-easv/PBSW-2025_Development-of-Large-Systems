workspace {
    model {
        User = person "User" "Person"
        
        HelloWorld = softwareSystem "HelloWorld System" "Allows customers to get greetings in different languages from different planets." {
            SPA = container "Single Page Application" "Allows the user to pick a language in the browser and displays a greeting." "HTML and JavaScript" 
            
            LanguageAPI = container "Language API" "Provides a list of supported languages." ".NET Web API" {
                LanguageController = component  "Language Controller" "Handles API requests for languages." ".NET Controller"
                LanguageService = component "Language Service" "Pass through layer (in this case)" ".NET Scoped Service"
                LanguageRepository = component "Language Repository" "Reads data from the database." ".NET Scoped Repository"
            }
            
            PlanetAPI = container "Planet Service" "Provides a random planet name based on provided language." ".NET Web API" {
                PlanetController = component "Planet Controller" "Handles API requests for planets."
                PlanetService = component "Planet Service" "Pass through layer (in this case)" ".NET Scoped Service"
                PlanetRepository = component "Planet Repository"  "Reads data from the database." ".NET Scoped Repository"
            }
            
            GreetingAPI = container "Greeting Service" "Provides a random greeting based on provided language." ".NET Web API" {
                GreetingController = component "Greeting Controller" "Handles API requests for greetings."
                GreetingService = component "Greeting Service" "Pass through layer (in this case)" ".NET Scoped Service"
                GreetingRepository = component "Greeting Repository"  "Reads data from the database." ".NET Scoped Repository"
            }

            Database = container "Database" "Persists available languages, greetings and planets." "PostgreSQL" { 
                tags "Database" 
                }
        }
        
        // Relationships
        User -> SPA "Requests localized greetings" "HTTPS"
        
        SPA -> LanguageAPI "GET Languages" "HTTPS"
        SPA -> PlanetAPI "GET a planet" "HTTPS"
        SPA -> GreetingAPI "GET greeting" "HTTPS"
        
        LanguageController -> LanguageService "Uses"
        LanguageService -> LanguageRepository "Uses"
        LanguageRepository -> Database "Reads from" "JDBC"

        PlanetController -> PlanetService "Uses"
        PlanetService -> PlanetRepository "Uses"
        PlanetRepository -> Database "Reads from" "JDBC"

        GreetingController -> GreetingService "Uses"
        GreetingService -> GreetingRepository "Uses"
        GreetingRepository -> Database "Reads from" "JDBC"
    }

    views {
        styles {
            element "Element" {
                color #ffffff
            }
            element "Person" {
                background #9b191f
                shape person
            }
            element "Software System" {
                background #ba1e25
            }
            element "App" {
                shape "MobileDeviceLandscape"
            }
            element "Database" {
                shape cylinder
            }
            element "Container" {
                background #d9232b
            }
            element "Component" {
                background #E66C5A
            }
            element "WebBrowser" {
                shape WebBrowser
            }
        }
    }
}