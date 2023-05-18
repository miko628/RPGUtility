using RPGUtility.Model;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.ViewModel
{
    class ExchangeViewModel:ViewModelBase
    {
        private dynamic _selectedItem;

        private readonly NavigationService _navigationService;

        private ExchangeModel _exchangeModel;
        public RelayCommand CancelCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand NavigateBackCommand { get; }

        private ObservableCollection<Character> _characters;
        private Character _selectedcharacter;
        private bool _isComboBoxVisible;


        public RelayCommand ChooseCharacterCommand { get; }

        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set { _characters = value;
                OnPropertyChanged(nameof(Characters));
            }
        }

        public bool IsComboBoxVisible
        {
            get { return _isComboBoxVisible; }
            set { _isComboBoxVisible = value;
                OnPropertyChanged(nameof(IsComboBoxVisible)); }
        }


        public Character SelectedCharacter
        {
            get { return _selectedcharacter; }
            set
            {
                _selectedcharacter = value;
                OnPropertyChanged(nameof(SelectedCharacter));
                IsComboBoxVisible = false;
                LoadInventory2(SelectedCharacter);
            }
        }
        public ObservableCollection<dynamic> Items { get; set; }
        public ObservableCollection<dynamic> Items2 { get; set; }

        public dynamic SelectedItem { get { return _selectedItem; } set { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); } }

        public ExchangeViewModel(NavigationService navigation,Campaign campaign,Character character)
        {
            _exchangeModel = new ExchangeModel(campaign,character);
            _navigationService = navigation;
            IsComboBoxVisible = false;
            //IsComboBoxVisible2 = false;
            _characters = new ObservableCollection<Character>();
            SelectedCharacter= character;
            LoadInventory(character);
            Items = new ObservableCollection<dynamic>();
            Items2 = new ObservableCollection<dynamic>();
            Load();
            ChooseCharacterCommand = new RelayCommand( (object parameter) => { SelectedCharacter = null; IsComboBoxVisible = true;  }, CanExecuteMyCommand);
            //ChooseFirstCharacterCommand = new RelayCommand((object parameter) => { IsComboBoxVisible1 = true; }, CanExecuteMyCommand);
            NavigateBackCommand =new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService,character,campaign)); }, CanExecuteMyCommand);
            CancelCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService,character,campaign)); }, CanExecuteMyCommand);
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
        }
        //IsComboBoxVisible
        private async Task Load()
        {

            List<Character> camp = await _exchangeModel.GetAll();
            await App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                Characters.Clear();
                foreach (var item in camp)
                {
                    Characters.Add(item);
                }
            });
        }

        private async Task LoadInventory(Character character)
        {

            List<Item> _item = await _exchangeModel.GetAllItems(character);
            List<Weapon> _weapon = await _exchangeModel.GetAllWeapons(character);
            List<Armor> _armor = await _exchangeModel.GetAllArmors(character);
            await App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                Items.Clear();
                foreach (var item in _item)
                {
                    Items.Add(item);
                }
                foreach (var item in _weapon)
                {
                    Items.Add(item);
                }
                foreach (var item in _armor)
                {
                    Items.Add(item);
                }
            });
        }

        private async Task LoadInventory2(Character character)
        {

            List<Item> _item = await _exchangeModel.GetAllItems(character);
            List<Weapon> _weapon = await _exchangeModel.GetAllWeapons(character);
            List<Armor> _armor = await _exchangeModel.GetAllArmors(character);
            await App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                Items2.Clear();
                foreach (var item in _item)
                {
                    Items2.Add(item);
                }
                foreach (var item in _weapon)
                {
                    Items2.Add(item);
                }
                foreach (var item in _armor)
                {
                    Items2.Add(item);
                }
            });
        }
        private void ExecuteSave(object parameter)
        {
            //tutaj dodaj zapisywanie do bazy danych przedmiotu
            Trace.WriteLine("pomyslnie dokonano wymiany");
            _navigationService.Navigate(() => new HomeViewModel(_navigationService));
           // _navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }

    }

}
