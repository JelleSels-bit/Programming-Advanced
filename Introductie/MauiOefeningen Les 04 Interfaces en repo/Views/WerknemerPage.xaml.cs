namespace MauiOefeningen.Views;

public partial class WerknemerPage : ContentPage
{
	public WerknemerPage(WerknemerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}