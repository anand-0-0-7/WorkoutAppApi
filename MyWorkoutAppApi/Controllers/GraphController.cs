using Microsoft.AspNetCore.Mvc;
using MyWorkoutAppApi.Data;
using System.Threading.Tasks;

namespace MyWorkoutAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        private readonly IGraphRepository _graphRepository;

        public GraphController(IGraphRepository graphRepository)
        {
            _graphRepository = graphRepository;
        }

        // Endpoint to get unique WorkoutName and SetNo combinations for a user
        [HttpGet("workout-log-options")]
        public async Task<IActionResult> GetWorkoutLogOptions(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid UserId.");
            }
            var workoutLogOptions = await _graphRepository.GetUniqueWorkoutLogOptionsAsync(userId);
            return Ok(workoutLogOptions);
        }

        // Endpoint to get graph data for the selected WorkoutName and SetNo combination
        [HttpGet("workout-data")]
        public async Task<IActionResult> GetWorkoutData([FromQuery] int userId,[FromQuery] string workoutName, [FromQuery] int setNo)
        {
            var workoutData = await _graphRepository.GetWorkoutDataForGraphAsync(userId, workoutName, setNo);
            return Ok(workoutData);
        }
    }
}
