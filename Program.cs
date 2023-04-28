List<DateTime> utcTimes = new List<DateTime>();

Console.WriteLine("Welcome to timezone converter:");

while(true)
{
    Console.WriteLine("Please enter a timezone (e.g. America/New_York) or 'q' to quit:");

    string input = Console.ReadLine();

    if(input == "q") break;
    else if(input == "w") input = "America/New_York";
    try
    {
         // Convert the input timezone to UTC
        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(input!);

        // Get the local time in the local time zone
        DateTime localTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, timeZoneInfo);

        DateTime nowUtc = DateTime.UtcNow;
        // Convert the local time to UTC
        DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(localTime, timeZoneInfo);

        utcTimes.Add(utcTime);
        Console.WriteLine($"Input Timezone: {timeZoneInfo.DisplayName}");
        Console.WriteLine($"Local Time: {localTime}");
        Console.WriteLine($"UTC Time: {utcTime}");
        Console.WriteLine($"Now UTC Time: {nowUtc}");
    }
    catch (TimeZoneNotFoundException)
    {
        Console.WriteLine("Invalid timezone. Please try again");
    }
    catch(Exception ex) {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

// Display the list of UTC times
Console.WriteLine("List of UTC times:");
foreach(var utcTime in utcTimes)
{
    Console.WriteLine(utcTime);
}