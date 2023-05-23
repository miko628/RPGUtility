using RPGUtility.Model;
using RPGUtility.Models;
using RPGUtility.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RPGUtility.ViewModel
{
    internal class CharacterViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly CharacterModel _characterModel;
        private Statistic _stats;
        private int[] _nextstatsSource;
        private int[] _statsSource;
        private Character _character;
        public string CharacterName { get; set; }
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand NavigationItemCreationCommand { get; }
      //  public RelayCommand CancelCommand { get; }
       // public RelayCommand SaveCommand { get; }
        //public RelayCommand NavigationExchangeCommand { get; }
        public RelayCommand NavigationEquipmentCommand { get; }
        public RelayCommand NavigationTradeCommand { get; }
        public RelayCommand NavigationAdvancementCommand { get; }
        public RelayCommand NavigationSkillTestCommand { get; }
        public RelayCommand NavigationSpellCommand { get; }
        //public RelayCommand NavigationOpposedTestCommand { get; }
        public RelayCommand NavigationRollDiceCommand { get; }

        public RelayCommand FatePointCommand { get; }
        public RelayCommand ResetFatePointCommand { get; }

        public int FatePoints { get; set; }
        public int CurrentHealth { get; set; }
        public int MaximumHealth { get; set; }
        public int[] NextStats
        {
            get
            {
                Trace.WriteLine("NextStats");
                return _nextstatsSource;
            }
            set
            {
                _nextstatsSource = value;
                OnPropertyChanged(nameof(NextStats));
            }
        }
        public int[] Stats
        {
            get
            {
                Trace.WriteLine("Stats");
                return _statsSource;
            }
            set
            {
                _statsSource = value;
                OnPropertyChanged(nameof(Stats));
            }
        }
        public CharacterViewModel(NavigationService navigation,Character character,Campaign campaign)
        {
            _characterModel = new CharacterModel();
            _navigationService = navigation;
            CharacterName = character.Name;
            _character = character;
            Image = ImageEncoder.BytearraytoBitmap(character.CharacterImage);
            //Statistic stat=_characterModel.GetStats(character);
            _statsSource = new int[8];
            _nextstatsSource = new int[8];
            LoadStats(character);
           // _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new StoryViewModel(_navigationService, campaign)); }, CanExecuteMyCommand);
            NavigationItemCreationCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new ItemCreatorViewModel(_navigationService,campaign,character,null)); }, CanExecuteMyCommand);
            //NavigationExchangeCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new ExchangeViewModel(_navigationService,campaign,character)); }, CanExecuteMyCommand);
            // CancelCommand = new RelayCommand(ExecuteCancel, CanExecuteMyCommand);
            // SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
            NavigationEquipmentCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new InventoryViewModel(_navigationService,character,campaign)); }, CanExecuteMyCommand);
            NavigationAdvancementCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterCreatorViewModel(_navigationService, campaign,character)); }, CanExecuteMyCommand);
            NavigationSkillTestCommand = new RelayCommand((object parameter) => {
                TestView subWindow = new TestView();
                subWindow.DataContext = new TestViewModel(character);
                subWindow.Show();
            }, CanExecuteMyCommand);
            FatePointCommand = new RelayCommand(ExecuteFate, CanExecuteMyCommand);
            NavigationSpellCommand = new RelayCommand(ExecuteEquipment, CanExecuteMyCommand);
            //NavigationOpposedTestCommand = new RelayCommand(ExecuteEquipment, CanExecuteMyCommand);
            NavigationRollDiceCommand = new RelayCommand((object parameter) => {
                DiceView subWindow = new DiceView();
                subWindow.DataContext = new DiceViewModel();
                subWindow.Show();
            }, CanExecuteMyCommand);
            NavigationTradeCommand = new RelayCommand(ExecuteEquipment, CanExecuteMyCommand);
            ResetFatePointCommand = new RelayCommand(ExecuteReset, CanExecuteMyCommand);

        }
        //k20 k12 k10 k10 k8 k6 k4
        private async void LoadStats(Character character)
        {

           _stats = await _characterModel.GetStats(character);
            //Stats.Clear();
            //NextStats.Clear();
            CurrentHealth = _stats.Health;
            MaximumHealth = _stats.Wounds;
            FatePoints = _stats.CurrentFatePoints;
            OnPropertyChanged(nameof(CurrentHealth));
            OnPropertyChanged(nameof(MaximumHealth));
            OnPropertyChanged(nameof(FatePoints));
            Stats[0] = _stats.WeaponSkill;
            Stats[1] = _stats.BallisticSkill;
            Stats[2] = _stats.Strength;
            Stats[3] = _stats.Toughness;
            Stats[4] = _stats.Agility;
            Stats[5] = _stats.Intelligence;
            Stats[6] = _stats.Willpower;
            Stats[7] = _stats.Fellowship;
            NextStats[0] = _stats.Attacks;
            NextStats[1] = _stats.Wounds;
            NextStats[2] = _stats.StrengthBonus;
            NextStats[3] = _stats.ToughnessBonus;
            NextStats[4] = _stats.Movement;
            NextStats[5] = _stats.Magic;
            NextStats[6] = _stats.InsanityPoints;
            NextStats[7] = _stats.FatePoints;
            OnPropertyChanged(nameof(Stats));
            OnPropertyChanged(nameof(NextStats));
        }

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
        private async void fate(Statistic stats)
        {
           
                _stats = await _characterModel.FatePoint(_stats);

            
        }
        private async void reset(Statistic stats)
        {
            _stats = await _characterModel.ResetFatePoint(_stats);
        }
        private void ExecuteFate(object parameter)
        {

            if (_stats is not null )
            {
                if (_stats.CurrentFatePoints > 0)
                {
                    fate(_stats);
                    //OnPropertyChanged(nameof(Stats));
                    LoadStats(_character);
                }
                else MessageBox.Show("Zbyt mało Punktów Szczęścia!");
            }
            FatePoints = _stats.CurrentFatePoints;
            OnPropertyChanged(nameof(FatePoints));
        }

        private void ExecuteReset(object parameter)
        {
            if (_stats is not null)
            {
                reset(_stats);
            }

            else { MessageBox.Show("Błąd przy resetowaniu punktów szczęścia"); }

            FatePoints = _stats.CurrentFatePoints;

            OnPropertyChanged(nameof(FatePoints));

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
