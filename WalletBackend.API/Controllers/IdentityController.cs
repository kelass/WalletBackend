using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WalletBackend.Data.Models.Identity;
using WalletBackend.Domain.Dtos.Auth;

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
            var managedUser = await _userManager.FindByEmailAsync(model.Email);
            if (managedUser !=null)
            {
                return BadRequest("User already exist");
            }

            if (ModelState.IsValid)
            {
                var user = new WalletUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok("Registration successful");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginAccountDto model)
        {
            var managedUser = await _userManager.FindByEmailAsync(model.Email);
            if (managedUser == null)
            {
                return BadRequest("User does not exist");
            }

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                    return Ok("signed in");
            }

            return BadRequest(ModelState);
        }
        

    }
}
