
using Microsoft.AspNetCore.Components;
using MyRent.Blazor.Web.Customization;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;

namespace MyRent.Blazor.Web.Components
{
    public partial class FormDetail : ControlComponent
    {
        [Parameter]
        public EventCallback OnShowTableHandler { get; set; }
        public async Task OnBack(MouseEventArgs e)
        {
            await OnShowTableHandler.InvokeAsync();
        }
    }
}
