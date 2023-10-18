using System;

class Program
{
    // Load saved places
    // List places, pick or add or quit
        // Pick show weather; return or delete
        // Add: get weather; quit or save
    // Options: Get Weather; Manage Places; Quit
        // Get weather
            // Display
    // Show weather
        // foreach place, 
    // list options

    static void Main(string[] args)
    {


        MainAsync().Wait();

        static async Task MainAsync()
        {
            ApiCaller caller = new();
            await caller.Lookup();
        }

        


    }
}