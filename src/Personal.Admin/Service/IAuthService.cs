using Personal.Admin.Model.Login;
using Personal.Admin.Model.Login.Result;

namespace Personal.Admin.Service;

public interface IAuthService
{
    Task<LoginResult> Login(LoginModel loginModel);
    Task Logout();
    Task<RegisterResult> Register(RegisterModel registerModel);
}
