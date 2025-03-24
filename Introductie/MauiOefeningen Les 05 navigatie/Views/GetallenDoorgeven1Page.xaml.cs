namespace MauiOefeningen.Views;

public partial class GetallenDoorgeven1Page : ContentPage
{
	public GetallenDoorgeven1Page(GetallenDoorGeven1ViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}