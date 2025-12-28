using System;
using System.Linq;
using System.Windows;
using _156023_155875.ProgWiz.CORE;
using _156023_155875.ProgWiz.DAOMock; // W przyszłości Reflection, na razie bezpośrednio do testów
using _156023_155875.ProgWiz.INTERFACES;

namespace _156023_155875.ProgWiz.WPF
{
    public partial class AddWindow : Window
    {
        private IDataAccessObject _dao;

        public AddWindow(IDataAccessObject dao)
        {
            InitializeComponent();
            _dao = dao;
            RefreshProducers();

            cbClosure.SelectedIndex = 0;
        }

        private void RefreshProducers()
        {
            cbProducers.ItemsSource = _dao.GetAllProducers();
            if (cbProducers.Items.Count > 0) cbProducers.SelectedIndex = 0;
        }

        private void BtnAddProducer_Click(object sender, RoutedEventArgs e)
        {
            string newProdName = txtNewProducer.Text;
            if (string.IsNullOrWhiteSpace(newProdName) || newProdName.Length < 3)
            {
                MessageBox.Show("Nazwa producenta musi mieć min. 3 znaki.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newProducer = new Producer { Name = newProdName };
            _dao.AddProducer(newProducer);

            txtNewProducer.Text = "";
            RefreshProducers();
            cbProducers.SelectedItem = _dao.GetAllProducers().LastOrDefault();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cbProducers.SelectedItem == null)
            {
                MessageBox.Show("Wybierz producenta.", "Błąd");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text.Length < 2)
            {
                MessageBox.Show("Nazwa modelu jest za krótka.", "Błąd");
                return;
            }

            if (!double.TryParse(txtSize.Text, out double size) || size < 30 || size > 50)
            {
                MessageBox.Show("Podaj poprawny rozmiar (30-50).", "Błąd");
                return;
            }

            if (!int.TryParse(txtYear.Text, out int year))
            {
                MessageBox.Show("Podaj poprawny rok.", "Błąd");
                return;
            }

            var newShoe = new ClimbingShoe
            {
                ProducerId = (cbProducers.SelectedItem as IProducer).Id,
                Name = txtName.Text,
                Size = size,
                ProductionYear = year,
                Closure = (ClosureType)cbClosure.SelectedItem
            };

            // 3. Zapis
            _dao.AddShoe(newShoe);

            this.DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}