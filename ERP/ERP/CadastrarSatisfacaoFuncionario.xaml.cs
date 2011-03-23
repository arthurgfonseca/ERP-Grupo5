using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using ErpQualidadeModel;

namespace ERP
{
    public partial class CadastrarSatisfacaoFuncionario : Page
    {
        public CadastrarSatisfacaoFuncionario()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void satisfacaoFuncionarioSetDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }
        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            ERP.Web.QualidadeContext QualidadeFuncionarioContext = new Web.QualidadeContext();

            try
            {
                SatisfacaoFuncionarioSet novoFuncionario = new SatisfacaoFuncionarioSet();

                novoFuncionario.comentarios = comentariosTextBox.Text;
                novoFuncionario.data_avaliacao = Convert.ToDateTime(data_avaliacaoDatePicker.Text);
                novoFuncionario.codigo_funcionario = codigo_funcionarioTextBox.Text;
                novoFuncionario.nota_final = Convert.ToDecimal(nota_finalTextBox.Text);
                novoFuncionario.nome_funcionario = nome_funcionarioTextBox.Text;
                novoFuncionario.nota_ambiente_trabalho = Convert.ToDecimal(nota_ambiente_trabalhoTextBox.Text);
                novoFuncionario.nota_colegas_trabalho = Convert.ToDecimal(nota_colegas_trabalhoTextBox.Text);
                novoFuncionario.nota_final = Convert.ToDecimal(nota_finalTextBox.Text);
                novoFuncionario.nota_satisfacao_pessoal = Convert.ToDecimal(nota_satisfacao_pessoalTextBox.Text);

                QualidadeFuncionarioContext.SatisfacaoFuncionarioSets.Add(novoFuncionario);
                QualidadeFuncionarioContext.SubmitChanges();

            }
            catch (Exception ex)
            {
            }


        }


    }
}
