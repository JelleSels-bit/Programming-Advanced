using MauiOefeningen.viewmodel;

namespace MauiOefeningen.Views;

public partial class PersoonPage : ContentPage
{
	public PersoonPage(PersoonViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}