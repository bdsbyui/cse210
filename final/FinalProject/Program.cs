using System;

class Program
{
    static void Main(string[] args)
    {
        static Forecast CallMapAsync(string search)
        {
            MapCaller caller = new(search);
            return caller.Call().Result;
        }

        static void CallWeatherAsync(Forecast forecast)
        {
            WeatherCaller caller = new(forecast);
            caller.Call().Wait();
        }

        Forecasts forecasts = new();  // or load Forecasts object

        Menu mainMenu = new("MAIN MENU");

        do
        {
            (string be, string s) = Menu.GetSubjectVerb(forecasts.Count());
            mainMenu.SetOptions
            (
                new List<string>()
                {
                    $"View saved location{s}",
                    "Add new location",
                    "Quit"
                }
            );

            mainMenu.Display();
            switch (mainMenu.PromptValidatedSelection())
            {
                case 0:
                    mainMenu.Kill();  // tries before kill?
                    break;

                case 1:
                    if (forecasts.Count() == 0)
                    {
                        goto case 2;
                    }

                    Menu listMenu = new($"LOCATION{s}");
                    listMenu.SetContext("Select location to view forecast.");
                    listMenu.SetOptions(forecasts.PutOptions());

                    listMenu.Display();
                    int selection = listMenu.PromptValidatedSelection();
                    switch (selection)
                    {
                        case 0:
                            listMenu.Kill();
                            break;

                        default:
                            Forecast selectedForecast 
                                    = forecasts.AccessForecast(selection - 1);
                            Menu forecastMenu = new(
                                    $"FORECAST FOR {selectedForecast.PutShortPlaceName()}");
                            forecastMenu.SetContext
                            (
                                $"Local time is currently {selectedForecast.PutCurrentTime(
                                    )}. The forecast was last updated {selectedForecast.PutElapsedTime(
                                        )} ago."
                            );
                            forecastMenu.SetOptions
                            (
                                new List<string>()
                                {
                                    "Update forecast",
                                    $"Current forecast as of {selectedForecast.PutForecastTime()}",
                                    $"{selectedForecast.PutMinutelyOption()}",
                                    $"{selectedForecast.PutHourlyOption()}",
                                    $"{selectedForecast.PutDailyOption()}",
                                    "Quit",
                                }
                            );

                            forecastMenu.Display();
                            switch (forecastMenu.PromptValidatedSelection())
                            {
                                case 0:
                                    forecastMenu.Kill();
                                    break;
                                
                                case 1:
                                    CallWeatherAsync(selectedForecast);
                                    break;
                                
                                case 2:
                                    selectedForecast.DisplayCurrent();
                                    break;
                                
                                case 3:
                                    selectedForecast.DisplayMinutely();
                                    break;
                                
                                case 4:
                                    selectedForecast.DisplayHourly();
                                    break;
                                
                                case 5:
                                    selectedForecast.DisplayDaily();
                                    break;
                                
                                case 6:
                                    forecastMenu.Quit();
                                    break;
                            }
                            break;
                    }
                    break;

                case 2:
                    Menu addMenu = new("ADD LOCATION");
                    addMenu.Display();
                    
                    string search = addMenu.PromptUnvalidatedResponse
                    (
                        "Enter a location: "
                    );
                    Forecast newForecast = CallMapAsync(search);
                    CallWeatherAsync(newForecast);
                    forecasts.Add(newForecast);
                    break;
                    
                case 3:
                    mainMenu.Quit();
                    break;
            }
        } while (mainMenu.Running());

        // save Forecasts object
    }
}