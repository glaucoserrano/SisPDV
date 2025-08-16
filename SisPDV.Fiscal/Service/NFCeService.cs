using DFe.Classes.Entidades;
using DFe.Classes.Flags;
using DFe.Utils;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Utils;
using SisPDV.Fiscal.DOT;
using System;
using System.Runtime.InteropServices;

namespace SisPDV.Fiscal.Service
{
    [ComVisible(true)]
    [Guid("d008b6d5-dc7b-4252-a794-67f4adbfffc0")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class NFCeService
    {
        private static ConfiguracaoServico _cfgServico;

        public NFCeService()
        {
        }
        public void NFceConfig(ConfigNFceDTO ConfigNFce)
        {
            CfgServico = ConfiguracaoServico.Instancia;
            CfgServico.tpAmb = (TipoAmbiente)ConfigNFce.tpEnvironment;
            CfgServico.tpEmis = (TipoEmissao)ConfigNFce.tpEmission;
            Emitente = new emit
            {
                CNPJ = ConfigNFce.EmitterCPF_CNPJ,
                CRT = CRT.SimplesNacional,
            };
            EnderecoEmitente = new enderEmit
            {
                CEP = ConfigNFce._cep,
                xLgr = ConfigNFce.xLgr,
                nro = ConfigNFce.nro,
                xCpl = ConfigNFce.xCpl,
                xBairro = ConfigNFce.xBairro,
                cMun = ConfigNFce.cMun,
                xMun = ConfigNFce.xMun,
                UF = (Estado)Enum.Parse(typeof(Estado), ConfigNFce._uf, true),
                cPais = ConfigNFce.cPais,
                xPais = ConfigNFce.xPais,
                fone = ConfigNFce.fone
            };
            
        }
        public ConfiguracaoServico CfgServico
        {
            get
            {
                ConfiguracaoServico.Instancia.CopiarPropriedades(_cfgServico);
                return _cfgServico;
            }
            set
            {
                _cfgServico = value;
                ConfiguracaoServico.Instancia.CopiarPropriedades(value);

            }
        }
        public emit Emitente { get; set; }
        public enderEmit EnderecoEmitente { get; set; }
    }
}
