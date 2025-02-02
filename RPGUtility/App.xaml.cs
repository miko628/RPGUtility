﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RPGUtility.ViewModel;
namespace RPGUtility
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationState state=new NavigationState();
            NavigationService navigation = new NavigationService(state);
            state.CurrentViewModel = new HomeViewModel(navigation);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(state)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
