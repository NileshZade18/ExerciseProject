using ExerciseProject.Models.DataDriven;

namespace ExerciseProject.Repository.Interface
{
    public interface IEmployeeRespository
    {
        Task<bool> AddEmployee(EmployeeDTO model);
        Task<List<EmployeeDTO>> GetAllEmployee();
    }
}
