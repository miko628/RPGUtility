using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGUtility.Model;
using System.Diagnostics;

namespace RPGUtility.ViewModel
{
    internal class TestOpposedViewModel:ViewModelBase
    {
        private readonly Campaign _campaign;
        private readonly TestOpossedModel _testOpposedModel;
        private readonly NavigationService _navigationService;
        public RelayCommand NavigateBackCommand { get; }
        private ObservableCollection<Character> _characters;
        private Character _selectedcharacter;
        private bool _isComboBoxVisible;
        private Character _selectedcharacter2;
        private bool _isComboBoxVisible2;
        private int index;
        public ObservableCollection<SkillCategory> Skills1 { get; set; }
        public ObservableCollection<SkillCategory> Skills2 { get; set; }
        public int SelectedItem
        {
            get
            {
                Trace.WriteLine(index);
                return index;
            }
            set 
            { index = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set
            {
                _characters = value;
                OnPropertyChanged(nameof(Characters));
            }
        }

        public string CharacterName1 { get; set; }
        public string CharacterName2 { get; set; }
        public int[] Stats1 { get; set; }
        public int[] Stats2 { get; set; }

        public bool IsComboBoxVisible
        {
            get { return _isComboBoxVisible; }
            set
            {
                _isComboBoxVisible = value;
                OnPropertyChanged(nameof(IsComboBoxVisible));
            }
        }

        public bool IsComboBoxVisible2
        {
            get { return _isComboBoxVisible2; }
            set
            {
                _isComboBoxVisible2 = value;
                OnPropertyChanged(nameof(IsComboBoxVisible2));
            }
        }

        public Character SelectedCharacter
        {
            get { return _selectedcharacter; }
            set
            {
                _selectedcharacter = value;
                OnPropertyChanged(nameof(SelectedCharacter));
                IsComboBoxVisible = false;
                if (SelectedCharacter is not null) { CharacterName1 = SelectedCharacter.Name;
                    LoadSkill1();
                }
                OnPropertyChanged(nameof(CharacterName1));
                
                
            }
        }
        public Character SelectedCharacter2
        {
            get { return _selectedcharacter2; }
            set
            {
                _selectedcharacter2 = value;
                OnPropertyChanged(nameof(SelectedCharacter2));
                IsComboBoxVisible2 = false;
                if (SelectedCharacter2 is not null) { CharacterName2 = SelectedCharacter2.Name;
                    LoadSkill2();
                }
                OnPropertyChanged(nameof(CharacterName2));

            }
        }
        public RelayCommand ChooseCharacterCommand { get; }
        public RelayCommand ChooseCharacterCommand2 { get; }
        public RelayCommand OkCommand { get; }
        public RelayCommand SaveCommand { get; }
        public bool ResultVisibility { get; set; }//zmienna do wyświetlania okna z wynnikiem

        public string HeadText { get; set; }//nagłówek okna z wynikiem
        public string BodyText { get; set; }//wynik dla okna z wynikiem

        public TestOpposedViewModel(NavigationService navigation, Campaign campaign)
        {
            _navigationService = navigation;
            _campaign = campaign;
            _characters = new ObservableCollection<Character>();
            Stats1 = new int[8];
            Stats2 = new int[8];
            IsComboBoxVisible = false;
            IsComboBoxVisible2 = false;
            _testOpposedModel = new TestOpossedModel(campaign);
            Skills1 = new ObservableCollection<SkillCategory>();
            Skills2 = new ObservableCollection<SkillCategory>();
            Load();
            
            NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new StoryViewModel(_navigationService, campaign)); }, CanExecuteMyCommand);
            ChooseCharacterCommand = new RelayCommand((object parameter) => { SelectedCharacter = null; IsComboBoxVisible = true; }, CanExecuteMyCommand);
            ChooseCharacterCommand2 = new RelayCommand((object parameter) => { SelectedCharacter2 = null; IsComboBoxVisible2 = true; }, CanExecuteMyCommand);
            OkCommand = new RelayCommand((object parameter) => {
                ResultVisibility = false;
                OnPropertyChanged(nameof(ResultVisibility));

            }, CanExecuteMyCommand);
            SaveCommand = new RelayCommand((object parameter) => {

                ResultVisibility = true;
                OnPropertyChanged(nameof(ResultVisibility));

            }, CanExecuteMyCommand);
        }
        
        private async void LoadSkill1()
        {
            List<SkillCategory> skills = await _testOpposedModel.GetSkills(SelectedCharacter);
            Statistic pom=await _testOpposedModel.GetStats(SelectedCharacter);
            Stats1[0] = pom.WeaponSkill;
            Stats1[1] = pom.BallisticSkill;
            Stats1[2] = pom.Strength;
            Stats1[3] = pom.Toughness;
            Stats1[4] = pom.Agility;
            Stats1[5] = pom.Intelligence;
            Stats1[6] = pom.Willpower;
            Stats1[7] = pom.Fellowship;
            Skills1.Clear();
            OnPropertyChanged(nameof(Stats1));
            foreach(var item in skills)
            {
                Skills1.Add(item);
                Trace.WriteLine(item.Name);
            }
            OnPropertyChanged(nameof(Skills1));
            //List<SkillCategory> skills2 = await _testOpposedModel.GetSkills(SelectedCharacter2);
        }
        private async void LoadSkill2()
        {
            List<SkillCategory> skills = await _testOpposedModel.GetSkills(SelectedCharacter2);
            Statistic pom = await _testOpposedModel.GetStats(SelectedCharacter2);
            Stats2[0] = pom.WeaponSkill;
            Stats2[1] = pom.BallisticSkill;
            Stats2[2] = pom.Strength;
            Stats2[3] = pom.Toughness;
            Stats2[4] = pom.Agility;
            Stats2[5] = pom.Intelligence;
            Stats2[6] = pom.Willpower;
            Stats2[7] = pom.Fellowship;
            Skills2.Clear();
            OnPropertyChanged(nameof(Stats2));
            foreach (var item in skills)
            {
                Skills2.Add(item);
                Trace.WriteLine(item.Name);

            }
            OnPropertyChanged(nameof(Skills2));
            //List<SkillCategory> skills2 = await _testOpposedModel.GetSkills(SelectedCharacter2);
        }
        private async Task Load()
        {

            List<Character> camp = await _testOpposedModel.GetAll();
            

            await App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                Characters.Clear();
                foreach (var item in camp)
                {
                    Characters.Add(item);
                }
            });
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
