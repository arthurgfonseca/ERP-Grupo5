﻿#pragma checksum "C:\Users\Arthur Fonseca\ERP\ERP-Grupo5\ERP\ERP\Views\ServicoMedico\ListaServicosMedicos.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DEB1BA06F3D370DC65C3396A8AB4E59D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ERP.View.ServicoMedico {
    
    
    public partial class ListaServicosMedicos : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.DomainDataSource servicoMedicoSetDomainDataSource;
        
        internal System.Windows.Controls.Label lblTitulo;
        
        internal System.Windows.Controls.DataGrid servicoMedicoSetDataGrid;
        
        internal System.Windows.Controls.DataGridTextColumn codigoColumn;
        
        internal System.Windows.Controls.DataGridTextColumn descricaoColumn;
        
        internal System.Windows.Controls.DataGridTextColumn nomeColumn;
        
        internal System.Windows.Controls.DataGridTextColumn precoColumn;
        
        internal System.Windows.Controls.DataPager pgrServicoMedico;
        
        internal System.Windows.Controls.Button btnRegistrar;
        
        internal System.Windows.Controls.DataForm dfrServico;
        
        internal System.Windows.Controls.Button btnDeletar;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/ERP;component/Views/ServicoMedico/ListaServicosMedicos.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.servicoMedicoSetDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("servicoMedicoSetDomainDataSource")));
            this.lblTitulo = ((System.Windows.Controls.Label)(this.FindName("lblTitulo")));
            this.servicoMedicoSetDataGrid = ((System.Windows.Controls.DataGrid)(this.FindName("servicoMedicoSetDataGrid")));
            this.codigoColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("codigoColumn")));
            this.descricaoColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("descricaoColumn")));
            this.nomeColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("nomeColumn")));
            this.precoColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("precoColumn")));
            this.pgrServicoMedico = ((System.Windows.Controls.DataPager)(this.FindName("pgrServicoMedico")));
            this.btnRegistrar = ((System.Windows.Controls.Button)(this.FindName("btnRegistrar")));
            this.dfrServico = ((System.Windows.Controls.DataForm)(this.FindName("dfrServico")));
            this.btnDeletar = ((System.Windows.Controls.Button)(this.FindName("btnDeletar")));
        }
    }
}

