using Microsoft.AspNetCore.Components;
using MyRent.Blazor.Web.Components;
using MyRent.Blazor.Web.Customization;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyRent.Blazor.Web.Components
{
    public partial class CellText : ControlComponent
    {
        [Parameter]
        public string Entity { get; set; }

        [Parameter]
        public KeyValuePair<string, object> Cell { get; set; }

        [Parameter]
        public Dictionary<String, Object> Row { get; set; }

        [Parameter]
        public KeyValuePair<(string, bool), string> Column { get; set; }

        private KeyValuePair<string, object> GetCell(Dictionary<string, object> row, KeyValuePair<(string, bool), string> column) => row.First(k => k.Key == column.Key.Item1);

        private String StringFromJSON(JsonElement jelement)
        {
            return jelement.GetString();
        }

        private int IntFromJSON(JsonElement jelement)
        {
            return jelement.GetInt32();
        }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
    }
}

