﻿#pragma checksum "C:\Users\Danilo\Documents\Visual Studio 2010\Projects\PCS2046\ERP\ERP\TestCRUDPlanosSaude.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B5CA282A329751264FEDA0F07241C475"
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
    
    
    public partial class TestCRUDPlanosSaude : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.DomainDataSource convenioPlanoSaudeSetDomainDataSource;
        
        internal System.Windows.Controls.DataGrid convenioPlanoSaudeSetDataGrid;
        
        internal System.Windows.Controls.DataGridTextColumn codigoColumn;
        
        internal System.Windows.Controls.DataGridTextColumn empresaColumn;
        
        internal System.Windows.Controls.DataGridTextColumn observacoesColumn;
        
        internal System.Windows.Controls.DataGridTextColumn planoColumn;
        
        internal System.Windows.Controls.DataGridTextColumn telefoneColumn;
        
        internal System.Windows.Controls.Button btnInserir;
        
        internal System.Windows.Controls.Grid grid1;
        
        internal System.Windows.Controls.TextBox empresaTextBox;
        
        internal System.Windows.Controls.TextBox observacoesTextBox;
        
        internal System.Windows.Controls.TextBox planoTextBox;
        
        internal System.Windows.Controls.TextBox telefoneTextBox;
        
        internal System.Windows.Controls.Label label1;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ERP;component/TestCRUDPlanosSaude.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.convenioPlanoSaudeSetDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("convenioPlanoSaudeSetDomainDataSource")));
            this.convenioPlanoSaudeSetDataGrid = ((System.Windows.Controls.DataGrid)(this.FindName("convenioPlanoSaudeSetDataGrid")));
            this.codigoColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("codigoColumn")));
            this.empresaColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("empresaColumn")));
            this.observacoesColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("observacoesColumn")));
            this.planoColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("planoColumn")));
            this.telefoneColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("telefoneColumn")));
            this.btnInserir = ((System.Windows.Controls.Button)(this.FindName("btnInserir")));
            this.grid1 = ((System.Windows.Controls.Grid)(this.FindName("grid1")));
            this.empresaTextBox = ((System.Windows.Controls.TextBox)(this.FindName("empresaTextBox")));
            this.observacoesTextBox = ((System.Windows.Controls.TextBox)(this.FindName("observacoesTextBox")));
            this.planoTextBox = ((System.Windows.Controls.TextBox)(this.FindName("planoTextBox")));
            this.telefoneTextBox = ((System.Windows.Controls.TextBox)(this.FindName("telefoneTextBox")));
            this.label1 = ((System.Windows.Controls.Label)(this.FindName("label1")));
        }
    }
}
