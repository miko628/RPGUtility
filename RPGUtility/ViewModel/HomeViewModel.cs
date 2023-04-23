using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.ViewModel
{
    internal class HomeViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        //private readonly NavigationState _navigationState;
        // public ViewModelBase CurrentViewModel => _navigationState.CurrentViewModel;

        public RelayCommand NavigateMenuCommand { get; }
        public RelayCommand NavigateSettingsCommand { get; }

        public RelayCommand NavigateHowCommand { get; }
        public RelayCommand ExitCommand { get; }
    
        public HomeViewModel(NavigationService state)
        {
            // CurrentViewModel =  new MenuViewModel();
            // _navigationState = state;
             _navigationService = state;
            //CurrentViewModel= _navigationService.getstate();
            // _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;

            NavigateMenuCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(()=>new MenuViewModel(_navigationService)); }, CanExecuteMyCommand);
            //NavigateMenuCommand = new RelayCommand(ExecuteMenu, CanExecuteMyCommand);
            NavigateSettingsCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new SettingsViewModel(_navigationService)); }, CanExecuteMyCommand);
            NavigateHowCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new HowViewModel(_navigationService)); }, CanExecuteMyCommand); 
            ExitCommand = new RelayCommand((object parameter) => { System.Windows.Application.Current.Shutdown(); }, CanExecuteMyCommand);
        }
        private void ExecuteMenu(object parameter) 
        { _navigationService.Navigate(()=>new MenuViewModel(_navigationService)); }
        private void ExecuteExit(object parameter)
        {

            System.Windows.Application.Current.Shutdown();// konczenie dzialania programu
                                                          // Tutaj wpisz kod, który ma być wykonany po kliknięciu przycisku
                                                          // Tutaj wpisz kod, który ma być wykonany po kliknięciu przycisku
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
