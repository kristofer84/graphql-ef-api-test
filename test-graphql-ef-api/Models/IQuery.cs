using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;
using test_graph.Models;

namespace test_graph.Controllers
{
    public interface IQuery : IObjectGraphType
    {
        [GraphQLMetadata("movies")]
        IEnumerable<Movie> GetMovies(IResolveFieldContext context);

        [GraphQLMetadata("movie")]
        Movie? GetMovie(IResolveFieldContext context, int id);
    }
}