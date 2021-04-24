﻿using Automaton.Runner.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Automaton.Runner.Controls
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private async void LoginClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = App.Current.MainWindow as MainWindow;
            var viewModel = DataContext as LoginViewModel;

            var result = await viewModel.Login();

            if (result == Enums.AppNavigate.Dashboard)
                mainWindow.NavigateToDashboard();
            else if (result == Enums.AppNavigate.Registration)
                mainWindow.NavigateToRegistration();
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var viewModel = DataContext as LoginViewModel;
            viewModel.Password = passwordBox.Password;
        }
    }
}
