using Microsoft.Win32;
using RPGUtility.Model;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace RPGUtility.ViewModel
{
    class CharacterCreatorViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly CharacterCreatorModel _characterCreatorModel;
        private readonly Character _character;
        private ObservableCollection<SkillCategory> _selectedskills;
        private ObservableCollection<TalentCategory> _selectedtalents;

        private string _characterName;
        private string[] _race;
        private int _age;
        private string _background;
        private string _birthPlace;
        private string _campaign;
        private string _gender;
        private string _characteristics;
       // private string _currentcareer;
        private string _eyes;
        private string _gamemaster;
        private string _hair;
        private string _playername;
        private double _height;
        private double _weight;
        //private string _previouscareer;
        private string _relatives;
        private string _star;
        private string _year;
        private readonly Campaign _campaignfull;
        private int[] _nextstatsSource;
        private int[] _statsSource;
        private string[] _charactertype;
        private SkillCategory _selectedskill;
        private TalentCategory _selectedtalent;
        private SkillCategory _selectedskill2;
        private TalentCategory _selectedtalent2;
        public SkillCategory SelectedSkill
        {
            get
            {
                //Trace.WriteLine(_selectedskill.ToString());
                return _selectedskill; }
            set
            { _selectedskill = value;
                if (SelectedSkill is not null)
                {
                    SelectedSkills.Add(_selectedskill);
                    SkillsList.Remove(SelectedSkill);
                    _selectedskill = null;
                }
                OnPropertyChanged(nameof(SelectedSkill));
                OnPropertyChanged(nameof(SkillsList));

            }
        }
        public TalentCategory SelectedTalent
        {
            get
            {
                //Trace.WriteLine(_selectedtalent.ToString());

                return _selectedtalent; }
            set
            {
                _selectedtalent = value;

                if (SelectedTalent is not null)
                {
                    SelectedTalents.Add(_selectedtalent);
                    TalentList.Remove(SelectedTalent);
                    _selectedtalent = null;
                }
                OnPropertyChanged(nameof(SelectedTalent));
                OnPropertyChanged(nameof(TalentList));

            }
        }

        public SkillCategory SelectedSkill2
        {
            get
            {
                //Trace.WriteLine(_selectedskill.ToString());
                return _selectedskill2;
            }
            set
            {
                _selectedskill2 = value;
                if (SelectedSkill2 is not null)
                {
                    SkillsList.Add(SelectedSkill2);
                    SelectedSkills.Remove(_selectedskill2);

                    _selectedskill2 = null;
                }
                OnPropertyChanged(nameof(SelectedSkill2));
                OnPropertyChanged(nameof(SkillsList));

            }
        }
        public TalentCategory SelectedTalent2
        {
            get
            {
                //Trace.WriteLine(_selectedtalent.ToString());

                return _selectedtalent2;
            }
            set
            {
                _selectedtalent2 = value;

                if (SelectedTalent2 is not null)
                {
                    TalentList.Add(SelectedTalent2);

                    SelectedTalents.Remove(SelectedTalent2);
                    _selectedtalent2 = null;
                }
                OnPropertyChanged(nameof(TalentList));

                OnPropertyChanged(nameof(SelectedTalent2));

            }
        }

        public int[] Stats
        {
            get {
                Trace.WriteLine("Stats");
                return _statsSource;
            }
            set
            {
                _statsSource = value;
                OnPropertyChanged(nameof(Stats));
            }
        }

        public ObservableCollection<SkillCategory> SkillsList { get; set; }

        public ObservableCollection<TalentCategory> TalentList { get; set; }

        public ObservableCollection<SkillCategory> SelectedSkills
        {
            get
            {
                return _selectedskills;
            }
            set
            {
                _selectedskills = value;
                OnPropertyChanged(nameof(SelectedSkills));
            }
        }

        public ObservableCollection<TalentCategory> SelectedTalents
        {
            get
            {
                return _selectedtalents;
            }
            set
            {
                _selectedtalents = value;
                OnPropertyChanged(nameof(SelectedTalents));
            }
        }
        public string SelectedCharacterType { get; set; }
        public string[] CharacterType
        {
            get { return _charactertype; }
            set {
                _charactertype = value;
                OnPropertyChanged(nameof(CharacterType));
            }
        }

        public int[] NextStats
        {
            get {
                Trace.WriteLine("NextStats");
                return _nextstatsSource; }
            set
            {
                _nextstatsSource = value;
                OnPropertyChanged(nameof(NextStats));
            }
        }
        public string SelectedRace { get; set; }

        public string CharacterName
        {
            get {
                Trace.WriteLine("CharacterName");
                return _characterName; }
            set {
                _characterName = value;
                OnPropertyChanged("CharacterName");
            }
        }
        public string[] Race
        {
            get { Trace.WriteLine("Race");
                return _race; }
            set {
                _race = value;
                OnPropertyChanged("Race");
            }
        }

        public string PlayerName
        {
            get { Trace.WriteLine("PlayerName");
                return _playername; }
            set
            {
                _playername = value;
                OnPropertyChanged("PlayerName");
            }
        }

        public double CashGold { get; set; }

        public double CashSilver { get; set; }

        public double CashPennies { get; set; }
        public string GameMaster
        {
            get
            {
                Trace.WriteLine("GameMaster");
                return _gamemaster;
            }
            set
            {
                _gamemaster = value;
                OnPropertyChanged("GameMaster");
            }
        }
        public string Campaign
        {
            get
            {
                Trace.WriteLine("Campaign");
                return _campaign;
            }
            set
            {
                _campaign = value;
                OnPropertyChanged("Campaign");
            }
        }
        public string Year
        {
            get
            {
                Trace.WriteLine("Year");
                return _year;
            }
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }
        public int Age
        {
            get
            {
                Trace.WriteLine("Age");
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }
        public string Gender
        {
            get
            {
                Trace.WriteLine("Gender");
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }
        public string Eyes
        {
            get
            {
                Trace.WriteLine("Eyes");
                return _eyes;
            }
            set
            {
                _eyes = value;
                OnPropertyChanged("Eyes");
            }
        }
        public double Weight
        {
            get
            {
                Trace.WriteLine("Weight");
                return _weight;
            }
            set
            {
                _weight = value;
                OnPropertyChanged("Weight");
            }
        }
        public string Hair
        {
            get
            {
                Trace.WriteLine("Hair");
                return _hair;
            }
            set
            {
                _hair = value;
                OnPropertyChanged("Hair");
            }
        }
        public double Height
        {
            get
            {
                Trace.WriteLine("Height");
                return _height;
            }
            set
            {
                _height = value;
                OnPropertyChanged("Height");
            }
        }
        public string Star
        {
            get
            {
                Trace.WriteLine("Star");
                return _star;
            }
            set
            {
                _star = value;
                OnPropertyChanged("Star");
            }
        }
        public string Relatives
        {
            get
            {
                Trace.WriteLine("Relatives");
                return _relatives;
            }
            set
            {
                _relatives = value;
                OnPropertyChanged("Relatives");
            }
        }
        public string BirthPlace
        {
            get
            {
                Trace.WriteLine("BirthPlace");
                return _birthPlace;
            }
            set
            {
                _birthPlace = value;
                OnPropertyChanged("BirthPlace");
            }
        }
        public string Characteristics
        {
            get
            {
                Trace.WriteLine("Characteristics");
                return _characteristics;
            }
            set
            {
                _characteristics = value;
                OnPropertyChanged("Characteristics");
            }
        }
        public string Background
        {
            get
            {
                Trace.WriteLine("Background");
                return _background;
            }
            set
            {
                _background = value;
                OnPropertyChanged("Background");
            }
        }
        public BitmapImage Image
        {
            get
            {
                return _characterCreatorModel.Image;
            }
            set
            {
                _characterCreatorModel.Image = value;
                OnPropertyChanged("Image");
            }
        }


        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }
        public RelayCommand ImageCommand { get; }
        public RelayCommand RollStats { get; }
        public RelayCommand NextRollStats { get; }

        public RelayCommand RollCash { get; }
        public CharacterCreatorViewModel(NavigationService navigation, Campaign? campaign, Character? character)
        {

            SkillsList = new ObservableCollection<SkillCategory>();
            TalentList = new ObservableCollection<TalentCategory>();
            _selectedtalents = new ObservableCollection<TalentCategory>();
            _selectedskills = new ObservableCollection<SkillCategory>();
            _statsSource = new int[8];
            _nextstatsSource = new int[8];
            _charactertype = new string[] { "Gracz", "NPC" };
            _race = new string[] { "Człowiek", "Elf", "Niziołek", "Krasnolud", "Inna" };
            SelectedRace = _race[0];
            SelectedCharacterType = _charactertype[0];
            //_selectedType=_type[0];
            _campaignfull = campaign;
            Campaign = _campaignfull.Name;
            GameMaster = _campaignfull.GameMaster;
            Year = _campaignfull.Year;
            _navigationService = navigation;
            _characterCreatorModel = new CharacterCreatorModel(campaign);

            
            if (character is not null)
            {
                _character = character;
                //BitmapImage pom=
                //Get();
                //GetTalent();

                //  Statistic pom = LoadStats(character);
                LoadStats(_character);
                SaveCommand = new RelayCommand(ExecuteUpdate, CanExecuteMyCommand);


            }
            else
            {
                SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);

            }
            Load();
            CancelCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterChooseViewModel(_navigationService, campaign)); }, CanExecuteMyCommand);
            ImageCommand = new RelayCommand(ExecuteImage, CanExecuteMyCommand);
            RollStats = new RelayCommand(DiceRoll, CanExecuteMyCommand);
            //ludzie,krasnoludy,elfy,niziolki
            RollCash = new RelayCommand((object parameter) => { CashGold = Dice.k10()+Dice.k10(); OnPropertyChanged(nameof(CashGold)); }, CanExecuteMyCommand);
            NextRollStats = new RelayCommand((object parameter) =>
            {
                for (int i = 0; i < 8; i++)
                {
                    NextStats[i] = Dice.k20();
                    Dice.k20();
                    //Thread.Sleep(20);
                }
                OnPropertyChanged(nameof(NextStats));
            }, CanExecuteMyCommand);
        }


    //List<Talent> talents = await _characterCreatorModel.GetTalent(_character);


