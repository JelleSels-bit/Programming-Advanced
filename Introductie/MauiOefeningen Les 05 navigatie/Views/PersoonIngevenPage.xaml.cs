namespace MauiOefeningen.Views;

public partial class PersoonIngevenPage : ContentPage
{
	public PersoonIngevenPage(PersonenIngevenViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}