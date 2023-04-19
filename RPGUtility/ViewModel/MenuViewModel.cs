﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RPGUtility.ViewModel
{
    class MenuViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand NavigateCharacterCommand { get; }
        public RelayCommand NavigateBattleCommand { get; }
        public RelayCommand NavigateTestCommand { get; }
        public RelayCommand NavigateSpellsCommand { get; }
        public MenuViewModel(NavigationService navigation)
        {
            _navigationService = navigation;
            //_navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new HomeViewModel(_navigationService)); }, CanExecuteMyCommand);
            NavigateCharacterCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService)); }, CanExecuteMyCommand);
            NavigateTestCommand = new RelayCommand(ExecuteTest, CanExecuteMyCommand);
        }

        private void ExecuteBack(object parameter)
        {
           // NavigationState pom = _navigationState;
           // _navigationState.CurrentViewModel = new MainViewModel(_navigationState);
        }

        private void ExecuteCharacter(object parameter)
        {
           // NavigationState pom = _navigationState;
           // _navigationState.CurrentViewModel = new CharacterCreatorViewModel(_navigationState);
            //_navigationState.CurrentViewModel = new CharacterViewModel();
        }
        private void ExecuteTest(object parameter)
        {
            //_navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
            //_navigationState.CurrentViewModel = new CharacterViewModel();
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
