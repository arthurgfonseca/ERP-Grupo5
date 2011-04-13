using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ErpAdministracaoModel;

namespace AdministracaoWS
{
    /// <summary>
    /// Summary description for AdministracaoWS
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AdministracaoWS : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable ListaServicos()
        {
            SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection();

            String connectionStringSettings = ConfigurationManager.ConnectionStrings["erp_administracaoEntities"].ToString();

            String[] connectionStringSettingsAux = connectionStringSettings.Split('"');

            connectionStringSettings = connectionStringSettingsAux[1];

            sqlConnection.ConnectionString = connectionStringSettings;

            string query = "select * from ServicoMedicoSet";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "ListaServicos");

            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables["ListaServicos"];

            return dataTable;
        }

        [WebMethod]
        public DataTable ListaConvenios()
        {
            SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection();

            String connectionStringSettings = ConfigurationManager.ConnectionStrings["erp_administracaoEntities"].ToString();

            String[] connectionStringSettingsAux = connectionStringSettings.Split('"');

            connectionStringSettings = connectionStringSettingsAux[1];

            sqlConnection.ConnectionString = connectionStringSettings;

            string query = "select * from ConvenioPlanoSaudeSet";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "ListaConvenios");

            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables["ListaConvenios"];

            return dataTable;
        }

        [WebMethod]
        public DataTable DadosClinica()
        {
            DataTable dataTable = new DataTable("DadosClinica");
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "name";
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "descricao";
            column.AutoIncrement = false;
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "cnpj";
            column.AutoIncrement = false;
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "cidade";
            column.AutoIncrement = false;
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "estado";
            column.AutoIncrement = false;
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "pais";
            column.AutoIncrement = false;
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "telefone";
            column.AutoIncrement = false;
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "endereco";
            column.AutoIncrement = false;
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "cep";
            column.AutoIncrement = false;
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            row = dataTable.NewRow();
            row["name"] = "Clínica Médica - Poli";
            row["cnpj"] = "123.456.789-00";
            row["cidade"] = "São Paulo";
            row["estado"] = "SP";
            row["pais"] = "Brasil";
            row["telefone"] = "1234-5678";
            row["endereco"] = "Av. Prof. Luciano Gualberto, travessa 3 nº 380";
            row["cep"] = "05508-010";
            dataTable.Rows.Add(row);

            return dataTable;
        }

        [WebMethod]
        public DataTable ListaDescontos()
        {
            SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection();

            String connectionStringSettings = ConfigurationManager.ConnectionStrings["erp_administracaoEntities"].ToString();

            String[] connectionStringSettingsAux = connectionStringSettings.Split('"');

            connectionStringSettings = connectionStringSettingsAux[1];

            sqlConnection.ConnectionString = connectionStringSettings;

            string query = "SELECT ConvenioServicoSet.id, ConvenioPlanoSaude_codigo, ConvenioPlanoSaudeSet.empresa, ConvenioPlanoSaudeSet.plano, ServicoMedicoSet_codigo, ServicoMedicoSet.nome, ServicoMedicoSet.preco, porcentagem_desconto FROM (ConvenioServicoSet LEFT OUTER JOIN ConvenioPlanoSaudeSet ON ConvenioPlanoSaudeSet.codigo = ConvenioPlanoSaude_codigo) LEFT OUTER JOIN ServicoMedicoSet ON ServicoMedicoSet.codigo = ServicoMedicoSet_codigo";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "ListaDescontos");

            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables["ListaDescontos"];

            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "preco_desconto";
            column.AutoIncrement = false;
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            foreach (DataRow row in dataTable.Rows)
            {
                row["preco_desconto"] = Convert.ToDecimal(row["preco"]) - (Convert.ToDecimal(row["preco"]) * Convert.ToDecimal(row["porcentagem_desconto"]) / 100);
            }

            dataTable.AcceptChanges();

            return dataTable;
        }
        

        [WebMethod]
        public DataTable ListaDescontosConvenios(int codigoConvenio)
        {
            SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection();

            String connectionStringSettings = ConfigurationManager.ConnectionStrings["erp_administracaoEntities"].ToString();

            String[] connectionStringSettingsAux = connectionStringSettings.Split('"');

            connectionStringSettings = connectionStringSettingsAux[1];

            sqlConnection.ConnectionString = connectionStringSettings;

            string query = "SELECT ConvenioServicoSet.id, ConvenioPlanoSaude_codigo, ConvenioPlanoSaudeSet.empresa, ConvenioPlanoSaudeSet.plano, ServicoMedicoSet_codigo, ServicoMedicoSet.nome, ServicoMedicoSet.preco, porcentagem_desconto FROM (ConvenioServicoSet LEFT OUTER JOIN ConvenioPlanoSaudeSet ON ConvenioPlanoSaudeSet.codigo = ConvenioPlanoSaude_codigo) LEFT OUTER JOIN ServicoMedicoSet ON ServicoMedicoSet.codigo = ServicoMedicoSet_codigo WHERE ConvenioPlanoSaude_codigo = " + codigoConvenio.ToString();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "ListaDescontosConvenios");

            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables["ListaDescontosConvenios"];

            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "preco_desconto";
            column.AutoIncrement = false;
            column.ReadOnly = false;
            column.Unique = false;
            dataTable.Columns.Add(column);

            foreach (DataRow row in dataTable.Rows)
            {
                row["preco_desconto"] = Convert.ToDecimal(row["preco"]) -(Convert.ToDecimal(row["preco"]) * Convert.ToDecimal(row["porcentagem_desconto"]) / 100);
            }

            dataTable.AcceptChanges();

            return dataTable;
        }
        
    }
}
