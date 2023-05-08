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
        private InventoryModel _inventoryModel;
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand AddCommand { get; }
        //private ObservableCollection<Item> _items;
       
        public ObservableCollection<Item> Items { get; set; }

        private void LoadData()
        {
            /*List<Item> dbItems = _inventoryModel.getItems();
            foreach (var item in dbItems)
            {
                // Id = itemData.Id,
                var it = new Item(item.name, item.quantity, item.description);
               *//* {
                    name = item.name,
                    quantity = item.quantity,
                    description = item.description
                };*//*
                Items.Add(item);
                Trace.WriteLine(item.name);
                Trace.WriteLine(item.quantity);
                Trace.WriteLine(item.description);
            }*/
               
            
        }
        
        public InventoryViewModel(NavigationService navigation)
        {
            _inventoryModel = new InventoryModel();
            _navigationService = navigation;
            Items = new ObservableCollection<Item>();
            LoadData();
            //NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService)); }, CanExecuteMyCommand);
        }
        private bool CanExecuteMyCommand(object parameter)
        { 
            return true;
        }
      
    }
}
