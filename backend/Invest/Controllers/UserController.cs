using Invest.Application.Interfaces;
using Invest.Application.ViewModels.Users;
using Invest.CrossCutting.Auth.Interfaces;
using Invest.CrossCutting.Auth.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invest.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthService authService;

        public UserController(IUserService service, IAuthService authService)
        {
            this.userService = service;
            this.authService = authService;
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(UserRequestCreateAccountViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userService.Post(user, Request.Host.Value));
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult Authenticate(UserRequestAuthenticateViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userService.Authenticate(user));
        }

        [HttpGet("forgot-password/{document}"), AllowAnonymous]
        public IActionResult ForgotPassword(string document)
        {
            return Ok(userService.ForgotPassword(document));
        }

        [HttpPost("change-password"), AllowAnonymous]
        public IActionResult ChangePassword(UserRequestChangePasswordViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userService.ChangePassword(user));
        }

        [HttpGet("activate/{userId}")]
        public IActionResult ActivateUser(int userId)
        {
            ContextUserViewModel _user = authService.GetLoggedUser();
            if (_user == null)
                return Unauthorized();

            return Ok(userService.ActivateUser(userId));
        }

        [HttpGet("deactivate/{userId}")]
        public IActionResult DeactivateUser(int userId)
        {
            ContextUserViewModel _user = authService.GetLoggedUser();
            if (_user == null)
                return Unauthorized();

            return Ok(userService.DeactivateUser(userId));
        }

        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            ContextUserViewModel _user = authService.GetLoggedUser();
            if (_user == null)
                return Unauthorized();

            return Ok(userService.GetById(userId));
        }

        [HttpGet("activate/{document}/{code}"), AllowAnonymous]
        public IActionResult ActivateByDocument(string document, string code)
        {
            userService.ActivateByDocument(document, code);
            return Redirect("https://" + Request.Host.Value);
        }

        [HttpGet("list")]
        public IActionResult GetAll()
        {
            var users = userService.GetAll();
            if (users == null)
                return NotFound();

            return Ok(users);
        }

        [HttpGet]
        public IActionResult Get()
        {
            ContextUserViewModel _user = authService.GetLoggedUser();
            if (_user == null)
                return Unauthorized();

            return Ok(userService.Get());
        }

        [HttpPut]
        public IActionResult Put(UserUpdateAccount user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userService.Put(user));
        }
    }
}