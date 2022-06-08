using Microsoft.AspNetCore.Components;
using Personal.Admin.Model.Login;
using Personal.Admin.Service;

namespace Personal.Admin.Pages.Login
{
    public class RegisterBase : ComponentBase
    {
        #region Inject
        [Inject]
        protected IAuthService AuthService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        #endregion

        #region Propriedades
        protected bool ShowErrors { get; set; }
        protected IEnumerable<string> Errors { get; set; }
        protected RegisterModel RegisterModel { get; set; }
        #endregion

        #region Construtor
        public RegisterBase() =>
            RegisterModel = new RegisterModel();
        #endregion

        #region Eventos
        protected async Task HandleRegistration()
        {
            ShowErrors = false;

            var result = await AuthService.Register(RegisterModel);

            if (result.Successful)
                NavigationManager.NavigateTo("/login");
            else
            {
                Errors = result.Errors;
                ShowErrors = true;
            }
        }
        #endregion
    }
}
