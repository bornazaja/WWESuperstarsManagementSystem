using System;
using System.ComponentModel;
using System.Reflection;

namespace WWESuperstarsManagementSystemLibrary.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription<TEnum>(this TEnum enumValue) where TEnum : struct
        {
            Type type = enumValue.GetType();

            if (!type.IsEnum)
            {
                throw new ArgumentException("Value must be enum type.");
            }

            MemberInfo[] memberInfoArray = type.GetMember(enumValue.ToString());
            if (memberInfoArray != null && memberInfoArray.Length > 0)
            {
                object[] attributes = memberInfoArray[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if(attributes!= null && attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return enumValue.ToString();
        }
    }
}
