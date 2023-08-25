using AutoMapper;
using ExerciseProject.Data;
using ExerciseProject.Models.DataDriven;
using ExerciseProject.Models.Domain;
using ExerciseProject.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ExerciseProject.Repository.Implementation
{
    public class SalaryRepository : ISalaryRepository
    {
        public EmployeeContext _EmployeeContext { get; }
        public IMapper _mapper { get; }

        public SalaryRepository(EmployeeContext dbContext, IMapper mapper)
        {
            _EmployeeContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<SalaryDTO>> GetAll()
        {
            var salary = await _EmployeeContext.salaryDetailsDbSet.ToListAsync();
            return _mapper.Map<List<SalaryDTO>>(salary);
        }

        public async Task<SalaryDTO> GetById(int id)
        {
            var item = await _EmployeeContext.salaryDetailsDbSet.FirstOrDefaultAsync(w => w.SalaryId == id);
            return _mapper.Map<SalaryDTO>(item);
        }

        public async Task<bool> AddSalary(SalaryDTO salaryDetails)
        {
           await _EmployeeContext.salaryDetailsDbSet.AddAsync(_mapper.Map<SalaryDetails>(salaryDetails));
           return Convert.ToBoolean( _EmployeeContext.SaveChanges());
        }
    }
}
