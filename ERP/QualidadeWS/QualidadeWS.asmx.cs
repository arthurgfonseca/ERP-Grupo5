using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ERPQualidadeModel;

namespace QualidadeWS
{
    /// <summary>
    /// Summary description for QualidadeWS
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class QualidadeWS : System.Web.Services.WebService
    {
        [WebMethod]
        //public List<SatisfacaoClienteSet> ListaSatisfacaoClientes()
        //{
        //    QualidadeService qualidadeService = new QualidadeService();

        //    List<SatisfacaoClienteSet> clientes = qualidadeService.GetSatisfacaoClienteSets().ToList();

        //    return clientes;
        //}
        public DataTable ListaSatisfacaoClientesData(int ano, int mes)
        {
            SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection();

            String connectionStringSettings = ConfigurationManager.ConnectionStrings["erp_qualidadeEntities"].ToString();

            String[] connectionStringSettingsAux = connectionStringSettings.Split('"');

            connectionStringSettings = connectionStringSettingsAux[1];

            sqlConnection.ConnectionString = connectionStringSettings;
            
            string query = "SELECT * FROM SatisfacaoClienteSet WHERE Month(data_avaliacao) = " + mes.ToString() + " AND Year(data_avaliacao) = " + ano.ToString();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "ListaSatisfacaoClientes");

            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables["ListaSatisfacaoClientes"];

            return dataTable;
        }

        [WebMethod]
        //public List<SatisfacaoClienteSet> ListaSatisfacaoClientes()
        //{
        //    QualidadeService qualidadeService = new QualidadeService();

        //    List<SatisfacaoClienteSet> clientes = qualidadeService.GetSatisfacaoClienteSets().ToList();

        //    return clientes;
        //}
        public DataTable ListaSatisfacaoClientes()
        {
            SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection();

            String connectionStringSettings = ConfigurationManager.ConnectionStrings["erp_qualidadeEntities"].ToString();

            String[] connectionStringSettingsAux = connectionStringSettings.Split('"');

            connectionStringSettings = connectionStringSettingsAux[1];

            sqlConnection.ConnectionString = connectionStringSettings;

            string query = "SELECT * FROM SatisfacaoClienteSet";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "ListaSatisfacaoClientes");

            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables["ListaSatisfacaoClientes"];

            return dataTable;
        }

        [WebMethod]
        //public List<SatisfacaoFuncionarioSet> ListaSatisfacaoFuncionarios()
        //{
        //    QualidadeService qualidadeService = new QualidadeService();

        //    List<SatisfacaoFuncionarioSet> funcionarios = qualidadeService.GetSatisfacaoFuncionarioSets().ToList();

        //    return funcionarios;
        //}
        public DataTable ListaSatisfacaoFuncionarios()
        {
            SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection();

            String connectionStringSettings = ConfigurationManager.ConnectionStrings["erp_qualidadeEntities"].ToString();

            String[] connectionStringSettingsAux = connectionStringSettings.Split('"');

            connectionStringSettings = connectionStringSettingsAux[1];

            sqlConnection.ConnectionString = connectionStringSettings;

            string query = "select * from SatisfacaoFuncionarioSet";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "ListaSatisfacaoFuncionarios");

            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables["ListaSatisfacaoFuncionarios"];

            return dataTable;
        }

        [WebMethod]
        //public List<SatisfacaoFuncionarioSet> ListaSatisfacaoFuncionarios()
        //{
        //    QualidadeService qualidadeService = new QualidadeService();

        //    List<SatisfacaoFuncionarioSet> funcionarios = qualidadeService.GetSatisfacaoFuncionarioSets().ToList();

        //    return funcionarios;
        //}
        public DataTable ListaSatisfacaoFuncionariosData(int ano, int mes)
        {
            SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection();

            String connectionStringSettings = ConfigurationManager.ConnectionStrings["erp_qualidadeEntities"].ToString();

            String[] connectionStringSettingsAux = connectionStringSettings.Split('"');

            connectionStringSettings = connectionStringSettingsAux[1];

            sqlConnection.ConnectionString = connectionStringSettings;

            string query = "SELECT * FROM SatisfacaoFuncionarioSet WHERE Month(data_avaliacao) = " + mes.ToString() + " AND Year(data_avaliacao) = " + ano.ToString();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "ListaSatisfacaoFuncionarios");

            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables["ListaSatisfacaoFuncionarios"];

            return dataTable;
        }
    }
}
