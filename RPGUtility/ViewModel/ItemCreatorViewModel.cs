using Microsoft.Win32;
using RPGUtility.Model;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RPGUtility.ViewModel
{
    internal class ItemCreatorViewModel : ViewModelBase
    {
        private ItemCreationModel _itemModel;
        private readonly NavigationService _navigationService;
        private ObservableCollection<string> _type;
        private Campaign _campaign;
        private Character _character;
        private dynamic _item;
        private string _selectedOption;
        private string _selectedWeapon;
        private string _selectedArmor;
        private ObservableCollection<string> _weaponType;
        private ObservableCollection<string> _armorType;
        private BitmapImage _itemImage;
        public string SelectedWeapon
        {
            get 
            {
                return _selectedWeapon;
            }
            set
            { 
                _selectedWeapon = value;
                 OnPropertyChanged(nameof(SelectedWeapon));
            }
        }
        public string SelectedArmor 
        {
            get
            {
                return _selectedArmor;
            }
            set
            {
                _selectedArmor = value;
                OnPropertyChanged(nameof(SelectedArmor));
            }
        }
        public ObservableCollection<string> WeaponType { get { return _weaponType; } set { _weaponType = value; OnPropertyChanged(nameof(WeaponType)); } }

        public ObservableCollection<string> ArmorType { get { return _armorType; } set { _armorType = value; OnPropertyChanged(nameof(ArmorType)); } }

        public double AttackValue { get; set; }

        public double ArmorValue { get; set; }
        public string SelectedOption
        {
            get {
                //Trace.WriteLine("wybieram : " + _selectedOption);
                return _selectedOption;
            }
            set
            {
                _selectedOption = value;
                OnPropertyChanged(nameof(SelectedOption));
            }
        }
        //public ViewModelBase CurrentViewModel => _navigationState.CurrentViewModel;
        public ObservableCollection<string> ItemType { get { return _type; } set { _type = value; OnPropertyChanged(nameof(ItemType)); } }
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand CancelCommand { get; }
        public RelayCommand SaveCommand { get; }

        public RelayCommand SendImageCommand { get; }

        public BitmapImage ItemImage{ get { return _itemImage; } set { _itemImage = value; OnPropertyChanged(nameof(ItemImage)); } }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public int ItemQuantity { get; set; }
        public ItemCreatorViewModel(NavigationService navigation,Campaign campaign,Character character,dynamic? item)
        {
            _type = new ObservableCollection<string> { "Przedmiot", "Broń", "Pancerz" };
            _weaponType = new ObservableCollection<string> { "Miecz", "Łuk" };
            _armorType = new ObservableCollection<string> { "Głowa", "Korpus", "Ręce", "Nogi", "Całe ciało" };
            _selectedOption = _type[0];
            _selectedWeapon = _weaponType[0];
            _selectedArmor = _armorType[0];
            ItemQuantity = 1;
            if (item is not null)
            {
                _item = item;
                //ItemImage = item.Image;
                if(item is Item)
                {
                    ItemImage = ImageEncoder.bytearraytoBitmap(item.ItemImage);
                    SelectedOption = _type[0];
                    ItemName = item.Name;
                    ItemDescription= item.Description;
                    ItemQuantity=item.Quantity;
                }   else if(item is Weapon)
                {
                    ItemImage = ImageEncoder.bytearraytoBitmap(item.WeaponImage);
                    SelectedOption = _type[1];
                    ItemName = item.Name;
                    ItemDescription = item.Description;
                    ItemQuantity = item.Quantity;
                    SelectedWeapon = item.Type;
                    AttackValue= item.Damage;
                }
                else if(item is Armor)
                {
                    ItemImage = ImageEncoder.bytearraytoBitmap(item.ArmorImage);
                    SelectedOption = _type[2];
                    ItemName = item.Name;
                    ItemDescription = item.Description;
                    ItemQuantity = item.Quantity;
                    SelectedArmor = item.ArmorType;
                    AttackValue= item.ArmorValue;
                }

                ItemName = item.Name;
                ItemDescription = item.Description;

                SaveCommand = new RelayCommand(ExecuteUpdate, CanExecuteMyCommand);
            }
            else SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);

            _itemModel = new ItemCreationModel(character);
            //_itemModel.ItemType[0];
            _campaign = campaign;
            _character = character;
            //SelectedOption = _itemModel.ItemType[0];
            
            // _itemModel.ItemType = new ObservableCollection<String> { "Przedmiot","Broń","Pancerz"};   
            
            _navigationService = navigation;
            //_prev = _previousstate;
            SendImageCommand = new RelayCommand(ExecuteImage, CanExecuteMyCommand);
            //NavigateBackCommand = new RelayCommand(ExecuteBack, CanExecuteMyCommand);
            CancelCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService,character,campaign)); }, CanExecuteMyCommand);
        }
        private void ExecuteImage(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                string ImagePath = openFileDialog.FileName;
                ItemImage = new BitmapImage(new System.Uri(ImagePath));

                //Image = ImageEncoder.bytearraytoBitmap(ImageEncoder.BitmapImagetobytearray(pom));
                //Image = new BitmapImage(new System.Uri(ImagePath));
            }
        }
        private async void ExecuteSave(object parameter)
        {
            //tutaj dodaj zapisywanie do bazy danych przedmiotu
            switch(_selectedOption)
                {
                case "Przedmiot":
                    await _itemModel.AddItem(ItemImage, ItemName, ItemQuantity, ItemDescription);
                    _navigationService.Navigate(() => new InventoryViewModel(_navigationService, _character, _campaign));
                    break;
                case "Broń":
                    await _itemModel.AddWeapon(ItemImage, ItemName, SelectedWeapon ,ItemQuantity, ItemDescription,AttackValue);
                    _navigationService.Navigate(() => new InventoryViewModel(_navigationService, _character, _campaign));
                    break;
                case "Pancerz":
                    await _itemModel.AddArmor(ItemImage, ItemName, ItemQuantity, ItemDescription, SelectedArmor, ArmorValue);
                    _navigationService.Navigate(() => new InventoryViewModel(_navigationService, _character, _campaign));
                    break;

            }
            Trace.WriteLine(_selectedOption);
            //_navigationService.Navigate(() => new InventoryViewModel(_navigationService, _character, _campaign)); 
            //_navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
        }
        private async void ExecuteUpdate(object parameter)
        {
            if (_item is Item)
            {
                await _itemModel.UpdateItem(_item, ItemImage, ItemName, ItemDescription, ItemQuantity);
                _navigationService.Navigate(() => new CharacterViewModel(_navigationService, _character, _campaign));
            } else if (_item is Weapon)
            {
                await _itemModel.UpdateWeapon(_item, ItemImage, ItemName, ItemDescription, ItemQuantity, AttackValue, SelectedWeapon);
            }
            else if (_item is Armor)
            {
                await _itemModel.UpdateArmor(_item, ItemImage, ItemName, ItemDescription, ItemQuantity, SelectedArmor, ArmorValue);
            }
            else Trace.WriteLine("błond");
            _navigationService.Navigate(() => new InventoryViewModel(_navigationService, _character, _campaign));
        }
        private void ExecuteBack(object parameter)
        {

        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
