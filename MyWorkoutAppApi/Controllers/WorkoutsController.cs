using Microsoft.AspNetCore.Mvc;
using MyWorkoutAppApi.Models;
using MyWorkoutAppApi.Data;
using System.Threading.Tasks;
using System.Linq;

namespace MyWorkoutAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutsController(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        // 1. Get list of distinct WorkoutTypes
        [HttpGet("workouttypes")]
        public async Task<IActionResult> GetWorkoutTypes()
        {
            var workoutTypes = await _workoutRepository.GetWorkoutTypesAsync();
            return Ok(workoutTypes);
        }

        // 2. Get list of WorkoutNames based on selected WorkoutType
        [HttpGet("workoutnames/{type}")]
        public async Task<IActionResult> GetWorkoutNames(string type)
        {
            var workoutNames = await _workoutRepository.GetWorkoutNamesAsync(type);

            if (workoutNames == null || workoutNames.Count == 0)
            {
                return NotFound($"No workouts found for type: {type}");
            }

            var result = workoutNames.Select(wt => new { wt.WorkoutId, wt.WorkoutName });
            return Ok(result);
        }

        // 3. Save the WorkoutLogs entry
        [HttpPost("logworkout")]
        public async Task<IActionResult> LogWorkout([FromBody] WorkoutLog workoutLog)
        {
            if (workoutLog == null)
            {
                return BadRequest("Workout log data is required.");
            }

            await _workoutRepository.SaveWorkoutLogAsync(workoutLog);

            return Ok("Workout log saved successfully.");
        }
    }
}
