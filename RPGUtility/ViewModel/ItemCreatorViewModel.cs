﻿using Microsoft.Win32;
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
            if (item is not null)
            {
                //ItemImage = item.Image;
                if(item is Item)
                {
                    
                }   else if(item is Weapon)
                {

                }
                else if(item is Armor)
                {

                }

                ItemName = item.Name;
                ItemDescription = item.Description;
            }
            _itemModel = new ItemCreationModel(character);
            //_itemModel.ItemType[0];
            _campaign = campaign;
            _character = character;
            //SelectedOption = _itemModel.ItemType[0];
            
            // _itemModel.ItemType = new ObservableCollection<String> { "Przedmiot","Broń","Pancerz"};   
            _selectedOption = _type[0];
            _selectedWeapon = _weaponType[0];
            _selectedArmor = _armorType[0];
            ItemQuantity = 1;
            _navigationService = navigation;
            //_prev = _previousstate;
            SendImageCommand = new RelayCommand(ExecuteImage, CanExecuteMyCommand);
            //NavigateBackCommand = new RelayCommand(ExecuteBack, CanExecuteMyCommand);
            CancelCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService,character,campaign)); }, CanExecuteMyCommand);
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
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
                    _navigationService.Navigate(() => new CharacterViewModel(_navigationService, _character, _campaign));
                    break;
                case "Broń":
                    await _itemModel.AddWeapon(ItemImage, ItemName, SelectedWeapon ,ItemQuantity, ItemDescription,AttackValue);
                    _navigationService.Navigate(() => new CharacterViewModel(_navigationService, _character, _campaign));
                    break;
                case "Pancerz":
                    await _itemModel.AddArmor(ItemImage, ItemName, ItemQuantity, ItemDescription, SelectedArmor, ArmorValue);
                    _navigationService.Navigate(() => new CharacterViewModel(_navigationService, _character, _campaign));
                    break;

            }
            Trace.WriteLine(_selectedOption);
            //_navigationService.Navigate(() => new InventoryViewModel(_navigationService, _character, _campaign)); 
            //_navigationState.CurrentViewModel = new CharacterViewModel(_navigationState);
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
