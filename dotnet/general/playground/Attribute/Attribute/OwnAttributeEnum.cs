using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    public enum OwnAttributeEnum
    {
        [EnumExtension("Null")]
        Null = 0,

        [EnumExtension("One", DbValue = 1)]
        One = 1,

        Two = 2
    }

    public static class OwnAttributeEnumExtension
    {
        public static string GetDescription(this OwnAttributeEnum parameter)
        {
            var attributes = (EnumExtension[]) parameter.GetType().GetField(parameter.ToString()).GetCustomAttributes(
                    typeof(EnumExtension), false);
            return attributes.Length > 0 ? attributes[0].GetBezeichnung() : string.Empty;
        }

        public static int GetDbValue(this OwnAttributeEnum parameter)
        {
            var attributes = (EnumExtension[])parameter.GetType().GetField(parameter.ToString()).GetCustomAttributes(
                    typeof(EnumExtension), false);
            return attributes.Length > 0 ? attributes[0].DbValue : -1;
        }
    }

    public class EnumExtension : System.Attribute
    {
        public int DbValue;
        private readonly string _bezeichnung;

        public EnumExtension(string aBezeichnung)
        {
            this._bezeichnung = aBezeichnung;
            this.DbValue = 0;
        }

        public string GetBezeichnung()
        {
            return this._bezeichnung;
        }
    }
}
