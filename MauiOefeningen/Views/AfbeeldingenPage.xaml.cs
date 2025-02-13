namespace MauiOefeningen.Views;

public partial class AfbeeldingenPage : ContentPage
{
	public AfbeeldingenPage(AfbeeldingViewModel vm) 
	{
		InitializeComponent();
		BindingContext = vm;
	}
}