namespace MauiOefeningen
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
            Routing.RegisterRoute(nameof(PersonenTonenPage), typeof(PersonenTonenPage));
            Routing.RegisterRoute(nameof(GetallenDoorgeven2Page), typeof(GetallenDoorgeven2Page));

        }
    }
}
