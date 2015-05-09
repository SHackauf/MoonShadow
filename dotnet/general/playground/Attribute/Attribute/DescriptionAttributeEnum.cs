using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    public enum DescriptionAttributeEnum
    {
        [Description("Null")]
        Null = 0,

        [Description("One")]
        One = 1,

        Two = 2
    }

    public static class DescriptionAttributeEnumExtensions
    {
        public static string GetDescription(this DescriptionAttributeEnum parameter)
        {
            var attributes = (DescriptionAttribute[]) parameter.GetType().GetField(parameter.ToString()).GetCustomAttributes(
                    typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
