using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models.DataDriven
{
    public class AddUserDto
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
