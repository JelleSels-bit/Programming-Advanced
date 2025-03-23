namespace Publishers.ViewModels;

public partial class NavigationPropertiesViewModel : BaseViewModel
{
    [ObservableProperty]
    private string publisher;

    [ObservableProperty]
    ObservableCollection<Employee> employees;

    private IEmployeesRepository _employeesRepository;

    public NavigationPropertiesViewModel() 
    {
        Publisher = string.Empty;
        _employeesRepository = new EmployeesRepository();
        Employees = [];
    }

    [RelayCommand]
    public void WerknemersOphalen()
    {
        IsBusy = true;
        Employees = new ObservableCollection<Employee>(_employeesRepository.OphalenEmployees(Publisher));
        IsBusy = false;
    }
}