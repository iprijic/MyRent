using MyRent.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MyRent.Blazor.Web.Customization;

namespace MyRent.Blazor.WebSite.Pages
{
    public partial class Homepage : ComponentBase
    {
        [Inject]
        private Configurator? Configurator { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
    }
}
