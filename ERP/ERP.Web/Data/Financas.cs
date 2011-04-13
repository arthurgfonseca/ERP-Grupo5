using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ErpAdministracaoModel;

namespace ERP.Web.Data
{
    public class Financas
    {
        public string dataRegistro { get; set; }

        public string descricaoRegistro { get; set; }

        public string tipoRegistro { get; set; }

        public decimal valorRegistro { get; set; }

        public Financas(string dataRegistro, string descricaoRegistro, string tipoRegistro, decimal valorRegistro)
        {
            this.dataRegistro = dataRegistro;
            this.descricaoRegistro = descricaoRegistro;
            this.tipoRegistro = tipoRegistro;
            this.valorRegistro = valorRegistro;
        }

         public Financas()
        {
        }
    }
}
