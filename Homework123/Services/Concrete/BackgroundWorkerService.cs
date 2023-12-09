using Homework123.Controllers;
using Homework123.Services.Abstract;

namespace Homework123.Services.Concrete
{
    public class BackgroundWorkerService : BackgroundService
    {
        private IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly IGetMovieService _movieGetService;
        private readonly IMovieService _movieService;
        private readonly ILogger<BackgroundWorkerService> _logger;
        private readonly MovieController _controller;

        public BackgroundWorkerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            using (var scope = _serviceProvider.CreateScope())
            {
                _controller = scope.ServiceProvider.GetRequiredService<MovieController>();
                _movieService = scope.ServiceProvider.GetRequiredService<IMovieService>();
                _movieGetService = scope.ServiceProvider.GetRequiredService<IGetMovieService>();
                _logger = scope.ServiceProvider.GetRequiredService<ILogger<BackgroundWorkerService>>();
                _configuration =scope.ServiceProvider.GetRequiredService<IConfiguration>();
            }
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var minute = int.Parse(_configuration["Time:minute"]);
                _logger.LogInformation("Worker running at : {time}", DateTimeOffset.Now);
                _controller.GetAsync();
                await Task.Delay(minute * 1000, stoppingToken);
            }
        }
    }
}
