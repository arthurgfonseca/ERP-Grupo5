namespace ERP
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using ERP.LoginUI;
    using ErpAdministracaoModel;
    using System.ServiceModel;
    using ERP.Web;

    /// <summary>
    /// <see cref="UserControl"/> class providing the main UI for the application.
    /// </summary>
    public partial class MainPage : UserControl
    {
        /// <summary>
        /// Creates a new <see cref="MainPage"/> instance.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            this.loginContainer.Child = new LoginStatus();
        }

        /// <summary>
        /// After the Frame navigates, ensure the <see cref="HyperlinkButton"/> representing the current page is selected
        /// </summary>
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            foreach (UIElement child in LinksStackPanel.Children)
            {
                HyperlinkButton hb = child as HyperlinkButton;
                if (hb != null && hb.NavigateUri != null)
                {
                    if (hb.NavigateUri.ToString().Equals(e.Uri.ToString()))
                    {
                        VisualStateManager.GoToState(hb, "ActiveLink", true);
                    }
                    else
                    {
                        VisualStateManager.GoToState(hb, "InactiveLink", true);
                    }
                }
            }
        }

        /// <summary>
        /// If an error occurs during navigation, show an error window
        /// </summary>
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ErrorWindow.CreateNew(e.Exception);
        }

        private void convenioPlanoSaudeSetDomainDataSource_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            ConvenioPlanoSaudeSet novoConvenio = new ConvenioPlanoSaudeSet();
            
            novoConvenio.codigo = int.Parse(codigoTextBox.Text);
            novoConvenio.empresa = empresaTextBox.Text;
            novoConvenio.observacoes = observacoesTextBox.Text;
            novoConvenio.plano = planoTextBox.Text;
            novoConvenio.telefone = telefoneTextBox.Text;

            ERP.Web.AdministracaoContext administracaoContext = new Web.AdministracaoContext();
        }
    }
}