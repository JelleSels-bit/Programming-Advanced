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

    [ObservableProperty]
    private string stringOutput;

    [ObservableProperty]
    private string auteurZoekterm;

    private IEmployeesRepository _employeesRepository;
    private IPublishersRepository _publisherRepository;
    private IBookRepository _bookRepository;
    private ISalesRepository _salesRepository;
    private IStoresRepository _storesRepository;

    public NavigationPropertiesViewModel(IEmployeesRepository employeesRepository, IPublishersRepository publisherRepository, IBookRepository bookRepository, ISalesRepository salesRepository, IStoresRepository storesRepository)
    {
        _employeesRepository = employeesRepository;
        _publisherRepository = publisherRepository;
        _bookRepository = bookRepository;
        _salesRepository = salesRepository;
        _storesRepository = storesRepository;

        uitgeverZoekterm = string.Empty;
        boekZoekterm = string.Empty;
        auteurZoekterm = string.Empty;
    }

    partial void OnSelectedObjectChanging(object value)
    {
        var selectedItem = value;

        if (selectedItem is Publisher)
        {
            StringOutput = "Publicaties:";
            var publisher = (Publisher)selectedItem;

            StringOutput += publisher.TitleInfo();
        }

        if (selectedItem is Book)
        {
            StringOutput = "Boeken:";
            var book = (Book)selectedItem;

            StringOutput += book.AuthorInfo();
        }

        if (selectedItem is Store)
        {
            StringOutput = "Winkels:\n";
            var store = (Store)selectedItem;

            StringOutput += store.SaleInfo();
        }
    }



    [RelayCommand]
    public void OphalenWinkels()
    {
        IsBusy = true;
        Items = new ObservableCollection<object>(_storesRepository.OphalenStoresSalesBoeken());
        IsBusy = false;
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
        Items = new ObservableCollection<object>(_bookRepository.OphalenBoekenMetZoekterm(BoekZoekterm, UitgeverZoekterm,AuteurZoekterm));
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
