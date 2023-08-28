using AutoMapper;
using ExerciseProject.Data;
using ExerciseProject.Models.DataDriven;
using ExerciseProject.Models.Domain;
using ExerciseProject.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ExerciseProject.Repository.Implementation
{
    public class EmployeeRespository : IEmployeeRespository
    {

        public EmployeeContext _employeeContext { get; }
        public IMapper Mapper { get; }

        public EmployeeRespository(EmployeeContext employeeContext, IMapper mapper)
        {
            _employeeContext = employeeContext;
            Mapper = mapper;
        }

        public async Task<bool> AddEmployee(EmployeeDTO model)
        {
           await _employeeContext.EpmloyeesDbSet.AddAsync(Mapper.Map<Epmloyee>(model));
           return Convert.ToBoolean(_employeeContext.SaveChanges());
        }

        public async Task<List<EmployeeDTO>> GetAllEmployee()
        {
            var rsult1 = await _employeeContext.EpmloyeesDbSet.ToListAsync();

            var rsult = await _employeeContext.EpmloyeesDbSet.Include(s => s.SalaryDetail).ToListAsync();
          return  Mapper.Map<List<EmployeeDTO>>(rsult);
        }
    }
}
