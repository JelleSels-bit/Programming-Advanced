namespace MauiOefeningen.Views;

public partial class NaamTonenPage : ContentPage
{
	public NaamTonenPage(NaamTonenViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}