using System;
using System.Net;

namespace ERP.Web.Data
{
    public class SatisfacaoFuncionarios
    {
        public int id { get; set; }

        public string nome { get; set; }

        public int codigoFuncionario { get; set; }

        public string dataAvailiacao { get; set; }

        public decimal notaAmbienteTrabalho { get; set; }

        public decimal notaColegasTrabalho { get; set; }

        public decimal notaSatisfacaoPessoal { get; set; }

        public decimal notaFinal { get; set; }

        public string comentario { get; set; }

        public SatisfacaoFuncionarios(int id, string nome, int codigoFuncionario, string dataAvailiacao, decimal notaAmbienteTrabalho, decimal notaColegasTrabalho, decimal notaSatisfacaoPessoal, decimal notaFinal, string comentario)
        {
            this.id = id;
            this.nome = nome;
            this.codigoFuncionario = codigoFuncionario;
            this.dataAvailiacao = dataAvailiacao;
            this.notaAmbienteTrabalho = notaAmbienteTrabalho;
            this.notaColegasTrabalho = notaColegasTrabalho;
            this.notaSatisfacaoPessoal = notaSatisfacaoPessoal;
            this.notaFinal = notaFinal;
            this.comentario = comentario;
        }

        public SatisfacaoFuncionarios()
        {
        }
    }
}
