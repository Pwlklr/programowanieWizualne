using System.Windows;
using _156023_155875.ProgWiz.BL;
using _156023_155875.ProgWiz.INTERFACES;
using _156023_155875.ProgWiz.CORE;

namespace _156023_155875.ProgWiz.WPF
{
    public partial class AddWindow : Window
    {
        private readonly ShoeViewModel _viewModel;
        private readonly IDataAccessObject _dao;

        public AddWindow(ShoeViewModel viewModel, IDataAccessObject dao)
        {
            InitializeComponent();
            _dao = dao;
            _viewModel = viewModel;

            DataContext = _viewModel;

            LoadProducers();
        }

        private void LoadProducers()
        {
            cbProducers.ItemsSource = _dao.GetAllProducers();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_viewModel.Error) ||
                !string.IsNullOrEmpty(_viewModel["Name"]) ||
                !string.IsNullOrEmpty(_viewModel["ProductionYear"]) ||
                !string.IsNullOrEmpty(_viewModel["Size"]))
            {
                MessageBox.Show("Popraw błędy w formularzu przed zapisaniem.", "Błąd walidacji", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void BtnAddProducer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewProducer.Text))
            {
                MessageBox.Show("Wpisz nazwę producenta.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var newProducer = new WpfProducer
            {
                Name = txtNewProducer.Text.Trim()
            };

            try
            {
                _dao.AddProducer(newProducer);

                LoadProducers();

                txtNewProducer.Text = string.Empty;

                MessageBox.Show("Producent dodany!", "Sukces");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Błąd podczas dodawania producenta: {ex.Message}", "Błąd");
            }
        }
    }

    public class WpfProducer : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}