namespace SisPDV.Application.DTOs.Person
{
    public class PersonGridDTO
    {
        public int? Id { get; set; }
        public string CNPJ_CPF { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Types
        {
            get
            {
                var types = new List<string>();
                if (IsCustomer) types.Add("Cliente");
                if (IsSupplier) types.Add("Fornecedor");
                if (IsCarrier) types.Add("Transportadora");
                return string.Join(", ", types);
            }
        }

        public bool IsCustomer { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsCarrier { get; set; }
    }

}
