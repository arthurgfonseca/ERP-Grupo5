﻿#pragma checksum "C:\Users\Danilo\Documents\Visual Studio 2010\Projects\PCS2046\ERP\ERP\CadastrarPlanoSaude.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "84DEE673A75D9EEAA9BCBE7EDCFAD091"
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


namespace ERP {
    
    
    public partial class CadastrarPlanoSaude : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Label label1;
        
        internal System.Windows.Controls.DomainDataSource convenioPlanoSaudeSetDomainDataSource;
        
        internal System.Windows.Controls.Border border1;
        
        internal System.Windows.Controls.Label label2;
        
        internal System.Windows.Controls.Grid grid1;
        
        internal System.Windows.Controls.TextBox empresaTextBox;
        
        internal System.Windows.Controls.TextBox planoTextBox;
        
        internal System.Windows.Controls.TextBox telefoneTextBox;
        
        internal System.Windows.Controls.TextBox observacoesTextBox;
        
        internal System.Windows.Controls.Label label3;
        
        internal System.Windows.Controls.Label label4;
        
        internal System.Windows.Controls.Label label5;
        
        internal System.Windows.Controls.DomainDataSource servicoMedicoSetDomainDataSource;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        internal System.Windows.Controls.DomainDataSource convenioServicoSetDomainDataSource;
        
        internal System.Windows.Controls.DataGrid grdServicos;
        
        internal System.Windows.Controls.DataGridTextColumn descricaoColumn;
        
        internal System.Windows.Controls.DataGridTextColumn precoColumn;
        
        internal System.Windows.Controls.DataGridTextColumn descontoColumn;
        
        internal System.Windows.Controls.DataGridTextColumn precoDescontoColumn;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ERP;component/CadastrarPlanoSaude.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.label1 = ((System.Windows.Controls.Label)(this.FindName("label1")));
            this.convenioPlanoSaudeSetDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("convenioPlanoSaudeSetDomainDataSource")));
            this.border1 = ((System.Windows.Controls.Border)(this.FindName("border1")));
            this.label2 = ((System.Windows.Controls.Label)(this.FindName("label2")));
            this.grid1 = ((System.Windows.Controls.Grid)(this.FindName("grid1")));
            this.empresaTextBox = ((System.Windows.Controls.TextBox)(this.FindName("empresaTextBox")));
            this.planoTextBox = ((System.Windows.Controls.TextBox)(this.FindName("planoTextBox")));
            this.telefoneTextBox = ((System.Windows.Controls.TextBox)(this.FindName("telefoneTextBox")));
            this.observacoesTextBox = ((System.Windows.Controls.TextBox)(this.FindName("observacoesTextBox")));
            this.label3 = ((System.Windows.Controls.Label)(this.FindName("label3")));
            this.label4 = ((System.Windows.Controls.Label)(this.FindName("label4")));
            this.label5 = ((System.Windows.Controls.Label)(this.FindName("label5")));
            this.servicoMedicoSetDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("servicoMedicoSetDomainDataSource")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
            this.convenioServicoSetDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("convenioServicoSetDomainDataSource")));
            this.grdServicos = ((System.Windows.Controls.DataGrid)(this.FindName("grdServicos")));
            this.descricaoColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("descricaoColumn")));
            this.precoColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("precoColumn")));
            this.descontoColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("descontoColumn")));
            this.precoDescontoColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("precoDescontoColumn")));
        }
    }
}
