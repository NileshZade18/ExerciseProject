using ExerciseProject.CustomAttribute;
using ExerciseProject.Models.DataDriven;
using ExerciseProject.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeRespository EmployeeRespository { get; }
        public EmployeeController(IEmployeeRespository employeeRespository)
        {
            EmployeeRespository = employeeRespository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await EmployeeRespository.GetAllEmployee();
            return Ok(result);
        }

        [HttpPost]
        [ModelValidate]
        public async Task<IActionResult> AddEmpoyee(EmployeeDTO employeeDTO)
        {
            var result = await EmployeeRespository.AddEmployee(employeeDTO);
            return Ok(result);
        }
    }
}
