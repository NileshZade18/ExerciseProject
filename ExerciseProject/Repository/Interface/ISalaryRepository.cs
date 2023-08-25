using ExerciseProject.Models.DataDriven;

namespace ExerciseProject.Repository.Interface
{
    public interface ISalaryRepository
    {
        Task<SalaryDTO> GetById(int id);
        Task<List<SalaryDTO>> GetAll();
        Task<bool> AddSalary(SalaryDTO salaryDetails);
    }
}
