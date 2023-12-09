using StudentDiary_WPF.Commands;
using StudentDiary_WPF.Models;
using StudentDiary_WPF.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace StudentDiary_WPF.ViewModels
{
    public class UserSettingsViewModel : ViewModelBase
    {
        
        public UserSettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);



        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        public string DbServerAddress {
            get {
                
                return Settings.Default.DbServerAddress;
            }
            set { 
                Settings.Default.DbServerAddress = value;
                OnPropertychanged();
            } 
        }
        public string DbServerName
        {
            get
            {

                return Settings.Default.DbServerName;
            }
            set
            {
                Settings.Default.DbServerName = value;
                OnPropertychanged();
            }
        }
        public string DbName
        {
            get
            {

                return Settings.Default.DbName;
            }
            set
            {
                Settings.Default.DbName = value;
                OnPropertychanged();
            }
        }
        public string DbUser
        {
            get
            {

                return Settings.Default.DbUser;
            }
            set
            {
                Settings.Default.DbUser = value;
                OnPropertychanged();
            }
        }

        public string DbPassword
        {
            get
            {

                return Settings.Default.DbPassword;
            }
            set
            {
                Settings.Default.DbPassword = value;
                OnPropertychanged();
            }
        }

        private void Confirm(object obj)
        {
            
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }
        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
