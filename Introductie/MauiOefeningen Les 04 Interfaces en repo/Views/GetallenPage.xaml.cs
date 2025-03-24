namespace MauiOefeningen.Views;

public partial class GetallenPage : ContentPage
{
	public GetallenPage(GetallenViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}