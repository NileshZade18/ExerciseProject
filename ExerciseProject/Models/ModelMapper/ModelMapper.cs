using AutoMapper;
using ExerciseProject.Models.DataDriven;
using ExerciseProject.Models.Domain;

namespace ExerciseProject.Models.ModelMapper
{
    public class ModelMapper :Profile
    {
        public ModelMapper()
        {
            CreateMap<SalaryDetails, SalaryDTO>().ReverseMap();
            CreateMap<Epmloyee, EmployeeDTO>().ReverseMap();

        }
    }
}
