var client = new WeatherAPI("AIzaSyBwawM5nYVEBy2yCleKfwpXkEf5cdZ7PKk");
float? temp = await client.GetCurrentTemperature(55.4038, 10.4024);
Console.WriteLine(temp);