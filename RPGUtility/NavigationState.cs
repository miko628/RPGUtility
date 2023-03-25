using RPGUtility.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility
{
    class NavigationState
    {
        public event Action CurrentViewModelChange;

        private ViewModelBase _CurrentViewModel;
        public ViewModelBase CurrentViewModel {
            get => _CurrentViewModel; 
            set { _CurrentViewModel = value;
                onCurrentViewModelChange();
            } }
        private void onCurrentViewModelChange()
        {
            CurrentViewModelChange?.Invoke();
        }
    }
}
