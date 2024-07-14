using Newtonsoft.Json;

namespace BFI.Web.Models
{
    public class VersionUpdateChange
    {
        [JsonProperty("sort")]
        public int Sort { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
