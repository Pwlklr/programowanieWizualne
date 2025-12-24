using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using CORE;
using INTERFACES;

namespace BL
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ShoeViewModel : ViewModelBase
    {
        private readonly IClimbingShoe _shoe;

        public ShoeViewModel(IClimbingShoe shoe)
        {
            _shoe = shoe;
        }

        public string Name
        {
            get => _shoe.Name;
            set { _shoe.Name = value; OnPropertyChanged(); }
        }

        public double Size
        {
            get => _shoe.Size;
            set { _shoe.Size = value; OnPropertyChanged(); }
        }

        public ClosureType Closure
        {
            get => _shoe.Closure;
            set { _shoe.Closure = value; OnPropertyChanged(); }
        }

        public int ProducerId => _shoe.ProducerId;
    }

    public class MainViewModel : ViewModelBase
    {
        private IDataAccessObject _dao;
        private ShoeViewModel _selectedShoe;

        public ObservableCollection<ShoeViewModel> Shoes { get; set; }
        public List<IProducer> Producers { get; set; }

        public ShoeViewModel SelectedShoe
        {
            get => _selectedShoe;
            set
            {
                _selectedShoe = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedProducerName));
            }
        }

        public string SelectedProducerName
        {
            get
            {
                if (SelectedShoe == null) return "Brak wyboru";
                var producer = Producers.FirstOrDefault(p => p.Id == SelectedShoe.ProducerId);
                return producer?.Name ?? "Nieznany";
            }
        }

        public MainViewModel(IDataAccessObject dao)
        {
            _dao = dao;
            Producers = new List<IProducer>(_dao.GetAllProducers());

            var shoesModels = _dao.GetAllShoes();
            Shoes = new ObservableCollection<ShoeViewModel>();
            foreach (var shoe in shoesModels)
            {
                Shoes.Add(new ShoeViewModel(shoe));
            }
        }
    }
}