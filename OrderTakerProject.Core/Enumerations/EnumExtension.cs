using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Enumerations
{
    public static class EnumExtension
    {
        /// <summary>
        /// Returns Description attribute of enum
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isEnumCode"></param>
        /// <returns></returns>
        public static string StringValue(this Enum value, bool isEnumCode = false)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (isEnumCode)
            {
                return value.ToString();
            }
            else
            {
                if (attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            }
        }

        /// <summary>
        /// Returns integer value of enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this Enum value)
        {
            object val = Convert.ChangeType(value, value.GetTypeCode());
            return (int)val;
        }
    }
}
