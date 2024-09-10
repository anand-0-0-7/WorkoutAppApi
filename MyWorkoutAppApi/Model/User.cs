using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWorkoutAppApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }

        // Navigation property for WorkoutLogs
        public ICollection<WorkoutLog> WorkoutLogs { get; set; }
    }
}
