using Microsoft.Win32;
using RPGUtility.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
        private float _height;
        private float _weight;
        private string _previouscareer;
        private string _relatives;
        private string _star;
        private int _year;


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
        public float Weight
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
        public float Height
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
        public CharacterCreatorViewModel(NavigationService navigation)
        {

           _navigationService=navigation;
            _characterCreatorModel = new CharacterCreatorModel();
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
            //CancelCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterViewModel(_navigationService)); }, CanExecuteMyCommand);
            ImageCommand = new RelayCommand(ExecuteImage, CanExecuteMyCommand);
        }
        private void ExecuteSave(object parameter)
        {
            // NavigationState pom = _navigationState;
            _characterCreatorModel.Save();
            //tutaj dodaj jeszcze sprawdzenie czy wszystkie wymagane pola są git określone
            //Character character = new Character(CharacterName,Race,Gender,null,Year,Height,Weight,Hair,Eyes,Characteristics,BirthPlace,Star,Relatives,null,null,CurrentCarrer,"oko",PreviousCarrer);
            Trace.WriteLine("pomyslnie dodano postac");
            //dodaj zapisywanie do bazy danych
            //Character _character=new Character(CharacterName,Race,Gender,"ok",Year,height,)
            //Trace.WriteLine(character.name);
           // Trace.WriteLine(character.race);
            

           // _navigationService.Navigate(() => new CharacterViewModel(_navigationService));
            //_navigationState.CurrentViewModel = new MenuViewModel(pom);

        }
        private void ExecuteImage(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                string ImagePath = openFileDialog.FileName;
                var pom = new BitmapImage(new System.Uri(ImagePath));
                
                Image = ImageEncoder.bytearraytoBitmap(ImageEncoder.BitmapImagetobytearray(pom));
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
