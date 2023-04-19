using RPGUtility.Model;
using RPGUtility.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility
{
    public class NavigationService
    {
        private readonly NavigationState _navigationState;
        //private readonly Func<ViewModelBase> _viewModel;
        //public ViewModelBase CurrentViewModel => _navigationState.CurrentViewModel;
        public NavigationService(NavigationState state)
        {
            _navigationState = state;
            //_viewModel = viewModel;
            //_navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            //_navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
        }
        
      public NavigationState getstate()
        {
            return _navigationState;
        }
        public void Navigate(Func<ViewModelBase> viewbase)
        {
           // _viewModel = viewModel;
            _navigationState.CurrentViewModel = viewbase();
        }

    }
}
