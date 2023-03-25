using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RPGUtility.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private readonly NavigationState _navigationState;
        public ViewModelBase CurrentViewModel => _navigationState.CurrentViewModel;

        public ICommand NavigateMenuCommand {  get; }
        public MainViewModel(NavigationState state)
        {
           // CurrentViewModel =  new MenuViewModel();
            _navigationState = state;
            _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            NavigateMenuCommand = new NavigateHome(state);
        }
        private void OnCurrentViewModelChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
