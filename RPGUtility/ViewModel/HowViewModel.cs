using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.ViewModel
{
    class HowViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand NextCommand { get; }
        public RelayCommand PreviousCommand { get; }
            public HowViewModel(NavigationService navigation)
        {
            _navigationService = navigation;
            NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new HomeViewModel(_navigationService)); }, CanExecuteMyCommand);
            //NavigateCharacterCommand = new RelayCommand(ExecuteCharacter, CanExecuteMyCommand);
        }


        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
