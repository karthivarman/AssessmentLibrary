using AssessmentLibrary.Assessment4;
using AssessmentLibrary.Assessment4.Api;

namespace AssessmentLibrary.Tests.Assessment4
{
    [TestClass]
    public class WeatherServiceTests
    {
        [TestMethod]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(10)]
        public async Task GetWeatherResultAsync_Returns_FirstResult(int firstFinishClientIndex)
        {
            var clients = Enumerable.Range(0, 10).Select(_ => new WeatherClientWithDelayStub() as IWeatherClient).ToList();
            clients.Insert(firstFinishClientIndex, new WeatherClientWithoutDelayStub());
            var factoryStub = new WeatherClientsFactoryStub(clients);
            var instance = new WeatherService(factoryStub);

            var output = await instance.GetWeatherResultAsync("London");

            Assert.IsTrue(output is WeatherDataWithoutDelay);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(10)]
        public async Task GetWeatherResultAsync_Returns_OnlySuccessfulResult(int firstFinishClientIndex)
        {
            var clients = Enumerable.Range(0, 10).Select(_ => new WeatherClientStubWithErrorStub() as IWeatherClient).ToList();
            clients.Insert(firstFinishClientIndex, new WeatherClientWithDelayStub());
            var factoryStub = new WeatherClientsFactoryStub(clients);
            var instance = new WeatherService(factoryStub);

            var output = await instance.GetWeatherResultAsync("London");

            Assert.IsTrue(output is WeatherData);
        }

        [TestMethod]
        public async Task GetWeatherResultAsync_ThrowsError_WhenAllRequestsFail()
        {
            var clients = Enumerable.Range(0, 10).Select(_ => new WeatherClientStubWithErrorStub() as IWeatherClient).ToList();
            var factoryStub = new WeatherClientsFactoryStub(clients);
            var instance = new WeatherService(factoryStub);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await instance.GetWeatherResultAsync("London"), "Failed to retrieve weather data");
        }
    }
}
