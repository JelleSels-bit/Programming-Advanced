namespace Publishers.Views;

public partial class CrudPage : ContentPage
{
    public CrudPage(CrudViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}