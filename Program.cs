using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReverseString;

var serviceCollection = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
    .Build();

serviceCollection.AddSingleton<IConfiguration>(configuration);
serviceCollection.AddSingleton<IReverseStringService, ReverseStringService>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var reverseStringService = serviceProvider.GetService<IReverseStringService>();
reverseStringService?.ReverseString();

Console.WriteLine("Press ESC to stop. Enter to continue..");

while (!(Console.ReadKey(true).Key == ConsoleKey.Escape))
{
}
Console.WriteLine("Exiting....");
