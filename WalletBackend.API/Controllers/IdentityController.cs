using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WalletBackend.Data.Models.Identity;
using WalletBackend.Domain.Dtos;

namespace WalletBackend.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<WalletUser> _userManager;
        private readonly SignInManager<WalletUser> _signInManager;
        public IdentityController(UserManager<WalletUser> userManager, SignInManager<WalletUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterAccountDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new WalletUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok("Registration successful");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

            return BadRequest(ModelState);
        }
    }
}
