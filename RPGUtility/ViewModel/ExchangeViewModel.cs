using RPGUtility.Model;
using RPGUtility.Models;
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
        private readonly NavigationService _navigationService;

        private ExchangeModel _exchangeModel;
        public RelayCommand CancelCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand NavigateBackCommand { get; }

        public RelayCommand ChooseSecondCharacterCommand { get; }
        public RelayCommand ChooseFirstCharacterCommand { get; }
        public ExchangeViewModel(NavigationService navigation,Campaign campaign,Character character)
        {
            _exchangeModel = new ExchangeModel();
            _navigationService = navigation;
            //NavigateBackCommand =new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService,character,campa)); }, CanExecuteMyCommand);
            CancelCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService,character,campaign)); }, CanExecuteMyCommand);
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
        }
        private void ExecuteSave(object parameter)
        {
            //tutaj dodaj zapisywanie do bazy danych przedmiotu
            Trace.WriteLine("pomyslnie dokonano wymiany");
            _navigationService.Navigate(() => new HomeViewModel(_navigationService));
           // _navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }

    }

}
