namespace MyRent.Blazor.WebSite.Customization
{
    public interface IConfigurator
    {
        public Dictionary<string, List<KeyValuePair<(string, bool), string>>> EntitySetMapper { get; }
        public Dictionary<string, string> EntitySetNameMapper { get; }

    }
    public class Configurator : IConfigurator
    {
        public Configurator() 
        {
            EntitySetMapper = new Dictionary<string, List<KeyValuePair<(string, bool), string>>> ()
            {
                { "Apartments" , new List<KeyValuePair<(string,bool), string>>()
                    {
                        KeyValuePair.Create(("",false),"Detail"),
                        KeyValuePair.Create(("Name",true),"Name"),
                        KeyValuePair.Create(("Owner",true),"Owner"),
                        KeyValuePair.Create(("Contact",true),"Contact"),
                        KeyValuePair.Create(("Type",true),"Type")
                    }
                }
            };

            EntitySetNameMapper = new Dictionary<string, string>()
            {
                { "Apartments", "Apartments"}
            };


        }
        public Dictionary<string, List<KeyValuePair<(string, bool), string>>> EntitySetMapper { get; }
        public Dictionary<string, string> EntitySetNameMapper { get; }

    }
}
