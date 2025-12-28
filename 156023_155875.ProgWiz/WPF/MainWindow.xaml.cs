using System.Windows;
using _156023_155875.ProgWiz.BL;
using _156023_155875.ProgWiz.INTERFACES;

namespace _156023_155875.ProgWiz.WPF
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        private IDataAccessObject _dao;

        public MainWindow()
        {
            InitializeComponent();

            _dao = new DAOMock.DAOMock();
            _viewModel = new MainViewModel(_dao);
            this.DataContext = _viewModel;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var addWin = new AddWindow(_dao);
            bool? result = addWin.ShowDialog();

            if (result == true)
            {
                _viewModel.RefreshData();
            }
        }
    }
}