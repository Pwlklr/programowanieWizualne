using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data; 
using System.Windows.Input;
using _156023_155875.ProgWiz.INTERFACES;

namespace _156023_155875.ProgWiz.BL
{
    public class MainViewModel : ViewModelBase
    {
        private IDataAccessObject _dao;
        private ShoeViewModel _selectedShoe;
        private string _filterText;

        public ObservableCollection<ShoeViewModel> Shoes { get; set; }

        public ICollectionView ShoesView { get; private set; }

        public List<IProducer> Producers { get; set; }

        public ICommand DeleteCommand { get; private set; }

        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                OnPropertyChanged();
                ShoesView.Refresh(); 
            }
        }

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

            LoadShoes();

            DeleteCommand = new RelayCommand(
                param => DeleteSelected(),
                param => SelectedShoe != null
            );
        }

        private void LoadShoes()
        {
            var shoesModels = _dao.GetAllShoes();
            Shoes = new ObservableCollection<ShoeViewModel>();
            foreach (var shoe in shoesModels)
            {
                Shoes.Add(new ShoeViewModel(shoe));
            }

            ShoesView = CollectionViewSource.GetDefaultView(Shoes);
            ShoesView.Filter = FilterShoes;
        }

        private bool FilterShoes(object item)
        {
            if (string.IsNullOrWhiteSpace(FilterText)) return true;

            var shoe = item as ShoeViewModel;
            if (shoe == null) return false;

            return shoe.Name.IndexOf(FilterText, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void DeleteSelected()
        {
            if (SelectedShoe != null)
            {
                
                _dao.RemoveShoe(SelectedShoe.Id);
                Shoes.Remove(SelectedShoe);
                SelectedShoe = null;
            }
        }

        public void RefreshData()
        {
            Producers = new List<IProducer>(_dao.GetAllProducers());
            OnPropertyChanged(nameof(Producers)); 

            LoadShoes();
            OnPropertyChanged(nameof(Shoes));
            OnPropertyChanged(nameof(ShoesView));
        }
    }
}