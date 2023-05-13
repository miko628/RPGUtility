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
using System.Xml.Linq;

namespace RPGUtility.ViewModel
{
    class InventoryViewModel: ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly Character _character;
        private readonly Campaign _campaign;
        private dynamic _selectedItem;
        private InventoryModel _inventoryModel;
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand AddCommand { get; }
        //private ObservableCollection<Item> _items;
        // public RelayCommand DeleteItemCommand { get; }

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
            Items = new ObservableCollection<dynamic>();
            Task.Run(Load);
            NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService,character,campaign)); }, CanExecuteMyCommand);
            AddCommand= new RelayCommand((object parameter) => { _navigationService.Navigate(() => new ItemCreatorViewModel(_navigationService,campaign,character)); }, CanExecuteMyCommand);
            //DeleteArmorCommand= new RelayCommand((object parameter) => { Trace.WriteLine("usuwam a"); }, CanExecuteMyCommand);
            //DeleteItemCommand= new RelayCommand((object parameter) => { Trace.WriteLine("usuwam i"); }, CanExecuteMyCommand);
            DeleteCommand = new RelayCommand((object parameter) => { string a = "usuwam w" + _selectedItem.Name; Trace.WriteLine(a); }, CanExecuteMyCommand);
        }
        private bool CanExecuteMyCommand(object parameter)
        { 
            return true;
        }
      
    }
}
