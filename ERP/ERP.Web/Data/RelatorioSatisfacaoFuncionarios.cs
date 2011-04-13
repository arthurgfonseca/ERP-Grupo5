using System;
using System.Net;

namespace ERP.Web.Data
{
    public class RelatorioSatisfacaoFuncionarios
    {
        public int funcionariosContagem { get; set; }

        public decimal notaAmbienteTrabalhoMedia { get; set; }

        public decimal notaCologasTrabalhoMedia { get; set; }

        public decimal notaSatisfacaoPessoal { get; set; }

        public decimal notaFinalMedia { get; set; }

        public RelatorioSatisfacaoFuncionarios(int funcionariosContagem, decimal notaAmbienteTrabalhoMedia, decimal notaCologasTrabalhoMedia, decimal notaSatisfacaoPessoal, decimal notaFinalMedia)
        {
            this.funcionariosContagem = funcionariosContagem;
            this.notaAmbienteTrabalhoMedia = notaAmbienteTrabalhoMedia;
            this.notaCologasTrabalhoMedia = notaCologasTrabalhoMedia;
            this.notaSatisfacaoPessoal = notaSatisfacaoPessoal;
            this.notaFinalMedia = notaFinalMedia;
        }

        public RelatorioSatisfacaoFuncionarios()
        {
        }
    }
}
