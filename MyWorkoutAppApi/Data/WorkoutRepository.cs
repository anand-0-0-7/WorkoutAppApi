using MyWorkoutAppApi.Data;
using MyWorkoutAppApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyWorkoutAppApi.Data
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkoutRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get list of distinct WorkoutTypes
        public async Task<List<string>> GetWorkoutTypesAsync()
        {
            return await _context.Workouts
                                 .Select(w => w.WorkoutType)
                                 .Distinct()
                                 .ToListAsync();
        }

        // Get list of WorkoutNames based on selected WorkoutType
        public async Task<List<Workout>> GetWorkoutNamesAsync(string workoutType)
        {
            return await _context.Workouts
                                 .Where(w => w.WorkoutType == workoutType)
                                 .ToListAsync();
        }

        // Save the WorkoutLogs entry
        public async Task SaveWorkoutLogAsync(WorkoutLog workoutLog)
        {
            await _context.WorkoutLogs.AddAsync(workoutLog);
            await _context.SaveChangesAsync();
        }
    }
}

