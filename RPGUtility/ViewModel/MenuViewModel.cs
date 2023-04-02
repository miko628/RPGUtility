using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RPGUtility.ViewModel
{
    class MenuViewModel : ViewModelBase
    {
        private readonly NavigationState _navigationState;
        public ViewModelBase CurrentViewModel => _navigationState.CurrentViewModel;
        public RelayCommand NavigateBackCommand { get; }
        public MenuViewModel(NavigationState state)
        {
            _navigationState = state;
            _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            NavigateBackCommand = new RelayCommand(ExecuteBack, CanExecuteMyCommand);
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
