using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("signup")]
    public IActionResult Signup()
    {
        // body validation

        // check if email exists

        // create user

        // generate jwt

        // store jwt in cookies

        return Ok();
    }

    [HttpPost("signin")]
    public IActionResult Signin()
    {
        // body validation

        // check if email exists

        // check if valid password

        // generate jwt

        // store jwt in cookies

        return Ok();
    }

    [HttpPost("signout")]
    public IActionResult Signout()
    {
        // delete jwt from session
        return Ok();
    }

    [HttpGet("currentuser")]
    public IActionResult CurrentUser()
    {
        // return current user or null
        return Ok();
    }
}