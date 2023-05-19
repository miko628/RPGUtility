using RPGUtility.Model;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Printing;

namespace RPGUtility.ViewModel
{
    class ExchangeViewModel:ViewModelBase
    {
        private dynamic _selectedItem;

        private dynamic _selectedItem2;

        private Character _character;
        private Campaign _campaign;
        private dynamic _selectedTargetItem;

        private dynamic _selectedTargetItem2;
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

        public string CharacterName1 { get; set; }
        public string CharacterName2 { get; set; }

        public bool IsComboBoxVisible
        {
            get { return _isComboBoxVisible; }
            set { _isComboBoxVisible = value;
                OnPropertyChanged(nameof(IsComboBoxVisible)); }
        }


        public Character SelectedCharacter
        {
            get {  return _selectedcharacter;  }
            set
            {
                _selectedcharacter = value;
                OnPropertyChanged(nameof(SelectedCharacter));
                IsComboBoxVisible = false;
                if (SelectedCharacter is not null) { CharacterName2 = SelectedCharacter.Name; }
                OnPropertyChanged(nameof(CharacterName2));
                LoadInventory2(_selectedcharacter);
            }
        }
        public ObservableCollection<dynamic> Items { get; set; }

        public ObservableCollection<dynamic> ItemsTarget { get; set; }
        public ObservableCollection<dynamic> Items2 { get; set; }
        public ObservableCollection<dynamic> Items2Target { get; set; }

        public dynamic SelectedItem { get { return _selectedItem;  } set { _selectedItem = value; if (_selectedItem is not null) { Items.Remove(_selectedItem); ItemsTarget.Add(_selectedItem); } _selectedItem = null; OnPropertyChanged(nameof(SelectedItem)); /*OnPropertyChanged(nameof(Items)); OnPropertyChanged(nameof(ItemsTarget));*/ } }
        public dynamic SelectedItem2 { get { return _selectedItem2; } set { _selectedItem2 = value; if (_selectedItem2 is not null) { Items2.Remove(_selectedItem2); Items2Target.Add(_selectedItem2); } _selectedItem2 = null; OnPropertyChanged(nameof(SelectedItem2)); /*OnPropertyChanged(nameof(Items2)); OnPropertyChanged(nameof(Items2Target));*/ } }
        public dynamic SelectedTargetItem { get { return _selectedTargetItem; } set { _selectedTargetItem = value; if (_selectedTargetItem is not null) { ItemsTarget.Remove(_selectedTargetItem); Items.Add(_selectedTargetItem); } _selectedTargetItem = null; OnPropertyChanged(nameof(SelectedItem)); /*OnPropertyChanged(nameof(ItemsTarget)); OnPropertyChanged(nameof(Items));*/ } }
        public dynamic SelectedTargetItem2 { get { return _selectedTargetItem2; } set { _selectedTargetItem2 = value; if (_selectedTargetItem2 is not null) { Items2Target.Remove(_selectedTargetItem2); Items2.Add(_selectedTargetItem2); } _selectedTargetItem2 = null; OnPropertyChanged(nameof(SelectedItem2)); /*OnPropertyChanged(nameof(Items2Target)); OnPropertyChanged(nameof(Items2));*/ } }

        public ExchangeViewModel(NavigationService navigation,Campaign campaign,Character character)
        {
            _exchangeModel = new ExchangeModel(campaign,character);
            _navigationService = navigation;
            IsComboBoxVisible = false;

            //IsComboBoxVisible2 = false;
            _characters = new ObservableCollection<Character>();
            //SelectedCharacter= character;
            _character = character;
            _campaign = campaign;
            CharacterName1=_character.Name;
            Items = new ObservableCollection<dynamic>();
            Items2 = new ObservableCollection<dynamic>();
            ItemsTarget= new ObservableCollection<dynamic>();
            Items2Target= new ObservableCollection<dynamic>();
            Load();
            LoadInventory(_character);
            ChooseCharacterCommand = new RelayCommand( (object parameter) => { SelectedCharacter = null; SelectedTargetItem2 = null; SelectedItem2 = null; Items2Target.Clear(); IsComboBoxVisible = true;  }, CanExecuteMyCommand);
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
        private async void ExecuteSave(object parameter)
        {
            //tutaj dodaj zapisywanie do bazy danych przedmiotu
            foreach(var item in ItemsTarget)
            {
                // _selectedcharacter
                if (item is Item)
                {
                    await _exchangeModel.UpdateItem(_selectedcharacter, item);
                }
                else if (item is Weapon)
                {
                    await _exchangeModel.UpdateWeapon(_selectedcharacter, item);

                }
                else if (item is Armor)
                {
                    await _exchangeModel.UpdateArmor(_selectedcharacter, item);

                }
                else Trace.WriteLine("Błond");
            }
            foreach(var item in Items2Target)
            {
                //_character
                if (item is Item)
                {
                    await _exchangeModel.UpdateItem(_character, item);

                }
                else if (item is Weapon)
                {
                    await _exchangeModel.UpdateWeapon(_character, item);

                }
                else if (item is Armor)
                {
                   await _exchangeModel.UpdateArmor(_character, item);

                }
                else Trace.WriteLine("Błond");
            }
            SelectedTargetItem2 = null; SelectedItem2 = null;
            SelectedTargetItem = null; SelectedItem = null;
            ItemsTarget.Clear();
            Items2Target.Clear();
            await LoadInventory(_character);
            await LoadInventory2(_selectedcharacter);
            //_navigationService.Navigate(() => new CharacterViewModel(_navigationService,_character,_campaign));
            // _navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
       

    }

}
