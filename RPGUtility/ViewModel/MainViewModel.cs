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

        public RelayCommand NavigateMenuCommand {  get; }
        public RelayCommand NavigateSettingsCommand { get; }

        public RelayCommand NavigateHowCommand { get; }
        public RelayCommand ExitCommand { get; }
        public MainViewModel(NavigationState state)
        {
           // CurrentViewModel =  new MenuViewModel();
            _navigationState = state;
            _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            NavigateMenuCommand = new RelayCommand(ExecuteMenu, CanExecuteMyCommand);
            NavigateSettingsCommand = new RelayCommand(ExecuteSettings, CanExecuteMyCommand);
            NavigateHowCommand = new RelayCommand(ExecuteHow, CanExecuteMyCommand);
            ExitCommand = new RelayCommand(ExecuteExit, CanExecuteMyCommand);
        }
        private void ExecuteMenu(object parameter)
        {
            NavigationState pom = _navigationState;
            _navigationState.CurrentViewModel = new MenuViewModel(pom); //ustawianie view i viewmodelu jakie uzywamy w glownym oknie
                                                                        //viewmodel musi dziedziczyc z viewmodelbase
                                                                        // System.Windows.Application.Current.Shutdown(); konczenie dzialania programu
                                                                        // Tutaj wpisz kod, który ma być wykonany po kliknięciu przycisku
        }
        private void ExecuteSettings(object parameter)
        {
            NavigationState pom = _navigationState;
            _navigationState.CurrentViewModel = new SettingsViewModel(pom); //ustawianie view i viewmodelu jakie uzywamy w glownym oknie
                                                                        //viewmodel musi dziedziczyc z viewmodelbase
                                                                        // System.Windows.Application.Current.Shutdown(); konczenie dzialania programu
                                                                        // Tutaj wpisz kod, który ma być wykonany po kliknięciu przycisku
                                                                        // Tutaj wpisz kod, który ma być wykonany po kliknięciu przycisku
        }

        private void ExecuteHow(object parameter)
        {
            NavigationState pom = _navigationState;
            _navigationState.CurrentViewModel = new HowViewModel(pom);
            //_navigationState.CurrentViewModel = new CharacterCreatorViewModel();
            //ustawianie view i viewmodelu jakie uzywamy w glownym oknie
            //viewmodel musi dziedziczyc z viewmodelbase
            // System.Windows.Application.Current.Shutdown(); konczenie dzialania programu
            // Tutaj wpisz kod, który ma być wykonany po kliknięciu przycisku
            // Tutaj wpisz kod, który ma być wykonany po kliknięciu przycisku
        }
        private void ExecuteExit(object parameter)
        {
         
        System.Windows.Application.Current.Shutdown();// konczenie dzialania programu
                                                                         // Tutaj wpisz kod, który ma być wykonany po kliknięciu przycisku
                                                                         // Tutaj wpisz kod, który ma być wykonany po kliknięciu przycisku
        }
        private void OnCurrentViewModelChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
