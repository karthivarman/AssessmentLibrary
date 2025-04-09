using AssessmentLibrary.Assessment4;
using AssessmentLibrary.Assessment4.Api;

namespace AssessmentLibrary.Tests.Assessment4
{
    // Using stubs instead of Moqs to avoid altering the project structure/references
    public class WeatherClientsFactoryStub : IWeatherClientsFactory
    {
        private List<IWeatherClient> _clients;

        public WeatherClientsFactoryStub(List<IWeatherClient> clients)
        {
            _clients = clients;
        }

        public IEnumerable<IWeatherClient> GetWeatherClents()
        {
            return _clients;
        }
    }

    public class WeatherClientWithDelayStub : IWeatherClient
    {
        public async Task<WeatherData> GetAsync(CancellationToken cancellationToken)
        {
            // Return data after 2 seconds
            await Task.Delay(2000);
            return new WeatherData();
        }
    }

    public class WeatherClientWithoutDelayStub : IWeatherClient
    {
        public Task<WeatherData> GetAsync(CancellationToken cancellationToken)
        {
            // Return data without any delay
            return Task.FromResult(new WeatherDataWithoutDelay() as WeatherData);
        }
    }

    public class WeatherClientStubWithErrorStub : IWeatherClient
    {
        public async Task<WeatherData> GetAsync(CancellationToken cancellationToken)
        {
            throw new Exception("Exception from Test code");
        }
    }

    public class WeatherDataWithoutDelay : WeatherData
    { }
}
