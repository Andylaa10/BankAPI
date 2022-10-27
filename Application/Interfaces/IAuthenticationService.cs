using Application.DTOs;

namespace Application.Interfaces;

public interface IAuthenticationService
{
    string Register(LoginAndRegisterDTO dto);
    
    string Login(LoginAndRegisterDTO dto);
}