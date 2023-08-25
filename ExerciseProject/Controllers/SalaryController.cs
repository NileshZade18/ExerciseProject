using ExerciseProject.Data;
using ExerciseProject.Models.DataDriven;
using ExerciseProject.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        public ISalaryRepository _EmployeeRepository { get; }

        public SalaryController(EmployeeContext employeeContext, ISalaryRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }
  
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _EmployeeRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var result = await _EmployeeRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddSalary(SalaryDTO model)
        {
            var result = await _EmployeeRepository.AddSalary(model);
            return Ok(result);
        }
    }
}
