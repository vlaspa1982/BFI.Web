using System.ComponentModel;

namespace BFI.Web.Models
{
    public class VersionVM
    {
        public IEnumerable<VersionUpdate> Updates {  get; set; }
        public string Type { get; set; }
        public string ShortName { get; set; }

    }
}
