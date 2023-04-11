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
        private ItemModel _itemModel;
        private readonly NavigationState _navigationState;
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
        public ItemCreatorViewModel(NavigationState state,string _previousstate)
        {
            _itemModel = new ItemModel();
            _selectedOption= _itemModel.ItemType[0];
            //SelectedOption = _itemModel.ItemType[0];
            // _itemModel.ItemType = new ObservableCollection<String> { "Przedmiot","Broń","Pancerz"};   
            _navigationState = state;
            _prev = _previousstate;

            _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            NavigateBackCommand = new RelayCommand(ExecuteBack, CanExecuteMyCommand);
            CancelCommand = new RelayCommand(ExecuteBack, CanExecuteMyCommand);
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
        }
        private void OnCurrentViewModelChange()
        {
            OnPropertyChanged(nameof(_navigationState.CurrentViewModel));
        }
        private void ExecuteSave(object parameter)
        {
            //tutaj dodaj zapisywanie do bazy danych przedmiotu
            Trace.WriteLine("pomyslnie dodano przedmiot");
            _navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
        }
        private void ExecuteBack(object parameter)
        {
            switch(_prev)
            {
                case ("Character"):
                    _navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
                    break;
                default:
                    _navigationState.CurrentViewModel = new MenuViewModel(_navigationState);
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
