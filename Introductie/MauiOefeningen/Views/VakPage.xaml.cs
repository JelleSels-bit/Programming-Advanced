namespace MauiOefeningen.Views;

public partial class VakPage : ContentPage
{
	public VakPage(VakViewModel vm) 
	{
		InitializeComponent();
		BindingContext = vm;
	}
}