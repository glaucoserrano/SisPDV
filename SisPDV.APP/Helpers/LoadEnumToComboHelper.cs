using System.ComponentModel;

namespace SisPDV.APP.Helpers
{
    public static class LoadEnumToComboHelper
    {
        public static void LoadEnumToComboBox<TEnum>(ComboBox comboBox, bool addDefaultItem = false,
               string defaultText = "00 - Selecione", int? defaultValue = 0) where TEnum : struct, Enum
        {
            var values = Enum.GetValues(typeof(TEnum))
                            .Cast<TEnum>();
            var items = values.Select(e => new
                            {
                                Value = Convert.ToInt32(e),
                                Description = $"{GetEnumDescription(e)}"
                            })
                            .ToList();

           if(addDefaultItem)
            {
                // Adiciona o item padrão "0 - Selecione" no início da lista
                items.Insert(0, new { Value = defaultValue ?? -1, Description = defaultText });
            }
            

            comboBox.DataSource = items;
            comboBox.DisplayMember = "Description";
            comboBox.ValueMember = "Value";
        }
        private static string GetEnumDescription<TEnum>(TEnum value) where TEnum : struct, Enum
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
