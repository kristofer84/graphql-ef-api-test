using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace test_graph.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphController : ControllerBase
    {
        private readonly AppContext _context;
        private readonly IQuery _query;
        private readonly ILogger<MovieController> _logger;
        private readonly Schema _schema;

        public GraphController(ILogger<MovieController> logger, AppContext context, IQuery query)
        {
            _logger = logger;
            _context = context;
            _query = query;
            _context.Database.EnsureCreated();

            _schema = Schema.For(@"
                type Movie {
                    id: ID!,
                    name: String!
                    reviews: [Review]
                },
                type Review {
                    id: ID!,
                    reviewer: String!,
                    stars: Int!
                },
                type Query {
                    movies: [Movie],
                    movie(id: ID!): Movie
                }
             ", _ => _.Types.Include<Query>());
        }

        [HttpGet]
        public async Task<ActionResult> Test()
        {
            var json = await Query("{movies{name}}");
            return Ok(json);
        }

        [HttpPost]
        public async Task<ActionResult> Test([FromForm] string query)
        {
            var json = await Query(query);
            return Ok(json);
        }

        private async Task<string> Query(string query)
        {
            return await _schema.ExecuteAsync(_ =>
             {
                 _.Query = query;
                 _.Root = _query;
             });
        }

        [HttpGet("reviews")]
        public async Task<ActionResult> Reviews()
        {
            return Ok(await _context.Reviews.ToListAsync());
        }
    }
}
