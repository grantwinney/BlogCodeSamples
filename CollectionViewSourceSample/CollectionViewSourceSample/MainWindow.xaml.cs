using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CollectionViewSourceSample
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(PiratesListView.ItemsSource).Filter = UserFilter;
        }

        private void PiratesFilter_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(PiratesListView.ItemsSource).Refresh();
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(PiratesFilter.Text))
                return true;

            var pirate = (Pirate)item;

            return (pirate.FirstName.StartsWith(PiratesFilter.Text, StringComparison.OrdinalIgnoreCase)
                    || pirate.LastName.StartsWith(PiratesFilter.Text, StringComparison.OrdinalIgnoreCase));
        }
    }

    public class Pirate
    {
        public Pirate(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}