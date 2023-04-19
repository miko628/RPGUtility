using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RPGUtility.ViewModel
{
    class MainViewModel : ViewModelBase
    {
      //  private readonly NavigationService _navigationService;
        private readonly NavigationState _navigationState;
        public ViewModelBase CurrentViewModel => _navigationState.CurrentViewModel;

        public MainViewModel(NavigationState state)
        {
            // CurrentViewModel =  new MenuViewModel();
             _navigationState = state;
           // _navigationService = state;
            //CurrentViewModel= _navigationService.getstate();
            _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;

           
        }
        private void OnCurrentViewModelChange()
        {
             OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}
