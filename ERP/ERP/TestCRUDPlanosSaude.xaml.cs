﻿using System;
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
using ErpAdministracaoModel;
using ERP.Web;
using System.ServiceModel.DomainServices.Client;

namespace ERP
{
    public partial class TestCRUDPlanosSaude : Page
    {
        private AdministracaoContext administracaoContext = new Web.AdministracaoContext();

        public TestCRUDPlanosSaude()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void convenioPlanoSaudeSetDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            ERP.Web.AdministracaoContext administracaoContext = new Web.AdministracaoContext();

            try
            {
                ConvenioPlanoSaudeSet novoConvenio = new ConvenioPlanoSaudeSet();

                novoConvenio.codigo = 0;
                novoConvenio.empresa = empresaTextBox.Text;
                novoConvenio.observacoes = observacoesTextBox.Text;
                novoConvenio.plano = planoTextBox.Text;
                novoConvenio.telefone = telefoneTextBox.Text;

                administracaoContext.ConvenioPlanoSaudeSets.Add(novoConvenio);
                administracaoContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                //TODO: error handler
            }
            

        }

        private void convenioPlanoSaudeSetDataGrid_RowEditEnded(object sender, DataGridRowEditEndedEventArgs e)
        {
            try
            {
                administracaoContext.SubmitChanges(OnSubmitCompleted, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Atualização de Plano de Saúde Falhou: {0}", ex.ToString()));
            }
        }
        
        private void OnSubmitCompleted(SubmitOperation so)
        {
            if ((so.HasError))
            {
                MessageBox.Show(string.Format("Atualização de Plano de Saúde Falhou: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            else
            {
                MessageBox.Show("Plano de Saúde atualizado");
            }
        }

    }
}
