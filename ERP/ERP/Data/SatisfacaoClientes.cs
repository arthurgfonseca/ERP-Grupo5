using System;
using System.Net;

namespace ERP.Data
{
    public class SatisfacaoClientes
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string dataAvailiacao { get; set; }

        public decimal tempoEspera { get; set; }

        public decimal qualidadeAtendimento { get; set; }

        public bool outraOpiniao { get; set; }

        public decimal notaFinal { get; set; }

        public string comentario { get; set; }

        public SatisfacaoClientes(int id, string nome, string dataAvailiacao, decimal tempoEspera, decimal qualidadeAtendimento, bool outraOpiniao, decimal notaFinal, string comentario)
        {
            this.id = id;
            this.nome = nome;
            this.dataAvailiacao = dataAvailiacao;
            this.tempoEspera = tempoEspera;
            this.qualidadeAtendimento = qualidadeAtendimento;
            this.outraOpiniao = outraOpiniao;
            this.notaFinal = notaFinal;
            this.comentario = comentario;
        }

        public SatisfacaoClientes()
        {
        }
    }
}
