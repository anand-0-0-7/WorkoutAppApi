using System.Collections.Generic;
using System.Threading.Tasks;
using MyWorkoutAppApi.Models;

namespace MyWorkoutAppApi.Data
{
    public interface IGraphRepository
    {
        Task<IEnumerable<dynamic>> GetUniqueWorkoutLogOptionsAsync(int userId); // Unique WorkoutName and SetNo combinations
        Task<IEnumerable<WorkoutLog>> GetWorkoutDataForGraphAsync(int userId, string workoutName, int setNo); // Date and Reps data
    }
}
