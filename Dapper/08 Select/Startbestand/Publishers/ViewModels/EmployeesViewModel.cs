using Publishers.Data.Interface;
using Publishers.Models;

namespace Publishers.ViewModels
{
    public partial class EmployeesViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Employee> employees;

        [ObservableProperty]
        private ObservableCollection<Job> jobs;

        [ObservableProperty]
        private ObservableCollection<Publisher> publishers;

        [ObservableProperty]
        private Job selectedJob;

        [ObservableProperty]
        private Publisher selectedPublisher;

        [ObservableProperty]
        private string id = "";

        [ObservableProperty]
        private DateTime hireDate = DateTime.Now;

        private IEmployeeInterface _employeeInterface;
        private IJobRepository _jobRepository;
        private IPublishersRepository _publishersRepository;

        public EmployeesViewModel(IEmployeeInterface employeeInterface, IJobRepository jobRepository, IPublishersRepository publishersRepository)
        {
            _employeeInterface = employeeInterface;
            _jobRepository = jobRepository;
            _publishersRepository = publishersRepository;

            Jobs = new ObservableCollection<Job>(_jobRepository.OphalenJobs());
            Publishers = new ObservableCollection<Publisher>(_publishersRepository.OphalenPublishers());
        }

        [RelayCommand]
        public void OphalenWerknemers()
        {
            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeeInterface.WerknemersOphalen());
            IsBusy = false;
        }

        [RelayCommand]
        public void OphalenWerknemersViaJob()
        {
            if (SelectedJob == null)
            {
                Shell.Current.DisplayAlert("Fout", "Please select a job", "OK");
            }

            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeeInterface.WerknemersOphalenViaJob(SelectedJob.Id));
            IsBusy = false;
        }

        [RelayCommand]
        public void OphalenWerknemersViaPublisher()
        {
            if (SelectedPublisher == null)
            {
                Shell.Current.DisplayAlert("Fout", "Please select a publisher", "OK");
            }

            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeeInterface.WerknemersOphalenViaPublisher(SelectedPublisher.Id));
            IsBusy = false;

        }

        [RelayCommand]
        public void OphalenWerknemerViaJobEnPublisher()
        {
            if (SelectedJob == null)
            {
                Shell.Current.DisplayAlert("Fout", "Please select a job", "OK");
            }

            if (SelectedPublisher == null)
            {
                Shell.Current.DisplayAlert("Fout", "Please select a publisher", "OK");
            }

            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeeInterface.WerknemersOphalenViaJobEnPublisher(SelectedJob.Id,SelectedPublisher.Id));
            IsBusy = false;
        }

        [RelayCommand]
        public void OphalenWerknemersViaAanwerfdatum()
        {
            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeeInterface.WerknemersOphalenViaHireDate(hireDate));
            IsBusy = false;
        }

        [RelayCommand]
        public void OphalenWerknmersViaId()
        {
            if (!int.TryParse(Id, out int id))
            {
                Shell.Current.DisplayAlert("Fout", "Geef een geldig ID", "Sluiten");
            }
            IsBusy = true;
            var employee = _employeeInterface.WerknemerOphalenViaId(id);
            if (employee == null)
            {
                Shell.Current.DisplayAlert("Fout", $"werknemer met id {id} werdt niet gevonden", "OK");
            }
            else
            {
                Shell.Current.DisplayAlert($"Store gevonden", employee.FullName, "Sluiten");
            }
            IsBusy = false;
        }





    }
}