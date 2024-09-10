using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWorkoutAppApi.Models
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }  // Primary Key

        [Required]
        [MaxLength(100)]
        public string WorkoutName { get; set; }

        [Required]
        [MaxLength(50)]
        public string WorkoutType { get; set; }

        // Navigation property for WorkoutLogs
        public ICollection<WorkoutLog> WorkoutLogs { get; set; }
    }
}
