using ExerciseProject.CustomAttribute;
using ExerciseProject.Models.DataDriven;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public UserManager<IdentityUser> _UserManager { get; }

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _UserManager = userManager;
        }

        [HttpPost]
        [ModelValidate]
        public async Task<IActionResult> AddUser(AddUserDto model)
        {
            var identityUser = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.UserName
            };
           var result=await _UserManager.CreateAsync(identityUser, model.Password);

            if(result.Succeeded)
            {
               var roleResult= await _UserManager.AddToRoleAsync(identityUser, model.Role);
                if (roleResult.Succeeded)
                    return Ok("Uswer created");
            }
            return Ok("Something went wrong");
        }
    }
}
