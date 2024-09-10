using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWorkoutAppApi.Models
{
    public class WorkoutLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }

        // Foreign key to User table
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }  // Navigation property

        // Foreign key to Workouts table
        [Required]
        public int WorkoutId { get; set; }
        [ForeignKey("WorkoutId")]
        public Workout Workouts { get; set; }  // Navigation property

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int SetNo { get; set; }

        [Required]
        public int Reps { get; set; }
    }
}
