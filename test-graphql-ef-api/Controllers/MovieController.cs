using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace test_graph.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly AppContext _context;
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, AppContext context)
        {
            _logger = logger;
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var movies = await _context
                .Movies
                .Include(s => s.Reviews)
                .ToListAsync();

            return Ok(movies);
        }

        [HttpGet("reviews")]
        public async Task<ActionResult> Reviews()
        {
            return Ok(await _context.Reviews.ToListAsync());
        }
    }
}
