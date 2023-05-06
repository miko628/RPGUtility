using RPGUtility.Model;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.ViewModel
{
    internal class StoryViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private StoryModel _storyModel;
        private int? campaign_id;
        public string Name
        {
            get
            {
                Trace.WriteLine("Name");
                return _storyModel.Name;
            }
            set
            {
                _storyModel.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get
            {
                Trace.WriteLine("Description");
                return _storyModel.Description;
            }
            set
            {
                _storyModel.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public string GameMaster
        {
            get
            {
                Trace.WriteLine("GameMaster");
                return _storyModel.GameMaster;
            }
            set
            {
                _storyModel.GameMaster = value;
                OnPropertyChanged("GameMaster");
            }
        }

        public string Year
        {
            get
            {
                Trace.WriteLine("Year");
                return _storyModel.Year;
            }
            set
            {
                _storyModel.Year = value;
                OnPropertyChanged("Year");
            }
        }

        public RelayCommand NavigateBackCommand { get; }

        public RelayCommand NewActCommand { get; }
        public RelayCommand DeleteActCommand { get; }
        public StoryViewModel(NavigationService navigation, Campaign campaign)
        {
            _navigationService = navigation;
            _storyModel = new StoryModel(campaign);
            // Name = campaign_id.ToString();
            //_storyModel._campaign = campaign;
            // _storyModel.id=campaign_id.GetValueOrDefault();
            //Trace.WriteLine(campaign_id);

            NavigateBackCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CampaignViewModel(_navigationService)); }, CanExecuteMyCommand);
            NewActCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CampaignViewModel(_navigationService)); /*do tworzenia postaci*/ }, CanExecuteMyCommand);
            DeleteActCommand = new RelayCommand((object parameter) => { _navigationService.Navigate(() => new CampaignViewModel(_navigationService)); }, CanExecuteMyCommand);
            // Name = campaign_id;
        }
        private bool CanExecuteMyCommand(object parameter)
        {
            // Tutaj wpisz kod, który sprawdzi, czy przycisk jest aktywny
            return true;
        }
    }
}
