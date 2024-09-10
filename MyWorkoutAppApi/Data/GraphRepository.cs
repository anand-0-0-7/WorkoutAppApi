using MyWorkoutAppApi.Data;
using MyWorkoutAppApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkoutAppApi.Data
{
    public class GraphRepository : IGraphRepository
    {
        private readonly ApplicationDbContext _context;

        public GraphRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Fetch unique WorkoutName and SetNo combinations for the logged-in user
        public async Task<IEnumerable<dynamic>> GetUniqueWorkoutLogOptionsAsync(int userId)
        {
            return _context.WorkoutLogs
                .Where(wl => wl.UserId == userId)
                .GroupBy(wl => new { wl.Workouts.WorkoutName, wl.SetNo })
                .Select(g => new { g.Key.WorkoutName, g.Key.SetNo })
                .ToList();
        }
        

        // Fetch the date and reps data for the selected workout name and set number combination
        public async Task<IEnumerable<WorkoutLog>> GetWorkoutDataForGraphAsync(int userId, string workoutName, int setNo)
        {
            return _context.WorkoutLogs
                .Where(wl =>wl.UserId==userId && wl.Workouts.WorkoutName == workoutName && wl.SetNo == setNo)
                .OrderBy(wl => wl.Date)
                .ToList();
        }
    }
}
