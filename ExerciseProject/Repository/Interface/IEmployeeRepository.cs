using ExerciseProject.Models.DataDriven;

namespace ExerciseProject.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<SalaryDTO> GetById(int id);
        Task<List<SalaryDTO>> GetAll();
        Task<bool> AddSalary(SalaryDTO salaryDetails);
    }
}
