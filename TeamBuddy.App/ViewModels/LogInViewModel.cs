﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TeamBuddy.App.Commands;
using TeamBuddy.App.Services;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Repositories;
using TeamBuddy.BL.Services;
using TeamBuddy.DAL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly IMessageBoxService messageBoxService;
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private object _showLogin = new Object();

        public Object ShowLogin
        {
            get => _showLogin;
            set
            {
                _showLogin = value;
                OnPropertyChanged();
            }
        }

        public UserDetailModel User { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LogInCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public LogInViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository, IMessageBoxService messageBoxService)
        {
            this.mediator = mediator;
            this.messageBoxService = messageBoxService;
            this.teamBuddyRepository = teamBuddyRepository;

            LogInCommand = new RelayCommand(LogIn);
            PasswordChangedCommand = new RelayCommand(PasswordChange);
        }

        private void PasswordChange(Object obj)
        {
            if (obj != null)
            {
                Password = ((PasswordBox)obj).Password;
            }
        }

        private void LogIn()
        {
            //string pass = Hasher.GetHash("pass");
            User = teamBuddyRepository.GetByEmail(Email);
            if (User == null)
            {
                messageBoxService.Show($"Login by {Email} failed!", "Login failed", MessageBoxButton.OK);
            }
            else
            {
                if (Password != User.Password)
                {
                    messageBoxService.Show($"Invalid password!", "Login failed", MessageBoxButton.OK);
                }
                else
                {
                    mediator.Send(new LogInMessage { SignedUser = User });
                    ShowLogin = null;
                }
            }
        }
    }
}