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
        private InventoryModel _inventoryModel;
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand AddCommand { get; }
        //private ObservableCollection<Item> _items;
       
        public ObservableCollection<Item> Items { get; set; }
        
        private async Task Load()
        {
            List<Item> _item = await _inventoryModel.GetAllItems();
            await App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                Items.Clear();
                foreach (var item in _item)
                {
                    Items.Add(item);
                }
            });
        }
        public InventoryViewModel(NavigationService navigation,Character character,Campaign campaign)
        {
            _inventoryModel = new InventoryModel(character);
            _navigationService = navigation;
            Items = new ObservableCollection<Item>();
            Task.Run(Load);
            //NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService)); }, CanExecuteMyCommand);
        }
        private bool CanExecuteMyCommand(object parameter)
        { 
            return true;
        }
      
    }
}
