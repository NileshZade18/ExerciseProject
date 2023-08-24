using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models.Domain
{
    public class Epmloyee
    {
        [Key]
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string MobileNumber { get; set; }

        public int Salary { get; set; }

        public SalaryDetails SalaryDetail { get; set; }
    }
}
