using System;
using System.Threading.Tasks;
using JokeFetcher.Services;

class Program
{
    static async Task Main()
    {
        var jokeService = new JokeService();

        Console.WriteLine("Fetching a random joke...\n");

        try
        {
            var joke = await jokeService.GetRandomJokeAsync();
            Console.WriteLine(joke);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}