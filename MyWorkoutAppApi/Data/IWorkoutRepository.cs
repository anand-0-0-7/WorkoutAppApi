using MyWorkoutAppApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWorkoutAppApi.Data
{
    public interface IWorkoutRepository
    {
        Task<List<string>> GetWorkoutTypesAsync();
        Task<List<Workout>> GetWorkoutNamesAsync(string workoutType);
        Task SaveWorkoutLogAsync(WorkoutLog workoutLog);
    }
}