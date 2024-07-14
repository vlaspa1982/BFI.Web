using System.ComponentModel;

namespace BFI.Web.Models
{
    public class VersionUpdateType
    {
        [Description("id_sw_type")]
        public int Id { get; set; }

        [Description("st_brand")]
        public string? Brand { get; set; }

        [Description("st_name")]
        public string? Name { get; set; }

    }
}
