using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.ViewModel
{
    internal class SettingsViewModel : ViewModelBase
    {
        private readonly NavigationState _navigationState;
        public ViewModelBase CurrentViewModel => _navigationState.CurrentViewModel;
        public RelayCommand NavigateBackCommand { get; }
        public SettingsViewModel(NavigationState state)
        {
            _navigationState = state;
            _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            NavigateBackCommand = new RelayCommand(ExecuteBack, CanExecuteMyCommand);
            //NavigateCharacterCommand = new RelayCommand(ExecuteCharacter, CanExecuteMyCommand);
        }
        private void OnCurrentViewModelChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private void ExecuteBack(object parameter)
        {
            NavigationState pom = _navigationState;
            _navigationState.CurrentViewModel = new MainViewModel(pom);
        }

        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
