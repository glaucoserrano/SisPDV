using SisPDV.APP.Infrastructure.FormNames;
using System.Reflection;

namespace SisPDV.APP.Helpers
{
    public static class ValidadateForNames
    {
        public static void ValidateFormNames(IServiceProvider provider)
        {
            var fields = typeof(FormNames).GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var field in fields)
            {
                var typeName = field.GetValue(null) as string;
                var type = Type.GetType(typeName);
                if (type == null)
                {
                    Console.WriteLine($"[ERRO] Tipo não encontrado: {typeName}");
                }
                else
                {
                    var form = provider.GetService(type);
                    if (form == null)
                    {
                        Console.WriteLine($"[ERRO] Form não registrado no DI: {type.FullName}");
                    }
                }
            }
        }
    }
}
