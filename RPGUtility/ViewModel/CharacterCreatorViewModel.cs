using Microsoft.Win32;
using RPGUtility.Model;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RPGUtility.ViewModel
{
    class CharacterCreatorViewModel: ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private CharacterCreatorModel _characterCreatorModel;
        private string _characterName;
        private string _race;
        private int _age;
        private string _background;
        private string _birthPlace;
        private string _campaign;
        private string _gender;
        private string _characteristics;
        private string _currentcareer;
        private string _eyes;
        private string _gamemaster;
        private string _hair;
        private string _playername;
        private double _height;
        private double _weight;
        private string _previouscareer;
        private string _relatives;
        private string _star;
        private int _year;
        private Campaign _campaignfull;
       
        private int[] _nextstatsSource;
        private int[] _nextstats1Source;
        private int[] _nextstats2Source;

        private int[] _statsSource;
        private int[] _stats1Source;
        private int[] _stats2Source;
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
        public int[] Stats1
        {
            get {
                Trace.WriteLine("Stats1");
                return _stats1Source; }
            set
            {
                _stats1Source = value;
                OnPropertyChanged(nameof(Stats1));
            }
        }
        public int[] Stats2
        {
            get {
                Trace.WriteLine("Stats2");
                return _stats2Source; }
            set
            {
                _stats2Source = value;
                OnPropertyChanged(nameof(Stats2));
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
        public int[] NextStats1
        {
            get { Trace.WriteLine("NextStats1"); return _nextstats1Source; }
            set
            {
                _nextstats1Source = value;
                OnPropertyChanged(nameof(NextStats1));
            }
        }
        public int[] NextStats2
        {
            get {
                Trace.WriteLine("NextStats2"); 
                return _nextstats2Source; }
            set
            {
                _nextstats2Source = value;
                OnPropertyChanged(nameof(NextStats2));
            }
        }



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
        public string Race
        {
            get { Trace.WriteLine("Race");
                return _race; }
            set {
                _race = value;
                OnPropertyChanged("Race");
            }
        }
        public string CurrentCarrer
        {
            get { Trace.WriteLine("CurrentCarrer");
                return _currentcareer; }
            set
            {
                _currentcareer = value;
                OnPropertyChanged("CurrentCarrer");
            }
        }
        public string PreviousCarrer
        {
            get { Trace.WriteLine("PreviousCarrer"); 
                return _previouscareer; }
            set
            {
                _previouscareer = value;
                OnPropertyChanged("PreviousCarrer");
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
        public int Year
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
        public RelayCommand RollStats1 { get; }
        public RelayCommand RollStats2 { get; }
        public RelayCommand NextRollStats { get; }
        public RelayCommand NextRollStats1 { get; }
        public RelayCommand NextRollStats2 { get; }
        public CharacterCreatorViewModel(NavigationService navigation,Campaign? campaign)
        {
            _statsSource = new int[8]; 
            _stats1Source = new int[8]; 
            _stats2Source = new int[8]; 
            _nextstatsSource = new int[8]; 
            _nextstats1Source = new int[8]; 
            _nextstats2Source = new int[8];
            _campaignfull = campaign;
            _navigationService =navigation;
            _characterCreatorModel = new CharacterCreatorModel(campaign);
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
            CancelCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterChooseViewModel(_navigationService,campaign)); }, CanExecuteMyCommand);
            ImageCommand = new RelayCommand(ExecuteImage, CanExecuteMyCommand);
            RollStats = new RelayCommand(DiceRoll, CanExecuteMyCommand);
            RollStats1 = new RelayCommand(DiceRoll1, CanExecuteMyCommand);
            RollStats2 = new RelayCommand(DiceRoll2, CanExecuteMyCommand);
            NextRollStats = new RelayCommand((object parameter) => {
                for (int i = 0; i < 8; i++)
                {
                    NextStats[i] = Dice.k20();
                    Dice.k20();
                    //Thread.Sleep(20);
                }
                OnPropertyChanged(nameof(NextStats));
            }, CanExecuteMyCommand);
            NextRollStats1 = new RelayCommand((object parameter) => {
                for (int i = 0; i < 8; i++)
                {
                    int result=Dice.k20();
                    //result=Dice.k20();
                    NextStats1[i] = result;
                    //result = Dice.k20();
                }
                OnPropertyChanged(nameof(NextStats1));
            }, CanExecuteMyCommand);
            NextRollStats2 = new RelayCommand((object parameter) => {
                for (int i = 0; i < 8; i++)
                {
                    NextStats2[i] = Dice.k20();
                }
                OnPropertyChanged(nameof(NextStats2));
            }, CanExecuteMyCommand);
        }
        private void DiceRoll(object parameter)
        {
            for (int i = 0; i < 8; i++)
            {
                Stats[i] = Dice.k20(); ;
            }
            OnPropertyChanged(nameof(Stats));
        }
        private void DiceRoll1(object parameter)
        {
            for (int i = 0; i < 8; i++)
            {
                Stats1[i] = Dice.k20();
            }
            OnPropertyChanged(nameof(Stats1));
        }
        private void DiceRoll2(object parameter)
        {
            for (int i = 0; i < 8; i++)
            {
                Stats2[i] = Dice.k30();
            }
            OnPropertyChanged(nameof(Stats2));
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
            Character pom = await _characterCreatorModel.Save(Image,CharacterName,Race,Gender,Background,new DateOnly(),Height,Weight,Hair,Eyes,Characteristics,BirthPlace,Star,Relatives,"","","","","",1.0,12.0,13.0,Stats,Stats1,Stats2);

             _navigationService.Navigate(() => new CharacterViewModel(_navigationService,pom, _campaignfull));
            //_navigationState.CurrentViewModel = new MenuViewModel(pom);

        }
        private void ExecuteImage(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                string ImagePath = openFileDialog.FileName;
                Image = new BitmapImage(new System.Uri(ImagePath));
                
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
