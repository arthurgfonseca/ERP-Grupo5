using System;
using System.Net;

namespace ERP.Data
{
    public class RelatorioSatisfacaoClientes
    {
        public int clientesContagem { get; set; }

        public decimal tempoEsperaMedio { get; set; }
        
        public decimal qualidadeAtendimentoMedia { get; set; }

        public int outraOpiniaoContagem { get; set; }

        public decimal notaFinalMedia { get; set; }

        public RelatorioSatisfacaoClientes(int clientesContagem, decimal tempoEsperaMedio, decimal qualidadeAtendimentoMedia, int outraOpiniaoContagem, decimal notaFinalMedia)
        {
            this.clientesContagem = clientesContagem;
            this.tempoEsperaMedio = tempoEsperaMedio;
            this.qualidadeAtendimentoMedia = qualidadeAtendimentoMedia;
            this.outraOpiniaoContagem = outraOpiniaoContagem;
            this.notaFinalMedia = notaFinalMedia;
        }

        public RelatorioSatisfacaoClientes()
        {
        }
    }
}
