namespace ERP
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using ERP.LoginUI;
    using System;
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

            VerificaAutenticacao();

            var ctx = WebContext.Current;

            ctx.Authentication.LoggedIn += (s, e) => DestravaAutenticacao();
            ctx.Authentication.LoggedOut += (s, e) => TravaAutenticacao();
        }

        private void VerificaAutenticacao(bool estaNaHome = false)
        {
            var ctx = WebContext.Current;

            if (!(ctx.User.IsAuthenticated))
                TravaAutenticacao(estaNaHome);
        }

        private void TravaAutenticacao(bool estaNaHome = false)
        {
            LinksStackPanel.Visibility = Visibility.Collapsed;
            if (!estaNaHome)
                ContentFrame.Navigate(new Uri("/Home", UriKind.Relative));
        }

        private void DestravaAutenticacao()
        {
            LinksStackPanel.Visibility = Visibility.Visible;
            ContentFrame.Navigate(new Uri("", UriKind.Relative));
        }

        /// <summary>
        /// After the Frame navigates, ensure the <see cref="HyperlinkButton"/> representing the current page is selected
        /// </summary>
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            foreach (UIElement child in LinksStackPanel.Children)
            {
                var hb = child as HyperlinkButton;
                if (hb != null && hb.NavigateUri != null)
                {
                    VisualStateManager.GoToState(hb,
                                                 hb.NavigateUri.ToString().Equals(e.Uri.ToString())
                                                     ? "ActiveLink"
                                                     : "InactiveLink", true);
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

        private void ContentFrameNavigating(object sender, NavigatingCancelEventArgs e)
        {
            var estaNaHome = e.Uri == new Uri("/Home", UriKind.Relative);
            VerificaAutenticacao(estaNaHome);
        }

        private void convenioPlanoSaudeSetDomainDataSource_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }
    }
}