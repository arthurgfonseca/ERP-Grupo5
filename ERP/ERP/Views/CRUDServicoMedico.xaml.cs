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
using System.ServiceModel.DomainServices.Client;
using System.Collections;
using ERP.Web;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace ERP
{
    public partial class CRUDServicoMedico : Page
    {
        public ObservableCollection<ServicoMedicoSet> listaServicos { get; set; }


        public CRUDServicoMedico()
        {
            InitializeComponent();
            servicoMedicoSetDomainDataSource.SubmittedChanges += new EventHandler<SubmittedChangesEventArgs>(servicoMedicoSetDomainDataSource_SubmittedChanges);
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void servicoMedicoSetDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void dfrServico_EditEnding(object sender, DataFormEditEndingEventArgs e)
        {
            if (e.EditAction.Equals(DataFormEditAction.Commit))
            {
                try
                {
                    servicoMedicoSetDomainDataSource.SubmitChanges();
                    MessageBox.Show("Serviço Médico atualizado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Atualização de Serviço Médico Falhou: {0}", ex.ToString()));
                }
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            ServicoMedicoSet produtoDeletado = (ServicoMedicoSet)servicoMedicoSetDataGrid.SelectedItem;
            AdministracaoContext context = (AdministracaoContext)servicoMedicoSetDomainDataSource.DomainContext;

            if (produtoDeletado != null)
            {
                context.ServicoMedicoSets.Remove(produtoDeletado);
                servicoMedicoSetDomainDataSource.SubmitChanges();
            }
        }

        void servicoMedicoSetDomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e)
        {
            servicoMedicoSetDomainDataSource.Load();
            servicoMedicoSetDataGrid.ItemsSource = servicoMedicoSetDomainDataSource.Data;
            pgrServicoMedico.Source = servicoMedicoSetDomainDataSource.Data;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            RegistroServicoMedico registroProduto = new RegistroServicoMedico();
            registroProduto.Closed += new EventHandler(registroProduto_Closed);
            registroProduto.Show();
        }

        void registroProduto_Closed(object sender, EventArgs e)
        {
            RegistroServicoMedico registro = (RegistroServicoMedico)sender;
            AdministracaoContext context = (AdministracaoContext)servicoMedicoSetDomainDataSource.DomainContext;

            if (registro.DialogResult == true && registro.novoServico != null)
            {
                context.ServicoMedicoSets.Add(registro.novoServico);
                servicoMedicoSetDomainDataSource.SubmitChanges();
            }
        }

    }
}
