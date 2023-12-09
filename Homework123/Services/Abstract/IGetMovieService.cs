using Homework123.Entities;

namespace Homework123.Services.Abstract
{
    public interface IGetMovieService
    {
        Task<Movie> GetMovieFromApi();
    }
}
