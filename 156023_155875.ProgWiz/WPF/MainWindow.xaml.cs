using System.Windows;
using _156023_155875.ProgWiz.BL;
using _156023_155875.ProgWiz.INTERFACES;
using _156023_155875.ProgWiz.CORE;

namespace _156023_155875.ProgWiz.WPF
{ 

    public partial class MainWindow : Window
    {
        private readonly IDataAccessObject _dao;

        public MainWindow(IDataAccessObject dao)
        {
            InitializeComponent();
            _dao = dao;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var newShoe = new WpfShoe();
            var vm = new ShoeViewModel(newShoe);

            AddWindow window = new AddWindow(vm, _dao);

            if (window.ShowDialog() == true)
            {
                if (DataContext is MainViewModel mainVm)
                {
                    _dao.AddShoe(vm.GetModel());
                    mainVm.RefreshData();
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel mainVm && mainVm.SelectedShoe != null)
            {
                var vm = mainVm.SelectedShoe;
                AddWindow window = new AddWindow(vm, _dao);

                if (window.ShowDialog() == true)
                {
                    _dao.UpdateShoe(vm.GetModel());
                    mainVm.RefreshData();
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel mainVm && mainVm.SelectedShoe != null)
            {
                if (MessageBox.Show("Czy na pewno usunąć?", "Potwierdzenie", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _dao.RemoveShoe(mainVm.SelectedShoe.Id);
                    mainVm.RefreshData();
                }
            }
        }
    }

    public class WpfShoe : IClimbingShoe
    {
        public int Id { get; set; }
        public int ProducerId { get; set; }
        public string Name { get; set; } = "";
        public int ProductionYear { get; set; } = System.DateTime.Now.Year;
        public ClosureType Closure { get; set; }
        public double Size { get; set; }
    }
}