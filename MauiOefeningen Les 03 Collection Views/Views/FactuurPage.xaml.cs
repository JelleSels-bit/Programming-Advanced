namespace MauiOefeningen.Views;

public partial class FactuurPage : ContentPage
{
	public FactuurPage(FactuurViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}