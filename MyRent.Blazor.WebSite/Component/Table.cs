
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
    public partial class Table : ControlComponent
    {
        [Inject]
        private Configurator? Configurator { get; set; }

        [Inject]
        private HttpClient? HttpClient { get; set; }

        [Inject]
        private IConfiguration AppConfig { get; set; }
 
   
        int count = 0;
        string? entityName;
        List<Dictionary<String, Object>> rows;
        List<KeyValuePair<(string, bool), string>> columns;

        private String filterdata; 

        private async Task Load(String filter)
        {
            HttpResponseMessage response;

            rows = new List<Dictionary<String, Object>>();
            columns = new List<KeyValuePair<(string, bool), string>>();


            if (HttpClient is not null)
            {
                String uri = "http://";

                uri = AppConfig["api"].EndsWith('/') ? AppConfig["api"] : (AppConfig["api"]+ '/');

                if (filter != String.Empty)
                {
                    uri = String.Format("{0}api/object/Apartments?$filter=contains(Name,'{1}')&$expand=Owner,Region,InterierObject&$count=true", uri, filter);
                }
                else
                {
                    uri = String.Format("{0}api/object/Apartments?$expand=Owner,Region,InterierObject&$count=true", uri);

                }

                response = await HttpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Dictionary<String, Object>? json = JsonSerializer.Deserialize<Dictionary<String, Object>>(responseBody);
                if(json is not null && json.ContainsKey("@odata.context"))
                {
                    entityName = ((JsonElement)json["@odata.context"]).GetString()?.Split('#').LastOrDefault();
                    if (entityName.Contains("(") && entityName.Contains(")"))
                        entityName = entityName.Split('(').FirstOrDefault();


                    if (json.ContainsKey("@odata.count"))
                        count = ((JsonElement)json["@odata.count"]).GetInt32();

                    if (json.ContainsKey("value"))
                    {
                        foreach(var item in ((JsonElement)json["value"]).EnumerateArray())
                        {
                            rows.Add(item.Deserialize<Dictionary<String, Object>>());
                        }
                    }
                }

                if (String.IsNullOrEmpty(entityName) == false && Configurator?.EntitySetMapper.ContainsKey(entityName) == true)
                {
                    columns = Configurator.EntitySetMapper[entityName];
                }
            }
        }

        private async Task OnClickFilter(MouseEventArgs args)
        {
            if (String.IsNullOrEmpty(filterdata) == false)
                await Load(filterdata);
            else
                await Load(String.Empty);

            //await Task.CompletedTask;
        }

        protected override Task OnInitializedAsync()
        {
           return Load(String.Empty);

            //StateHasChanged();
           // Task.CompletedTask;
           // return base.OnInitializedAsync();

        }
    }
}



