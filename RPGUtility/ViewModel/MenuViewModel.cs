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
        public RelayCommand NavigateCharacterCommand { get; }
        public RelayCommand NavigateBattleCommand { get; }
        public RelayCommand NavigateTestCommand { get; }
        public RelayCommand NavigateSpellsCommand { get; }
        public MenuViewModel(NavigationState state)
        {
            _navigationState = state;
            _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            NavigateBackCommand = new RelayCommand(ExecuteBack, CanExecuteMyCommand);
            NavigateCharacterCommand = new RelayCommand(ExecuteCharacter, CanExecuteMyCommand);
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

        private void ExecuteCharacter(object parameter)
        {
            NavigationState pom = _navigationState;
            _navigationState.CurrentViewModel = new CharacterCreatorViewModel(pom);
            //_navigationState.CurrentViewModel = new CharacterViewModel();
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
