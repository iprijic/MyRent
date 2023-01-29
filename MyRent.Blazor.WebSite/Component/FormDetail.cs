
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

        [Parameter]
        public Nullable<Int64> ID { get; set; }

        [Parameter]
        public List<Dictionary<String, Object>> Rows { get; set; }

        private Dictionary<String, Object> selected;


        public async Task OnBack(MouseEventArgs e)
        {
            await OnShowTableHandler.InvokeAsync();
        }

        private void SelectRow()
        {
            foreach(Dictionary<String, Object> row in Rows)
            {
                if(((JsonElement)row["ID"]).GetInt64() == ID)
                {
                    selected = row;
                    break;
                }
            }
        } 

        protected override Task OnInitializedAsync()
        {
            SelectRow();
            return base.OnInitializedAsync();
        }
    }
}