private async void LoadStats(Character character)
        {
            Statistic pom = await _characterCreatorModel.GetStats(character);
            Stats[0] = pom.WeaponSkill;
            Stats[1] = pom.BallisticSkill;
            Stats[2] = pom.Strength;
            Stats[3] = pom.Toughness;
            Stats[4] = pom.Agility;
            Stats[5] = pom.Intelligence;
            Stats[6] = pom.Willpower;
            Stats[7] = pom.Fellowship;
            NextStats[0] = pom.Attacks;
            NextStats[1] = pom.Wounds;
            NextStats[2] = pom.StrengthBonus;
            NextStats[3] = pom.ToughnessBonus;
            NextStats[4] = pom.Movement;
            NextStats[5] = pom.Magic;
            NextStats[6] = pom.InsanityPoints;
            NextStats[7] = pom.FatePoints;
            OnPropertyChanged(nameof(Stats));
            OnPropertyChanged(nameof(NextStats));
        }
        private async void Load()
        {
            if(_character is not null)

            {
                Trace.WriteLine("powinno dziaąłc");
                Image = ImageEncoder.BytearraytoBitmap(_character.CharacterImage);
                CharacterName = _character.Name;
                PlayerName = _character.Playername;
                SelectedRace = _character.Race;
                Gender = _character.Gender;
                Age = _character.Age;
                Height = _character.Height;
                Weight = _character.Weight;
                Hair = _character.Hair;
                Eyes = _character.Eyes;
                Characteristics = _character.Characteristics;
                BirthPlace = _character.PlaceBirth;
                Star = _character.StarSign;
                Relatives = _character.Relatives;
                CashGold = _character.GoldCrowns;
                CashSilver = _character.SilverShillings;
                CashPennies = _character.BrassPenniews;

                List<Skill> skills = await _characterCreatorModel.GetSkill(_character);
                List<Talent> talents = await _characterCreatorModel.GetTalent(_character);

                SkillsList.Clear();
                List<SkillCategory> categories = await _characterCreatorModel.GetAllSkills();

                //
                foreach (SkillCategory category in categories)
                {
                    SkillsList.Add(category);

                    foreach (var skill in skills)
                    {
                        if (skill.SkillcategoryId == category.SkillId)
                        {
                            SelectedSkills.Add(category);
                            SkillsList.Remove(category);
                        } 
                    }
                }
                //
                TalentList.Clear();
                List<TalentCategory> pom2 = await _characterCreatorModel.GetAllTalents();
                foreach (TalentCategory talent in pom2)
                {
                    TalentList.Add(talent);
                    foreach (var t in talents)
                    {
                        if (t.TalentcategoryId == talent.TalentId)
                        {
                            SelectedTalents.Add(talent);
                            TalentList.Remove(talent);
                        }
 
                    }
                }
            }
            else
            {
                SkillsList.Clear();
                List<SkillCategory> categories = await _characterCreatorModel.GetAllSkills();
                foreach (SkillCategory category in categories)
                {
                    SkillsList.Add(category);
                }
                TalentList.Clear();
                List<TalentCategory> talents = await _characterCreatorModel.GetAllTalents();
                foreach (TalentCategory talent in talents)
                {
                    TalentList.Add(talent);
                }
            }
        }


        private void DiceRoll(object parameter)
        {
            //int value = Dice.k10();
            //int value2 = Dice.k10();
            int[] list;
            for (int i = 0; i < 8; i++)
            {
                Stats[i] = 0;
                NextStats[i] = 0;
            }
            // int basenumber = 0;
            switch (SelectedRace)
            {
                case "Elf":
                    list = _characterCreatorModel.ElfRoll();
                    for (int i = 0; i < 8; i++)
                    {
                        Stats[i] = list[i];
                        NextStats[i] = list[i + 8];
                    }
                    break;
                case "Człowiek":
                    list = _characterCreatorModel.HumanRoll();
                    for(int i=0;i<8;i++)
                    {
                        Stats[i] = list[i];
                        NextStats[i] = list[i + 8];
                    }
                    break;
                case "Niziołek":
                    list = _characterCreatorModel.HalflingRoll();
                    for (int i = 0; i < 8; i++)
                    {
                        Stats[i] = list[i];
                        NextStats[i] = list[i + 8];
                    }
                    break;
                case "Krasnolud":
                    list = _characterCreatorModel.DwarfRoll();
                    for (int i = 0; i < 8; i++)
                    {
                        Stats[i] = list[i];
                        NextStats[i] = list[i + 8];
                    }
                    break;
                default:
                    list = _characterCreatorModel.DefaultRoll();
                    for (int i = 0; i < 8; i++)
                    {
                        Stats[i] = list[i];
                        NextStats[i] = list[i + 8];
                    }
                    break;
            }


            OnPropertyChanged(nameof(Stats));
            OnPropertyChanged(nameof(NextStats));
        }
       
        private async void ExecuteSave(object parameter)
        {
            // NavigationState pom = _navigationState;
            // _characterCreatorModel.Save();
            //tutaj dodaj jeszcze sprawdzenie czy wszystkie wymagane pola są git określone
            //Character character = new Character(CharacterName,Race,Gender,null,Year,Height,Weight,Hair,Eyes,Characteristics,BirthPlace,Star,Relatives,null,null,CurrentCarrer,"oko",PreviousCarrer);
            //Trace.WriteLine("pomyslnie dodano postac");
            //dodaj zapisywanie do bazy danych
            //Character _character=new Character(CharacterName,Race,Gender,"ok",Year,height,)
            //Trace.WriteLine(character.name);
            // Trace.WriteLine(character.race);
            Character pom = await _characterCreatorModel.Save(Image,CharacterName,PlayerName,SelectedRace,Gender,Age,Height,Weight,Hair,Eyes,Characteristics,BirthPlace,Star,Relatives,CashGold,CashSilver,CashPennies,Stats,NextStats);

            await _characterCreatorModel.SaveSkill(pom,SelectedSkills.ToList());
            await _characterCreatorModel.SaveTalent(pom,SelectedTalents.ToList());
            _navigationService.Navigate(() => new CharacterViewModel(_navigationService,pom, _campaignfull));
            //_navigationState.CurrentViewModel = new MenuViewModel(pom);

        }
        public async void ExecuteUpdate(object parameter)
        {
             
            /*Character pom =*/ 
            await _characterCreatorModel.Update(_character,Image, CharacterName, PlayerName, SelectedRace, Gender, Age, Height, Weight, Hair, Eyes, Characteristics, BirthPlace, Star, Relatives, CashGold, CashSilver, CashPennies, Stats, NextStats);
            await _characterCreatorModel.UpdateSkill(_character, SelectedSkills.ToList());
            await _characterCreatorModel.UpdateTalent(_character, SelectedTalents.ToList());
            _navigationService.Navigate(() => new CharacterViewModel(_navigationService, _character, _campaignfull));
        }
        private void ExecuteImage(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string ImagePath = openFileDialog.FileName;
                Image = new BitmapImage(new Uri(ImagePath));
                
                //Image = ImageEncoder.bytearraytoBitmap(ImageEncoder.BitmapImagetobytearray(pom));
                //Image = new BitmapImage(new System.Uri(ImagePath));
            }
        }

        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
