namespace MauiOefeningen.Views;

public partial class VragenlijstPage : ContentPage
{
	public VragenlijstPage(VragenlijstViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}