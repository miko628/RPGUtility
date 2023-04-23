using RPGUtility.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.ViewModel
{
    internal class ItemCreatorViewModel:ViewModelBase
    {
        private ItemCreationModel _itemModel;
        private readonly NavigationService _navigationService;
       string _prev;
        private string _selectedOption;
        public string SelectedOption
        {
            get => _selectedOption;
            set
            {
                _selectedOption = value;
                OnPropertyChanged(nameof(SelectedOption));
            }
        }
        //public ViewModelBase CurrentViewModel => _navigationState.CurrentViewModel;
        public ObservableCollection<String> ItemType { get { return _itemModel.ItemType; } set { _itemModel.ItemType = new ObservableCollection<String> { "Przedmiot", "Broń", "Pancerz" }; } }
        public RelayCommand NavigateBackCommand { get; }

        public RelayCommand CancelCommand { get; }
        public RelayCommand SaveCommand { get; }
        public ItemCreatorViewModel(NavigationService navigation,string _previousstate)
        {
            _itemModel = new ItemCreationModel();
            _selectedOption= _itemModel.ItemType[0];
            //SelectedOption = _itemModel.ItemType[0];
            // _itemModel.ItemType = new ObservableCollection<String> { "Przedmiot","Broń","Pancerz"};   
            _navigationService = navigation;
            _prev = _previousstate;

            NavigateBackCommand = new RelayCommand(ExecuteBack, CanExecuteMyCommand);
            CancelCommand = new RelayCommand(ExecuteBack, CanExecuteMyCommand);
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
        }
        private void ExecuteSave(object parameter)
        {
            //tutaj dodaj zapisywanie do bazy danych przedmiotu
            Trace.WriteLine("pomyslnie dodano przedmiot");
            _navigationService.Navigate(() => new CharacterViewModel(_navigationService)); 
            //_navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
        }
        private void ExecuteBack(object parameter)
        {
            switch(_prev)
            {
                case ("Character"):
                    _navigationService.Navigate(() => new CharacterViewModel(_navigationService)); 
                 //   _navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
                    break;
                default:
                    _navigationService.Navigate(() => new MenuViewModel(_navigationService));

                    //  _navigationState.CurrentViewModel = new MenuViewModel(_navigationState);
                    break;
            }
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
