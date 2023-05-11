using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RPGUtility.ViewModel
{
    internal class SettingsViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand HandleCheck { get; }
        public RelayCommand HandleUnchecked { get; }

        private WindowState _currentWindowState;
        public WindowState CurrentWindowState
        {
            get { return _currentWindowState; }
            set
            {
                _currentWindowState = value;
                OnPropertyChanged(nameof(CurrentWindowState));
            }
        }
        public SettingsViewModel(NavigationService navigation)
        {
            _navigationService = navigation;
            NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new HomeViewModel(_navigationService)); }, CanExecuteMyCommand);
            HandleCheck = new RelayCommand((object parameter) => { CurrentWindowState = WindowState.Maximized;  }, CanExecuteMyCommand);
            HandleUnchecked = new RelayCommand((object parameter) => { CurrentWindowState = WindowState.Normal; }, CanExecuteMyCommand);

            //NavigateCharacterCommand = new RelayCommand(ExecuteCharacter, CanExecuteMyCommand);
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
