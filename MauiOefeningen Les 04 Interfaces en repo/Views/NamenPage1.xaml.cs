namespace MauiOefeningen.Views;

public partial class NamenPage1 : ContentPage
{
	public NamenPage1(NamenViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}