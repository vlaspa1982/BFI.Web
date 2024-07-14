using System.ComponentModel;

namespace BFI.Web.Models
{
    public class VersionUpdate
    {
        [Description("id_sw")]
        public int Id { get; set; }

        [Description("st_name")]
        public string SwName { get; set; }

        [Description("id_sw_type")]
        public int TypeId { get; set; }

        [Description("id_user")]
        public int UserId { get; set; }

        [Description("sw_date_create")]
        public DateTime Created { get; set; }

        [Description("sw_date")]
        public DateTime Date { get; set; }

        [Description("sw_generation")]
        public int Generation { get; set; }

        [Description("sw_version")]
        public string? Version { get; set; }

        [Description("sw_desc")]
        public string? Description { get; set; }

        [Description("sw_changes")]
        public List<VersionUpdateChange> Changes { get; set; }

    }
}
