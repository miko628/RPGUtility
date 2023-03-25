using RPGUtility.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility
{
    class NavigateHome : CommandBase // zmienic to na relay cos tam ok ok ?
    {
        private readonly NavigationState _navigationState;
        public NavigateHome(NavigationState state)
        {
            _navigationState = state;
        }
        public override void Execute(object? parameter)
        {
            _navigationState.CurrentViewModel = new MenuViewModel();
        }
    }
}
