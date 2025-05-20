namespace SisPDV.APP.Helpers
{
    public static class ComboHelper
    {
        public static async Task LoadComboBoxAsync<T>(
            ComboBox combobox,
            Func<Task<List<T>>> loadDataFunc,
            string displayName,
            string valueMember,
            string defaultDisplay = "Selecione",
            object? defaultValue = null)
        {
            var list = await loadDataFunc();
            var defaultItem = CreateDefaultItem<T>(displayName, valueMember, defaultDisplay, defaultValue);

            list.Insert(0, defaultItem);

            combobox.DataSource= list;
            combobox.DisplayMember = displayName;
            combobox.ValueMember = valueMember;
        }

        private static T CreateDefaultItem<T>(string displayName, string valueMember, string defaultDisplay, object? defaultValue)
        {
            var obj = Activator.CreateInstance<T>();
            var displayProp = typeof(T).GetProperty(displayName);
            var valueProp = typeof(T).GetProperty(valueMember);

            if (displayProp != null && displayProp.CanWrite)
                displayProp.SetValue(obj, defaultDisplay);

            if(valueProp != null && valueProp.CanWrite && defaultValue != null)
                valueProp.SetValue(obj, defaultValue);

            return obj;
        }
    }
}
