using AssessmentLibrary.Assessment4.Api;

namespace AssessmentLibrary.Assessment4;

public interface IWeatherService
{
    Task<WeatherData> GetWeatherResultAsync(string city);
}

public class WeatherService : IWeatherService
{
    private readonly IWeatherClientsFactory _weatherClientsFactory;

    public WeatherService(IWeatherClientsFactory weatherClientsFactory)
    {
        _weatherClientsFactory = weatherClientsFactory;
    }

    public async Task<WeatherData> GetWeatherResultAsync(string city)
    {
        var cancellationTokenSource = new CancellationTokenSource();

        try
        {
            var clients = _weatherClientsFactory.GetWeatherClents();
            var tasks = clients.Select(c => c.GetAsync(cancellationTokenSource.Token)).ToList();
            var result = await WaitTillFirstSuccess(tasks);
            return result;
        }
        finally
        {
            await cancellationTokenSource.CancelAsync();
        }
    }

    private static async Task<WeatherData> WaitTillFirstSuccess(List<Task<WeatherData>> tasks)
    {
        while (tasks.Count > 0)
        {
            var completedTask = await Task.WhenAny(tasks);
            if (completedTask.IsCompletedSuccessfully)
            {
                return completedTask.Result;
            }

            completedTask.Dispose();
            tasks.Remove(completedTask);
        }

        throw new Exception("Failed to retrieve weather data");
    }
}
