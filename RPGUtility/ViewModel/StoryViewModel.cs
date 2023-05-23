using RPGUtility.Model;
using RPGUtility.Models;
using RPGUtility.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RPGUtility.ViewModel
{
    internal class StoryViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly StoryModel _storyModel;
        private readonly Campaign _campaign;
        private dynamic _selectedAct;
        private string _name;
        private string _description;
        private string _gamemaster;
        private string _year;
        private bool _canExecute = true;
        private bool _isreadonly = true;
        private bool _ishidden = true;
        private dynamic _actlist;
        public bool ReadOnly
        {
            get { return _isreadonly; }
            set
            {
                _isreadonly = value;
                OnPropertyChanged(nameof(ReadOnly));
            }
        }
        public bool Hide
        {
            get { return _ishidden; }
            set
            {
                _ishidden = value;
                OnPropertyChanged(nameof(Hide));
            }
        }
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand NavigateCharacterCommand { get; }

        public RelayCommand SaveEditCommand { get; }
        public RelayCommand DiceRollCommand { get; }
        public RelayCommand NewActCommand { get; }

        public RelayCommand DeleteActCommand { get; }
        public RelayCommand EditCampaignCommand { get; }
        public RelayCommand NavigateExchangeCommand { get; }
        public RelayCommand NavigateTestCommand { get; }
        public dynamic SelectedAct
        {
            get
            {
                if (_selectedAct != null)
                {
                    Name = _selectedAct.Name;
                    Description = _selectedAct.Description;
                    if (_selectedAct is Campaign)
                    {
                        Hide = true;
                        GameMaster = _selectedAct.GameMaster;
                        Year = _selectedAct.Year;
                    }
                    else
                    {
                        Hide = false;
                    }
                }

                return _selectedAct;
            }
            set
            {
                _selectedAct = value;

                // _storyModel.ChangeStory(_selectedAct);
                OnPropertyChanged(nameof(SelectedAct));
            }
        }

        public ObservableCollection<dynamic> Acts
        {
            get { return _actlist; }
            set
            {
                _actlist = value;
                OnPropertyChanged(nameof(Acts));
            }
        }
        public string Name
        {
            get
            {
                // Trace.WriteLine("Name");
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get
            {
                // Trace.WriteLine("Description");
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public string GameMaster
        {
            get
            {
                //Trace.WriteLine("GameMaster");
                return _gamemaster;
            }
            set
            {
                _gamemaster = value;
                OnPropertyChanged("GameMaster");
            }
        }

        public string Year
        {
            get
            {
                //Trace.WriteLine("Year");
                return _year;
            }
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }

        private async Task Load()
        {
            List<Act> ac = await _storyModel.GetAll();
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                Acts.Clear();
                Acts.Add(_campaign);
                foreach (var item in ac)
                {
                    Acts.Add(item);
                }
            });


        }
        public StoryViewModel(NavigationService navigation, Campaign? campaign)
        {
            _navigationService = navigation;
            if (campaign != null)
            {
                _storyModel = new StoryModel(campaign);
                // Name = campaign_id.ToString();
                _campaign = campaign;

                _actlist = new ObservableCollection<dynamic>();
                //_storyModel._campaign = campaign;
                // _storyModel.id=campaign_id.GetValueOrDefault();
                //Trace.WriteLine(campaign_id);
                //Acts.Add(campaign);
                Task.Run(Load);
                _selectedAct = _campaign;
                OnPropertyChanged(nameof(SelectedAct));
                //new ThreadPriorityLevel start=()=> Backgrou
                NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CampaignViewModel(_navigationService)); }, CanExecuteMyCommand);
                NewActCommand = new RelayCommand(async (object parameter) => { await _storyModel.AddAct(Acts.Count()); await Load();/*do tworzenia postaci*/ }, CanExecuteMyCommand);
                DeleteActCommand = new RelayCommand(async (object parameter) =>
                {
                    if (_selectedAct is not null)
                    {
                        await _storyModel.Delete(_selectedAct); _selectedAct = _campaign;
                        OnPropertyChanged(nameof(SelectedAct)); await Load();
                    }
                }, CanExecuteMyCommand);
                NavigateCharacterCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CharacterChooseViewModel(_navigationService, campaign)); }, CanExecuteMyCommand);
                NavigateExchangeCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new ExchangeViewModel(_navigationService, campaign)); }, CanExecuteMyCommand);
                NavigateTestCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new TestOpposedViewModel(_navigationService, campaign)); }, CanExecuteMyCommand);
                SaveEditCommand = new RelayCommand(async (object parameter) =>
                {

                    if (_selectedAct is Act)
                    {
                        await _storyModel.UpdateAct(_selectedAct, Name, Description);
                        await Task.Run(Load);
                    }
                    else
                    {
                        await _storyModel.UpdateCampaign(Name, Description, GameMaster, Year);
                        await Task.Run(Load);
                    }

                }, CanExecuteMyCommand);

                EditCampaignCommand = new RelayCommand((object parameter) =>
                {
                    ReadOnly = !ReadOnly;
                }, CanExecuteMyCommand);
                DiceRollCommand = new RelayCommand((object parameter) =>
                {
                    DiceView subWindow = new();
                    subWindow.DataContext = new DiceViewModel();
                    subWindow.Closed += (sender, args) => { _canExecute = true; };

                    subWindow.Show();
                    _canExecute = false;

                }, ExecuteCommand);
                // Name = campaign_id;
            }
            else
            {
                //dodaj tu jeszcze message box ok ok
                _navigationService.Navigate(() => new CampaignViewModel(_navigationService));

            }
        }

        private bool ExecuteCommand(object parameter)
        {
            if (Application.Current.MainWindow != null)
            {
                return true;//  Application.Current.MainWindow.Activate();
            }
            else return false;
            //_canExecute = !_canExecute;
            // return _canExecute;
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
