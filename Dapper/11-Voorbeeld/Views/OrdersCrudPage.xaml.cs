using Orders.ViewModels;

namespace Orders.Views;

public partial class OrdersCrudPage : ContentPage
{
	public OrdersCrudPage(OrdersCrudViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}