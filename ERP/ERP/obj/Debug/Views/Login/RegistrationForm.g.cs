﻿#pragma checksum "C:\Projects\danilo.yokoyama\ERP\ERP\Views\Login\RegistrationForm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "420069D95EDD7F15BA31BC57003E2D82"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ERP.Controls;
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


namespace ERP.LoginUI {
    
    
    public partial class RegistrationForm : System.Windows.Controls.StackPanel {
        
        internal ERP.Controls.BusyIndicator busyIndicator;
        
        internal ERP.Controls.CustomDataForm registerForm;
        
        internal System.Windows.Controls.Button registerButton;
        
        internal System.Windows.Controls.Button registerCancel;
        
        internal System.Windows.Controls.HyperlinkButton backToLogin;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ERP;component/Views/Login/RegistrationForm.xaml", System.UriKind.Relative));
            this.busyIndicator = ((ERP.Controls.BusyIndicator)(this.FindName("busyIndicator")));
            this.registerForm = ((ERP.Controls.CustomDataForm)(this.FindName("registerForm")));
            this.registerButton = ((System.Windows.Controls.Button)(this.FindName("registerButton")));
            this.registerCancel = ((System.Windows.Controls.Button)(this.FindName("registerCancel")));
            this.backToLogin = ((System.Windows.Controls.HyperlinkButton)(this.FindName("backToLogin")));
        }
    }
}

