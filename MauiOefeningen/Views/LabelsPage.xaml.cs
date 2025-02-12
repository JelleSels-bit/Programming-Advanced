namespace MauiOefeningen.Views;

public partial class LabelsPage : ContentPage
{
	public LabelsPage(LabelViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}