using RPGUtility.Model;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

namespace RPGUtility.ViewModel
{
    class InventoryViewModel: ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly Character _character;
        //private readonly Campaign _campaign;
        private dynamic _selectedItem;
        private InventoryModel _inventoryModel;

        public string CharacterName { get; set; }
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand AddCommand { get; }
        //private ObservableCollection<Item> _items;
        // public RelayCommand DeleteItemCommand { get; }
        public RelayCommand EditCommand { get; }
        public dynamic SelectedItem { get { return _selectedItem; } set { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); } }
       public RelayCommand DeleteCommand { get; }

     //  public RelayCommand DeleteArmorCommand { get; }

        public ObservableCollection<dynamic> Items { get; set; }
        
        private async Task Load()
        {
            List<Item> _item = await _inventoryModel.GetAllItems();
            List<Weapon> _weapon = await _inventoryModel.GetAllWeapons();
            List<Armor> _armor = await _inventoryModel.GetAllArmors();
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
        public InventoryViewModel(NavigationService navigation,Character character,Campaign campaign)
        {
            _inventoryModel = new InventoryModel(character);
            _navigationService = navigation;
            CharacterName = character.Name;
            Items = new ObservableCollection<dynamic>();
            Task.Run(Load);
            NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService,character,campaign)); }, CanExecuteMyCommand);
            AddCommand= new RelayCommand((object parameter) => { _navigationService.Navigate(() => new ItemCreatorViewModel(_navigationService,campaign,character,null)); }, CanExecuteMyCommand);
            EditCommand= new RelayCommand((object parameter) => { _navigationService.Navigate(() => new ItemCreatorViewModel(_navigationService, campaign, character, SelectedItem)); }, CanExecuteMyCommand);
            //DeleteArmorCommand= new RelayCommand((object parameter) => { Trace.WriteLine("usuwam a"); }, CanExecuteMyCommand);
            //EditingCommands =;
            //DeleteItemCommand= new RelayCommand((object parameter) => { Trace.WriteLine("usuwam i"); }, CanExecuteMyCommand);
            DeleteCommand = new RelayCommand(async(object parameter) => {
                if (_selectedItem is Item)
                {
                    await _inventoryModel.DeleteItem(_selectedItem);
                    await Task.Run(Load);
                }
                else if (_selectedItem is Weapon)
                {
                    await _inventoryModel.DeleteWeapon(_selectedItem);
                    await Task.Run(Load);
                }
                else if (_selectedItem is Armor)
                {
                    await _inventoryModel.DeleteArmor(_selectedItem);
                    await Task.Run(Load);
                }
                else Trace.WriteLine("blond");
            }, CanExecuteMyCommand);
        }
        private bool CanExecuteMyCommand(object parameter)
        { 
            return true;
        }
      
    }
}
