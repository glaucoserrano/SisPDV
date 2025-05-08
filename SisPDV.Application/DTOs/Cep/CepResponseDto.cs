namespace SisPDV.Application.DTOs.Cep
{
    public class CepResponseDto
    {
        public string cep { get; set; } = string.Empty;
        public string logradouro { get; set; } = string.Empty;
        public string bairro { get; set; } = string.Empty;
        public string localidade { get; set; } = string.Empty;
        public string uf { get; set; } = string.Empty;
        public string ibge { get; set; } = string.Empty;
    }
}
