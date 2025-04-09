namespace AssessmentLibrary.Assessment4.Api;

public interface IWeatherClient
{
    Task<WeatherData> GetAsync(CancellationToken cancellationToken);
}

public class WeatherClient : IWeatherClient
{
    public async Task<WeatherData> GetAsync(CancellationToken cancellationToken)
    {
        // Simulate API delay
        await Task.Delay(Random.Shared.Next(500, 1000));

        // TODO: Use cancellationToken to handle cancellation

        return new WeatherData();
    }
}
