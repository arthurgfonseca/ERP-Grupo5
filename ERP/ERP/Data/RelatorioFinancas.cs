using System;
using System.Net;

namespace ERP.Data
{
    public class RelatorioFinancas
    {
        public int registrosContagem { get; set; }

        public decimal valorRegistroTotal { get; set; }

        public RelatorioFinancas(int registrosContagem, decimal valorRegistroTotal)
        {
            this.registrosContagem = registrosContagem;
            this.valorRegistroTotal = valorRegistroTotal;
        }

        public RelatorioFinancas()
        {
        }
    }
}
