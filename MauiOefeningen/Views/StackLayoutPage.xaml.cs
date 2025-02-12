namespace MauiOefeningen.Views;

public partial class StackLayoutPage : ContentPage
{
	public StackLayoutPage(StackLayoutViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}