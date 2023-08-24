using ExerciseProject.Models.Domain;

namespace ExerciseProject.Models.DataDriven
{
    public class EmployeeDTO
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string MobileNumber { get; set; }

        public int Salary { get; set; }
    }
}
