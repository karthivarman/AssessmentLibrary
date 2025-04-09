namespace AssessmentLibrary.Assessment4
{
    public class WeatherReportService
    {
        private readonly IWeatherService _weatherService;
        private volatile bool _processing = false;

        public WeatherReportService(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // A simple periodic timer is used instead of a framework like Quartz.net to avoid external dependency
        public async Task StartWeatherReport(CancellationToken stoppingToken, int intervalInSeconds)
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(intervalInSeconds));

            while (!stoppingToken.IsCancellationRequested)
            {
                if (!_processing)
                {
                    _processing = true;
                    Process();
                }

                await timer.WaitForNextTickAsync(stoppingToken);
            }
        }

        private void Process()
        {
            // No need to await response
            Task.Run(async () =>
            {
                try
                {
                    var result = await _weatherService.GetWeatherResultAsync("London");
                    // TODO: Handle data here

                    _processing = false;
                }
                catch (Exception )
                {
                    // Log and notify error
                }
            });
        }
    }
}
