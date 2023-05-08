using RPGUtility.Model;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RPGUtility.ViewModel
{
    internal class StoryViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private StoryModel _storyModel;
        //private int? campaign_id;
        private Act? _selectedAct;
        private string? _name;
        private string? _description;
        private string? _gamemaster;
        private string? _year;
        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand NavigateMenuCommand { get; }
        public RelayCommand NewActCommand { get; }
        public RelayCommand DeleteActCommand { get; }

        public Act SelectedAct {
            get {
                if (_selectedAct != null)
                {
                    Name = _selectedAct.Name;
                    Description = _selectedAct.Description;
                    GameMaster = "";
                    Year = "";
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
        public RelayCommand EditCampaignCommand { get; }
        public ObservableCollection<Act> Acts
        {
            get { return _storyModel.Acts; }
            set
            {
                _storyModel.Acts = value;
                OnPropertyChanged(nameof(Acts));
            }
        }
        public string Name
        {
            get
            {
                Trace.WriteLine("Name");
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
                Trace.WriteLine("Description");
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
                Trace.WriteLine("GameMaster");
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
                Trace.WriteLine("Year");
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
                foreach (var item in ac)
                {
                    Acts.Add(item);
                }
            });


        }
        public StoryViewModel(NavigationService navigation, Campaign? campaign)
        {
            _navigationService = navigation;
            _storyModel = new StoryModel(campaign);
            // Name = campaign_id.ToString();
            try 
            {
                Name = campaign.Name;
                Description = campaign.Description;
                Year = new string("Rok gry: " + campaign.Year);
                GameMaster = new string("Mistrz gry: " + campaign.GameMaster);
            }
            catch
            (ArgumentNullException e)
            { }
            
            //_storyModel._campaign = campaign;
            // _storyModel.id=campaign_id.GetValueOrDefault();
            //Trace.WriteLine(campaign_id);
            Task.Run(Load);
            //new ThreadPriorityLevel start=()=> Backgrou
            NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CampaignViewModel(_navigationService)); }, CanExecuteMyCommand);
            NewActCommand = new RelayCommand(async(object parameter) => { await _storyModel.AddAct(); await Load();/*do tworzenia postaci*/ }, CanExecuteMyCommand);
            DeleteActCommand = new RelayCommand(async (object parameter) => { await _storyModel.Delete(_selectedAct); await Load(); }, CanExecuteMyCommand);
            NavigateMenuCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new MenuViewModel(_navigationService,campaign)); }, CanExecuteMyCommand);
            EditCampaignCommand = new RelayCommand((object parameter) =>
            {
            }, CanExecuteMyCommand);
            // Name = campaign_id;
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
