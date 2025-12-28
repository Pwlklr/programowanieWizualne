using _156023_155875.ProgWiz.BL;
using _156023_155875.ProgWiz.INTERFACES;
using _156023_155875.ProgWiz.WPF;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows;

namespace WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string? dllName = ConfigurationManager.AppSettings["DaoLibrary"];
            string? className = ConfigurationManager.AppSettings["DaoClass"];

            if (string.IsNullOrEmpty(dllName) || string.IsNullOrEmpty(className))
            {
                MessageBox.Show("Błąd konfiguracji: Brak kluczy DaoLibrary lub DaoClass w App.config.");
                Shutdown();
                return;
            }

            string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dllName);

            if (!File.Exists(dllPath))
            {
                MessageBox.Show($"Nie znaleziono pliku biblioteki: {dllPath}\nSprawdź czy pliki zostały skopiowane (Target CopyDAO).");
                Shutdown();
                return;
            }

            try
            {
                Assembly asm = Assembly.LoadFrom(dllPath);
                Type? daoType = asm.GetType(className);

                if (daoType == null)
                {
                    MessageBox.Show($"Nie znaleziono klasy {className} w bibliotece {dllName}.");
                    Shutdown();
                    return;
                }

                var daoInstance = Activator.CreateInstance(daoType);

                if (daoInstance is not IDataAccessObject dao)
                {
                    MessageBox.Show($"Klasa {className} nie implementuje interfejsu IDataAccessObject.");
                    Shutdown();
                    return;
                }

                MainViewModel vm = new MainViewModel(dao);

                MainWindow window = new MainWindow(dao);

                window.DataContext = vm;
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd krytyczny aplikacji: {ex.Message}");
                Shutdown();
            }
        }
    }
}