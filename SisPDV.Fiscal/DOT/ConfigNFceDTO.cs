using DFe.Classes.Entidades;
using DFe.Classes.Flags;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace SisPDV.Fiscal.DOT
{
    [ComVisible(true)]
    [Guid("A12B3456-C789-4D01-ABCD-1234567890AB")] // Gere um novo GUID
    [ClassInterface(ClassInterfaceType.AutoDual)] // Para expor propriedades diretamente
    public class ConfigNFceDTO
    {
        public int tpEnvironment { get; set; }
        public int tpEmission { get; set; }
        public string EmitterCPF_CNPJ { get; set; }
        public int CRT { get; set; } // 0 - Simples Nacional, 1 - Simples Nacional - Excesso de Receita, 2 - Regime Normal
        public string _cep { get; set; } //C13 - Código do CEP
        public string xLgr { get; set; } //C06 - Logradouro
        public string nro { get; set; } //C07 - Número
        public string xCpl { get; set; } //C08 - Complemento
        public string xBairro { get; set; } //C09 - Bairro
        public long cMun { get; set; } //C10 - Código do município
        public string xMun { get; set; } //C11 - Nome do município, informar EXTERIOR para operações com o exterior.
        public string _uf { get; set; } //C12 - Sigla da UF, informar EX para operações com o exterior.
        public int? cPais { get; set; } = 1058;  //C14 - Código do País
        public string xPais { get; set; } ="BRASIL"; //     C15 - Nome do País
        public long? fone { get; set; } //C16 - Telefone

    }
}
