using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProject.Models.Domain
{
    public class SalaryDetails
    {
        [Key]
        public int SalaryId { get; set; }
        public string BankName { get; set; }
        public string IFCcode { get; set; }
        public string AcNo { get; set; }
    }
}
