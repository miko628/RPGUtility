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
        public string CharacterName
        {
            get {
                Trace.WriteLine("CharacterName");
                return _characterCreatorModel.CharacterName; }
            set {
                _characterCreatorModel.CharacterName = value;
                OnPropertyChanged("CharacterName");
            }
        }
        public string Race
        {
            get { Trace.WriteLine("Race");
                return _characterCreatorModel.Race; }
            set {
                _characterCreatorModel.Race = value;
                OnPropertyChanged("Race");
            }
        }
        public string CurrentCarrer
        {
            get { Trace.WriteLine("CurrentCarrer");
                return _characterCreatorModel.CurrentCarrer; }
            set
            {
                _characterCreatorModel.CurrentCarrer = value;
                OnPropertyChanged("CurrentCarrer");
            }
        }
        public string PreviousCarrer
        {
            get { Trace.WriteLine("PreviousCarrer"); 
                return _characterCreatorModel.PreviousCarrer; }
            set
            {
                _characterCreatorModel.PreviousCarrer = value;
                OnPropertyChanged("PreviousCarrer");
            }
        }
        public string PlayerName
        {
            get { Trace.WriteLine("PlayerName");
                return _characterCreatorModel.PlayerName; }
            set
            {
                _characterCreatorModel.PlayerName = value;
                OnPropertyChanged("PlayerName");
            }
        }
        public string GameMaster
        {
            get
            {
                Trace.WriteLine("GameMaster");
                return _characterCreatorModel.GameMaster;
            }
            set
            {
                _characterCreatorModel.GameMaster = value;
                OnPropertyChanged("GameMaster");
            }
        }
        public string Campaign
        {
            get
            {
                Trace.WriteLine("Campaign");
                return _characterCreatorModel.Campaign;
            }
            set
            {
                _characterCreatorModel.Campaign = value;
                OnPropertyChanged("Campaign");
            }
        }
        public int Year
        {
            get
            {
                Trace.WriteLine("Year");
                return _characterCreatorModel.Year;
            }
            set
            {
                _characterCreatorModel.Year = value;
                OnPropertyChanged("Year");
            }
        }
        public int Age
        {
            get
            {
                Trace.WriteLine("Age");
                return _characterCreatorModel.Age;
            }
            set
            {
                _characterCreatorModel.Age = value;
                OnPropertyChanged("Age");
            }
        }
        public string Gender
        {
            get
            {
                Trace.WriteLine("Gender");
                return _characterCreatorModel.Gender;
            }
            set
            {
                _characterCreatorModel.Gender = value;
                OnPropertyChanged("Gender");
            }
        }
        public string Eyes
        {
            get
            {
                Trace.WriteLine("Eyes");
                return _characterCreatorModel.Eyes;
            }
            set
            {
                _characterCreatorModel.Eyes = value;
                OnPropertyChanged("Eyes");
            }
        }
        public float Weight
        {
            get
            {
                Trace.WriteLine("Weight");
                return _characterCreatorModel.Weight;
            }
            set
            {
                _characterCreatorModel.Weight = value;
                OnPropertyChanged("Weight");
            }
        }
        public string Hair
        {
            get
            {
                Trace.WriteLine("Hair");
                return _characterCreatorModel.Hair;
            }
            set
            {
                _characterCreatorModel.Hair = value;
                OnPropertyChanged("Hair");
            }
        }
        public float Height
        {
            get
            {
                Trace.WriteLine("Height");
                return _characterCreatorModel.Height;
            }
            set
            {
                _characterCreatorModel.Height = value;
                OnPropertyChanged("Height");
            }
        }
        public string Star
        {
            get
            {
                Trace.WriteLine("Star");
                return _characterCreatorModel.Star;
            }
            set
            {
                _characterCreatorModel.Star = value;
                OnPropertyChanged("Star");
            }
        }
        public string Relatives
        {
            get
            {
                Trace.WriteLine("Relatives");
                return _characterCreatorModel.Relatives;
            }
            set
            {
                _characterCreatorModel.Relatives = value;
                OnPropertyChanged("Relatives");
            }
        }
        public string BirthPlace
        {
            get
            {
                Trace.WriteLine("BirthPlace");
                return _characterCreatorModel.BirthPlace;
            }
            set
            {
                _characterCreatorModel.BirthPlace = value;
                OnPropertyChanged("BirthPlace");
            }
        }
        public string Characteristics
        {
            get
            {
                Trace.WriteLine("Characteristics");
                return _characterCreatorModel.Characteristics;
            }
            set
            {
                _characterCreatorModel.Characteristics = value;
                OnPropertyChanged("Characteristics");
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
            CancelCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new MenuViewModel(_navigationService)); }, CanExecuteMyCommand);
            ImageCommand = new RelayCommand(ExecuteImage, CanExecuteMyCommand);
        }
        private void ExecuteSave(object parameter)
        {
            // NavigationState pom = _navigationState;
            _characterCreatorModel.Save();
            Trace.WriteLine("pomyslnie dodano postac");
            //dodaj zapisywanie do bazy danych
            //Character _character=new Character(CharacterName,Race,Gender,"ok",Year,height,)
            Trace.WriteLine(CharacterName);
            Trace.WriteLine(Race);
            Trace.WriteLine(CurrentCarrer);
            Trace.WriteLine(PreviousCarrer);
            Trace.WriteLine(PlayerName);

            _navigationService.Navigate(() => new MenuViewModel(_navigationService));
            //_navigationState.CurrentViewModel = new MenuViewModel(pom);

        }
        private void ExecuteImage(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string ImagePath = openFileDialog.FileName;
                Image = new BitmapImage(new System.Uri(ImagePath));
            }
        }

        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
