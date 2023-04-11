using RPGUtility.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.ViewModel
{
    class ExchangeViewModel:ViewModelBase
    {
        private readonly NavigationState _navigationState;
        private ExchangeModel _exchangeModel;
        public ViewModelBase CurrentViewModel => _navigationState.CurrentViewModel;
        public RelayCommand CancelCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand NavigateBackCommand { get; }

        public RelayCommand ChooseSecondCharacterCommand { get; }
        public RelayCommand ChooseFirstCharacterCommand { get; }
        public ExchangeViewModel(NavigationState state)
        {
            _exchangeModel = new ExchangeModel();
            _navigationState = state;
            _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            NavigateBackCommand =new RelayCommand(ExecuteBack, CanExecuteMyCommand);
            CancelCommand = new RelayCommand(ExecuteBack, CanExecuteMyCommand);
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
        }
        private void ExecuteSave(object parameter)
        {
            //tutaj dodaj zapisywanie do bazy danych przedmiotu
            Trace.WriteLine("pomyslnie dokonano wymiany");
            _navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
        }
        private void OnCurrentViewModelChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private void ExecuteBack(object parameter)
        {
            
            _navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }

    }

}
