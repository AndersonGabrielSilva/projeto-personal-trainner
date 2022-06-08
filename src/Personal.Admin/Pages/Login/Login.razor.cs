using Microsoft.AspNetCore.Components;
using Personal.Admin.Model.Login;
using Personal.Admin.Service;

namespace Personal.Admin.Pages.Login;

public class LoginBase : ComponentBase
{
    #region Inject
    [Inject]
    protected IAuthService AuthService { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }
    #endregion

    #region Propriedades
    protected LoginModel loginModel { get; set; }
    protected bool ShowErrors { get; set; }
    protected string Error { get; set; }
    #endregion

    #region Construtor
    public LoginBase()
    {
        loginModel = new LoginModel();
    }
    #endregion

    #region Eventos
    protected async Task HandleLogin()
    {
        ShowErrors = false;

        var result = await AuthService.Login(loginModel);

        if (result.Successful)
        {
            NavigationManager.NavigateTo("/");
        }
        else
        {
            Error = result.Error;
            ShowErrors = true;
        }
    }
    #endregion
}
