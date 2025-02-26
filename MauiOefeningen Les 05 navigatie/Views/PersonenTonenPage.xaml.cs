namespace MauiOefeningen.Views;

public partial class PersonenTonenPage : ContentPage
{
	public PersonenTonenPage(PersoonTonenViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}