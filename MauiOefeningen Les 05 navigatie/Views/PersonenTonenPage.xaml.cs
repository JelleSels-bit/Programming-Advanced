namespace MauiOefeningen.Views;

public partial class PersonenTonenPage : ContentPage
{
	public PersonenTonenPage(PersonenIngevenViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}