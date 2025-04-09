namespace AssessmentLibrary.Assessment4.Api;

public interface IWeatherClientsFactory
{
    IEnumerable<IWeatherClient> GetWeatherClents();
}

public class WeatherClientsFactory : IWeatherClientsFactory
{
    public IEnumerable<IWeatherClient> GetWeatherClents()
    {
        return Enumerable.Range(0, 10).Select(_ => new WeatherClient());
    }
}
