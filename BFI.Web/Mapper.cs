using System.ComponentModel;
using System.Reflection;

namespace BFI.Web
{
    public static class Mapper
    {
        public static string GetDescriptionFromAttribute(MemberInfo member)
        {
            if (member == null) return null;

            var attrib = (DescriptionAttribute)Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute), false);
            return attrib == null ? null : attrib.Description;
        }

    }
}
