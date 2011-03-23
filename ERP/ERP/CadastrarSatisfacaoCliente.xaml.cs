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
    public partial class CadastrarSatisfacaoCliente : Page
    {
        public CadastrarSatisfacaoCliente()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void satisfacaoClienteSetDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }
        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            ERP.Web.QualidadeContext QualidadeClienteContext = new Web.QualidadeContext();

            try
            {
                SatisfacaoClienteSet novoCliente = new SatisfacaoClienteSet();

                novoCliente.comentarios = comentariosTextBox.Text;
                novoCliente.data_avaliacao = Convert.ToDateTime(data_avaliacaoDatePicker.Text);
                novoCliente.nome = nomeTextBox.Text;
                novoCliente.nota_final = Convert.ToDecimal(nota_finalTextBox.Text);
                novoCliente.qualidade_atendimento = Convert.ToDecimal(qualidade_atendimentoTextBox.Text);
                novoCliente.tempo_espera = Convert.ToDecimal(tempo_esperaTextBox.Text);

                QualidadeClienteContext.SatisfacaoClienteSets.Add(novoCliente);
                QualidadeClienteContext.SubmitChanges();

            }
            catch (Exception ex)
            {
            }


        }

    }
}
