namespace MauiOefeningen.Views;

public partial class GetallenDoorgeven2Page : ContentPage
{
	public GetallenDoorgeven2Page(GetallenDoorGeven2ViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;	
	}
}