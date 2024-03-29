﻿using StoryWriter.PageModels.Base;
using StoryWriter.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoryWriter.PageModels
{
    public class LoginEmailPageModel : PageModelBase
    {
        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get => _loginCommand;
            set => SetProperty(ref _loginCommand, value);
        }

        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private INavigationService _navigationService;
        private IAccountService _accountService;
        private readonly IMessageService messageService;

        public LoginEmailPageModel(INavigationService navigationService, IAccountService accountService, IMessageService messageService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            this.messageService = messageService;

            // Init our Login Command
            LoginCommand = new Command(DoLoginAction);
        }

        /// <summary>
        /// Perform login validation and navigation if applicable
        /// </summary>
        private async void DoLoginAction()
        {
            var loginAttempt = await _accountService.LoginAsync(Username, Password);
            if (loginAttempt)
            {
                // navigate to the Dashboard.
                await _navigationService.NavigateToAsync<DashboardPageModel>();
            }
            else
            {
                messageService.LongAlert("Login failed");
            }
        }
    }
}