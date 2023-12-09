using Homework123.Data;
using Homework123.Entities;
using Homework123.Repositores.Abstract;
using System.Linq.Expressions;

namespace Homework123.Repositores.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDBContext _context;

        public MovieRepository(MovieDBContext context)
        {
            _context = context;
        }

        public void Add(Movie entity)
        {
            _context.Movies.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            _context.Movies.Remove(entity);
            _context.SaveChanges();
        }

        public Movie Get(Expression<Func<Movie, bool>> expression)
        {
            var movie = _context.Movies.SingleOrDefault(expression);
            return movie;
        }

        public IEnumerable<Movie> GetAll()
        {
            var movies = _context.Movies;
            return movies;
        }

        public void Update(Movie entity)
        {
            _context.Movies.Update(entity);
            _context.SaveChanges();
        }
    }
}
