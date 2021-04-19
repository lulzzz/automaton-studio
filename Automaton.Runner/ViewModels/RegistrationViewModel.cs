﻿using Automaton.Runner.Core.Services;
using Automaton.Runner.Services;
using System;
using System.Threading.Tasks;

namespace Automaton.Runner.ViewModels
{
    public class RegistrationViewModel
    {
        private readonly IHubService hubService;
        private readonly IAuthService authService;

        public RegistrationViewModel(IHubService hubService, IAuthService authService)
        {
            this.hubService = hubService;
            this.authService = authService;
        }

        public async Task Register(string runnerName)
        {
            await hubService.Connect(authService.Token, runnerName);

            var registered = await hubService.Register(runnerName);

            if (registered)
            {

            }

            var mainWindow = App.Current.MainWindow as MainWindow;
            mainWindow.ShowDashboardControl();
        }
    }
}
