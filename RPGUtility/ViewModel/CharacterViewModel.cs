using RPGUtility.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RPGUtility.ViewModel
{
    internal class CharacterViewModel:ViewModelBase
    {
        private readonly NavigationState _navigationState;
        private CharacterModel _characterModel;
        public ViewModelBase CurrentViewModel => _navigationState.CurrentViewModel;
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand NavigationItemCreationCommand { get; }
      //  public RelayCommand CancelCommand { get; }
       // public RelayCommand SaveCommand { get; }
        public RelayCommand NavigationExchangeCommand { get; }
        public CharacterViewModel(NavigationState state)
        {
            _characterModel = new CharacterModel();
            _navigationState = state;
            _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            NavigateBackCommand = new RelayCommand(ExecuteBack, CanExecuteMyCommand);
            NavigationItemCreationCommand = new RelayCommand(ExecuteItemCreation, CanExecuteMyCommand);
            NavigationExchangeCommand = new RelayCommand(ExecuteExchange, CanExecuteMyCommand);
           // CancelCommand = new RelayCommand(ExecuteCancel, CanExecuteMyCommand);
           // SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
        }
        public BitmapImage Image
        {
            get
            {
                if (_characterModel.Image != null)
                    return _characterModel.Image;
                else return new BitmapImage();
            }
            set
            {
                _characterModel.Image = value;
                OnPropertyChanged("Image");
            }
        }
        private void OnCurrentViewModelChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private void ExecuteBack(object parameter)
        {
            //NavigationState pom = _navigationState;

            _navigationState.CurrentViewModel = new MenuViewModel(_navigationState);
        }
        private void ExecuteExchange(object parameter)
        {
            //NavigationState pom = _navigationState;

            _navigationState.CurrentViewModel = new ExchangeViewModel(_navigationState);
        }
        private void ExecuteItemCreation(object parameter)
        {
            NavigationState pom = _navigationState;

            _navigationState.CurrentViewModel = new ItemCreatorViewModel(pom,"Character");
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
