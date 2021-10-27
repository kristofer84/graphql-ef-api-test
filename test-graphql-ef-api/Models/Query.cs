using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using test_graph.Models;

namespace test_graph.Controllers
{
    public class Query : ObjectGraphType, IQuery
    {
        private readonly AppContext _context;

        public Query(AppContext appContext)
        {
            _context = appContext;
        }

        [GraphQLMetadata("movies")]
        public IEnumerable<Movie> GetMovies(IResolveFieldContext context)
        {
            var query = MovieQuery(context);
            return query.ToList();
        }

        [GraphQLMetadata("movie")]
        public Movie? GetMovie(IResolveFieldContext context, int id)
        {
            var query = MovieQuery(context);
            return query.SingleOrDefault(j => j.Id == id);
        }

        private IQueryable<Movie> MovieQuery(IResolveFieldContext context)
        {
            var fields = context.SubFields?.Select(s => s.Value.Name);
            var query = _context.Movies.AsQueryable();

            if (fields != null && fields.Contains("reviews"))
            {
                query = query.Include(s => s.Reviews);
            }

            return query;
        }
    }
}