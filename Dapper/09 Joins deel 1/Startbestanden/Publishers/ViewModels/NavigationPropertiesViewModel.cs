using Publishers.Data.Interface;

namespace Publishers.ViewModels;

public partial class NavigationPropertiesViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<object> items;

    [ObservableProperty]
    private string uitgeverZoekterm;

    [ObservableProperty]
    private string boekZoekterm;

    [ObservableProperty]
    private object selectedObject;

    private IEmployeesRepository _employeesRepository;
    private IPublishersRepository _publisherRepository;
    private IBookRepository _bookRepository;
    private ISalesRepository _salesRepository;

    public NavigationPropertiesViewModel(IEmployeesRepository employeesRepository, IPublishersRepository publisherRepository, IBookRepository bookRepository, ISalesRepository salesRepository)
    {
        _employeesRepository = employeesRepository;
        _publisherRepository = publisherRepository;
        _bookRepository = bookRepository;
        _salesRepository = salesRepository;

        uitgeverZoekterm = string.Empty;
        boekZoekterm = string.Empty;
    }

    [RelayCommand]
    public void OphalenWerknemers()
    {
        IsBusy = true;
        Title = "Werknemers:";
        Items = new ObservableCollection<object>(_employeesRepository.OphalenEmployeesViaUitgeverenEnJob(UitgeverZoekterm));
        IsBusy = false;
    }

    [RelayCommand]
    public void OphalenUitgever()
    {
        IsBusy = true;
        Title = "Publishers:";
        Items = new ObservableCollection<object>(_publisherRepository.OphalenPublishers(UitgeverZoekterm));
        IsBusy = false;
    }

    [RelayCommand]
    public void OphalenBoeken()
    {
        IsBusy = true;
        Title = "Books:";
        Items = new ObservableCollection<object>(_bookRepository.OphalenBoekenMetZoekterm(BoekZoekterm, UitgeverZoekterm));
        IsBusy = false;
    }

    [RelayCommand]
    public void OphalenSalesVoorBoeken()
    {
        if (SelectedObject == null || SelectedObject is not Book book)
        {
            Shell.Current.DisplayAlert("Fout", "Gelieve een boek te selecteren uit de lijst", "OK");
            return;
        }
        IsBusy = true;
        Title = "Sales of books:";
        Items = new ObservableCollection<object>(_salesRepository.OphalenSalesVoorBoeken(book.Id));

    }

    [RelayCommand]
    public void OphalenSalesVoorPublisher()
    {
        if (SelectedObject == null || SelectedObject is not Publisher publisher)
        {
            Shell.Current.DisplayAlert("Fout", "Gelieve een uitgever te selecteren uit de lijst", "OK");
            return;
        }
        IsBusy = true;
        Title = "Sales of publisher:";
        Items = new ObservableCollection<object>(_salesRepository.OphalenSalesVoorPublisher(publisher.Id));
    }




}
