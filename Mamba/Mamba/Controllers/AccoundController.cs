using Mamba.Business.DTOs.RegisterDto;
using Mamba.Core.Entites;
using Mamba.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mamba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccoundController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccoundController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm]Registerdto dto)
        {
            if(dto== null)return BadRequest();
           
            User user = new User()
            {
                Fullname = dto.Fullname,
                UserName=dto.Username,
                Email = dto.Email
            };

            var result = await userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    return BadRequest(item.Description);
                }
            }
            await signInManager.SignInAsync(user, isPersistent: false);
            return Ok();
        }
    
    }
}
