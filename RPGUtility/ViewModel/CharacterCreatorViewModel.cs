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
        private readonly NavigationState _navigationState;
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
        public string Year
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
        public ViewModelBase CurrentViewModel => _navigationState.CurrentViewModel;
        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }
        public RelayCommand ImageCommand { get; }
        public CharacterCreatorViewModel(NavigationState state)
        {
            _characterCreatorModel = new CharacterCreatorModel();
            _navigationState = state;
            _navigationState.CurrentViewModelChange += OnCurrentViewModelChange;
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteMyCommand);
            CancelCommand = new RelayCommand(ExecuteCancel, CanExecuteMyCommand);
            ImageCommand = new RelayCommand(ExecuteImage, CanExecuteMyCommand);
        }
        private void OnCurrentViewModelChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private void ExecuteSave(object parameter)
        {
            NavigationState pom = _navigationState;
            Trace.WriteLine("pomyslnie dodano postac");
            //dodaj zapisywanie do bazy danych
            Trace.WriteLine(CharacterName);
            Trace.WriteLine(Race);
            Trace.WriteLine(CurrentCarrer);
            Trace.WriteLine(PreviousCarrer);
            Trace.WriteLine(PlayerName);
            _navigationState.CurrentViewModel = new MenuViewModel(pom);

        }
        private void ExecuteCancel(object parameter)
        {
            NavigationState pom = _navigationState;
            _navigationState.CurrentViewModel = new MenuViewModel(pom);
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
