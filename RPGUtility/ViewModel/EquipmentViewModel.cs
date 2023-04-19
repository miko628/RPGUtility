using RPGUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.ViewModel
{
    class EquipmentViewModel: ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private EquipmentModel _equimpentModel;
        public RelayCommand NavigateBackCommand { get; }
        
        public EquipmentViewModel(NavigationService navigation)
        {
            _equimpentModel = new EquipmentModel();
            _navigationService = navigation;
            NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService)); }, CanExecuteMyCommand);
        }
        private bool CanExecuteMyCommand(object parameter)
        { 
            return true;
        }
    }
}
