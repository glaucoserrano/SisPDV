using System.Reflection;
using System.Text.RegularExpressions;

namespace SisPDV.Domain.Helpers
{
    public class ValidationHelper
    {
        public static bool ValidCPF(string cpf)
        {
            cpf = FormatHelper.OnlyNumber(cpf);
            if (cpf.Length != 11 || cpf.Distinct().Count() == 1) return false;

            var multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCpf = cpf.Substring(0, 9);
            var sum = tempCpf.Select((t, i) => int.Parse(t.ToString()) * multiplier1[i]).Sum();
            var rest = sum % 11;
            var digit = rest < 2 ? 0 : 11 - rest;
            tempCpf += digit;

            sum = tempCpf.Select((t, i) => int.Parse(t.ToString()) * multiplier2[i]).Sum();
            rest = sum % 11;
            digit = rest < 2 ? 0 : 11 - rest;
            tempCpf += digit;

            return cpf.EndsWith(tempCpf.Substring(9, 2));
        }
        public static bool ValidCNPJ(string cnpj)
        {
            cnpj = FormatHelper.OnlyNumber(cnpj);
            if (cnpj.Length != 14 || cnpj.Distinct().Count() == 1) return false;

            var multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCnpj = cnpj.Substring(0, 12);
            var sum = tempCnpj.Select((t, i) => int.Parse(t.ToString()) * multiplier1[i]).Sum();
            var rest = sum % 11;
            var digit = rest < 2 ? 0 : 11 - rest;
            tempCnpj += digit;

            sum = tempCnpj.Select((t, i) => int.Parse(t.ToString()) * multiplier2[i]).Sum();
            rest = sum % 11;
            digit = rest < 2 ? 0 : 11 - rest;
            tempCnpj += digit;

            return cnpj.EndsWith(tempCnpj.Substring(12, 2));
        }
        public static bool JustNumbers(char text)
        {
            if(!char.IsControl(text) && !char.IsDigit(text)) return true;

            return false;
        }
        public static bool JustDecimal(string existingText, char text)
        {           
            if (!char.IsControl(text) && !char.IsDigit(text) && text != '.')
                return  true;

            // Impede mais de um ponto decimal
            if (text == '.' && existingText.Contains('.'))
                return true;

            return false;
        }
    }
}
