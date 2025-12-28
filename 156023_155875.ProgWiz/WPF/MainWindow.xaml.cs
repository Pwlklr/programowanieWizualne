using System;
using System.Configuration; // Potrzebne do odczytu App.config
using System.IO;
using System.Reflection;
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

            string dllName = ConfigurationManager.AppSettings["DaoLibrary"];
            string className = ConfigurationManager.AppSettings["DaoClass"];

            string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dllName);

            if (!File.Exists(dllPath))
            {
                MessageBox.Show($"Nie znaleziono pliku: {dllPath}\nUpewnij się, że projekt DAO jest zbudowany i plik dll skopiowany.");
                return;
            }

            try
            {
                var assembly = Assembly.LoadFrom(dllPath);

                var type = assembly.GetType(className);

                if (type == null)
                    throw new Exception("Nie znaleziono klasy DAO w bibliotece.");

                _dao = (IDataAccessObject)Activator.CreateInstance(type);

                _viewModel = new MainViewModel(_dao);
                this.DataContext = _viewModel;
            }
            catch (Exception ex)
            {
                var realError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var details = ex.InnerException != null ? ex.InnerException.ToString() : ex.ToString();

                MessageBox.Show($"Błąd ładowania DAO:\n{realError}\n\nSzczegóły:\n{details}");
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var addWin = new AddWindow(_dao);
            if (addWin.ShowDialog() == true)
            {
                _viewModel.RefreshData();
            }
        }
    }
}