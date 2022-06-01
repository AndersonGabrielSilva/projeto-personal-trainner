using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace Personal.Admin.Shared.Utils;

public class BaseComponent : ComponentBase
{
    #region Inject
    [Inject]
    protected ISnackbar Snackbar { get; set; }

    [Inject]
    protected IJSRuntime JS { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    protected HttpClient Http { get; set; }

    [Inject]
    protected NavigationManager Navigation { get; set; }
    #endregion

    #region Eventos
    protected override void OnInitialized()
    {
        Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomRight;
    }
    #endregion
}
