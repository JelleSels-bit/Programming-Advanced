using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Orders.ViewModels
{
    public partial class OrdersCrudViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<Order> orders;

        [ObservableProperty]
        public ObservableCollection<Klant> klanten;

        [ObservableProperty]
        public ObservableCollection<Werknemer> werknemers;

        [ObservableProperty]
        public Order selectedOrder;

        [ObservableProperty]
        public string actieLabel = "Nieuw order toevoegen";

        partial void OnSelectedOrderChanged(Order value)
        {
            if (value == null)
            {
                ActieLabel = "Nieuw order toevoegen";
            }
            else
            {
                ActieLabel = "Order wijzigen";
            }
        }

        private IOrderRepository _orderRepository;
        private IKlantRepository _klantRepository;
        private IWerknemerRepository _werknemerRepository;

        public OrdersCrudViewModel(OrderRepository orderRepo, KlantRepository klantRepo, WerknemerRepository werknemerRepo)
        {
            _orderRepository = orderRepo;
            _klantRepository = klantRepo;
            _werknemerRepository = werknemerRepo;
            RefreshOrders();
            Klanten = new ObservableCollection<Klant>(_klantRepository.KlantenOphalen());
            Werknemers = new ObservableCollection<Werknemer>(_werknemerRepository.OphalenWerknemers());
            SelectedOrder = new Order();
        }

        private void RefreshOrders()
        {
            Orders = new ObservableCollection<Order>(_orderRepository.OrdersOphalen());
        }

        [RelayCommand]
        public void Toevoegen()
        {
            bool isFout = false;
            if (SelectedOrder.KlantId == 0)
            {
                Shell.Current.DisplayAlert("fout", "Er is geen klant geselecteerd", "ok");
                isFout = true;
            }

            if (string.IsNullOrWhiteSpace(SelectedOrder.Verzendadres))
            {
                Shell.Current.DisplayAlert("fout", "Verzend adres niet ingevuld", "ok");
                isFout = true;
            }

            if (!isFout)
            {
                
            var result = _orderRepository.ToevoegenOrder(SelectedOrder);

            if (result)
            {
                RefreshOrders();
                SelectedOrder = new Order();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het toevoegen van het order", "OK");
            }
            }
        }


        [RelayCommand]
        public void Wijzigen()
        {
            var result = _orderRepository.WijzigenOrder(SelectedOrder);

            if (result)
            {
                RefreshOrders();
                SelectedOrder = new Order();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het wijzigen van het order", "OK");
            }
        }


        [RelayCommand]
        public void Verwijderen()
        {
            var result = _orderRepository.VerwijderenOrder(SelectedOrder.Id);

            if (result)
            {
                RefreshOrders();
                SelectedOrder = new Order();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het verwijderen van het order", "OK");
            }
        }

        [RelayCommand]
        public void Deselecteren()
        {
            SelectedOrder = new Order();
        }
    }
}
