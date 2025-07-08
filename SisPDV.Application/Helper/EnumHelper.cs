using System.ComponentModel;
using System.Reflection;

namespace SisPDV.Application.Helper
{
    public static class EnumHelper
    {
        public static string GetEnumDescription<TEnum>(TEnum value) where TEnum : Enum
        {
            FieldInfo? field = value.GetType().GetField(value.ToString());

            if(field == null) return value.ToString();

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : value.ToString(); 
        }
    }
}
