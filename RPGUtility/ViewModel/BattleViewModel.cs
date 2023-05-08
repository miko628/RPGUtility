using RPGUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.ViewModel
{
    class BattleViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private BattleModel _battleModel;
        public RelayCommand NavigateBackCommand { get; }

        public BattleViewModel(NavigationService navigation)
        {
            _navigationService = navigation;
            _battleModel = new BattleModel();
            //NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new MenuViewModel(_navigationService)); }, CanExecuteMyCommand);

        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
