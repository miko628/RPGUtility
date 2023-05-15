using RPGUtility.Model;
using RPGUtility.Models;
using RPGUtility.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RPGUtility.ViewModel
{
    internal class CharacterViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private CharacterModel _characterModel;
        public string CharacterName { get; set; }
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand NavigationItemCreationCommand { get; }
      //  public RelayCommand CancelCommand { get; }
       // public RelayCommand SaveCommand { get; }
        public RelayCommand NavigationExchangeCommand { get; }
        public RelayCommand NavigationEquipmentCommand { get; }
        public RelayCommand NavigationTradeCommand { get; }
        public RelayCommand NavigationAdvancementCommand { get; }
        public RelayCommand NavigationSkillTestCommand { get; }
        public RelayCommand NavigationSpellCommand { get; }
        public RelayCommand NavigationOpposedTestCommand { get; }
        public RelayCommand NavigationRollDiceCommand { get; }
        public CharacterViewModel(NavigationService navigation,Character character,Campaign campaign)
        {
            _characterModel = new CharacterModel();
            _navigationService = navigation;
            CharacterName = character.Name;
            Image = ImageEncoder.bytearraytoBitmap(character.CharacterImage);
           // _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new StoryViewModel(_navigationService, campaign)); }, CanExecuteMyCommand);
            NavigationItemCreationCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new ItemCreatorViewModel(_navigationService,campaign,character)); }, CanExecuteMyCommand);
            NavigationExchangeCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new ExchangeViewModel(_navigationService,campaign,character)); }, CanExecuteMyCommand);
            // CancelCommand = new RelayCommand(ExecuteCancel, CanExecuteMyCommand);
            // SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
            NavigationEquipmentCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new InventoryViewModel(_navigationService,character,campaign)); }, CanExecuteMyCommand);
            NavigationAdvancementCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterCreatorViewModel(_navigationService, campaign)); }, CanExecuteMyCommand);
            NavigationSkillTestCommand = new RelayCommand(ExecuteEquipment, CanExecuteMyCommand);
            NavigationSpellCommand = new RelayCommand(ExecuteEquipment, CanExecuteMyCommand);
            NavigationOpposedTestCommand = new RelayCommand(ExecuteEquipment, CanExecuteMyCommand);
            NavigationRollDiceCommand = new RelayCommand((object parameter) => {
                DiceView subWindow = new DiceView();
                subWindow.DataContext = new DiceViewModel();
                subWindow.Show();
            }, CanExecuteMyCommand);
            NavigationTradeCommand = new RelayCommand(ExecuteEquipment, CanExecuteMyCommand);
        }
        //k20 k12 k10 k10 k8 k6 k4

        public BitmapImage Image
        {
            get
            {
                if (_characterModel.Image != null)
                    return _characterModel.Image;
                else return new BitmapImage();
            }
            set
            {
                _characterModel.Image = value;
                OnPropertyChanged("Image");
            }
        }
        private void ExecuteBack(object parameter)
        {
            //NavigationState pom = _navigationState;

          //  _navigationState.CurrentViewModel = new MenuViewModel(_navigationState);
        }
        private void ExecuteExchange(object parameter)
        {
            //NavigationState pom = _navigationState;

           // _navigationState.CurrentViewModel = new ExchangeViewModel(_navigationState);
        }

        private void ExecuteEquipment(object parameter)
        {
            //NavigationState pom = _navigationState;

          //  _navigationState.CurrentViewModel = new EquipmentViewModel(_navigationState);
        }
        private void ExecuteItemCreation(object parameter)
        {
          //  NavigationState pom = _navigationState;

            //_navigationState.CurrentViewModel = new ItemCreatorViewModel(pom,"Character");
        }

        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
