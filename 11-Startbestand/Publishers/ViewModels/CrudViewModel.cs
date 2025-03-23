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
        Employee selectedEmployee;

 
        private IEmployeesRepository _employeeRepository;

        public CrudViewModel(IEmployeesRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RefreshEmployees();
            SelectedEmployee = new Employee();

        }

        [RelayCommand]
        private void RefreshEmployees()
        {
            Employees = new ObservableCollection<Employee>(_employeeRepository.OphalenEmployeesMetUitgeverEnJob());
        }


        [RelayCommand]
        public void Toevoegen()
        {
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