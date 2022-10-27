using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _service;
    public AuthController(IAuthenticationService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("login")]
    public ActionResult Login(LoginAndRegisterDTO dto)
    {
        try
        {
            return Ok(_service.Login(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route("register")]
    public ActionResult Register(LoginAndRegisterDTO dto)
    {
        try
        {
            return Ok(_service.Register(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}