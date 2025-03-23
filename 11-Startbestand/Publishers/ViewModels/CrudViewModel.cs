using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Publishers.ViewModels
{
    public partial class CrudViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<Employee> employees;

        [ObservableProperty]
        ObservableCollection<Job> jobs;

        [ObservableProperty]
        ObservableCollection<Publisher> publishers;

        [ObservableProperty]
        Employee selectedEmployee;


        private IEmployeesRepository _employeeRepository;
        private IJobsRepository _jobsRepository;
        private IPublishersRepository _publishersRepository;

        public CrudViewModel(IEmployeesRepository employeeRepository, IJobsRepository jobsRepository,IPublishersRepository publishersRepository)
        {
            _employeeRepository = employeeRepository;
            _jobsRepository = jobsRepository;
            _publishersRepository = publishersRepository;

            RefreshEmployees();
            SelectedEmployee = new Employee();
            Jobs = new ObservableCollection<Job>(_jobsRepository.OphalenJobs());
            Publishers = new ObservableCollection<Publisher>(_publishersRepository.OphalenPublishers());

        }

        [RelayCommand]
        private void RefreshEmployees()
        {
            Employees = new ObservableCollection<Employee>(_employeeRepository.OphalenEmployeesMetUitgeverEnJob());
        }


        [RelayCommand]
        public void Toevoegen()
        {
            SelectedEmployee.Code = Guid.NewGuid().ToString().Substring(0, 8);
            var result = _employeeRepository.ToevoegenEmployee(SelectedEmployee);

            if (result)
            {
                RefreshEmployees();
                SelectedEmployee = new();

            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het toevoegen van het order", "OK");
            }
        }

        [RelayCommand]
        public void Wijzigen()
        {
            var result = _employeeRepository.WijzigenEmployee(SelectedEmployee);

            if (result)
            {
                RefreshEmployees();
                SelectedEmployee = new Employee();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het wijzigen van de werknemer", "OK");
            }
        }


        [RelayCommand]
        public void Verwijderen()
        {
            var result = _employeeRepository.VerwijderenEmployee(SelectedEmployee.Id);

            if (result)
            {
                RefreshEmployees();
                SelectedEmployee = new Employee();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het verwijderen van de werknemer", "OK");
            }
        }

        [RelayCommand]
        public void Deselecteren()
        {
            SelectedEmployee = new Employee();
        }


    }
}