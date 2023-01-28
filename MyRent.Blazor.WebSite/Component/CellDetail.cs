
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
    public partial class CellDetail
    {
        [Parameter]
        public Int64 ID { get; set; }

        [Parameter]
        public EventCallback<Int64> OnShowFormHandler { get; set; }

        private async Task OnClickDetail(MouseEventArgs e)
        {
            await OnShowFormHandler.InvokeAsync(ID);
        }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
    }
}
