using Homework123.Entities;
using Homework123.Services.Abstract;
using System.Text.Json;

namespace Homework123.Services.Concrete
{
    public class GetMovieService : IGetMovieService
    {
        private readonly HttpClient httpClient;
        private readonly Random random;
        private readonly IMovieService _movieService;

        public GetMovieService(IMovieService movieService)
        {
            httpClient = new HttpClient();
            random = new Random();
            _movieService = movieService;
        }

        public async Task<Movie> GetMovieFromApi()
        {
            char randomLetter = (char)('A' + random.Next(26));

            string apiKey = "573749c3";
            string apiUrl = $"https://www.omdbapi.com/?apikey={apiKey}&t={randomLetter}*";

            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var movieInfo = JsonSerializer.Deserialize<Movie>(content);
                _movieService.Add(movieInfo);
                return movieInfo;
            }
            else
            {
                return null;
            }
        }
    }
}
