using ExerciseProject.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models.DataDriven
{
    public class EmployeeDTO
    {
        public int EmpID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(1,ErrorMessage ="Age shoub be greater than 1")]
        [MaxLength(100,ErrorMessage ="Age shoub be less than 100")]
        public string Age { get; set; }
        public string MobileNumber { get; set; }

        public int Salary { get; set; }

        public SalaryDTO SalaryDetail { get; set; }

    }
}
