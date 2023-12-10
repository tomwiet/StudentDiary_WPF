using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using StudentDiary_WPF.Commands;
using StudentDiary_WPF.Models;
using StudentDiary_WPF.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
//Server=(local)\SQLEXPRESS;Database=StudentDiary;User Id=DiaryUser;Password=Diary;
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

        public string ConnetionString 
        { 
            get 
            {
                return Settings.Default.ConnetionString;
            }
            set
            {
                Settings.Default.ConnetionString = value;
                OnPropertychanged();
            }
        }

        private void Confirm(object obj)
        {
            ConnetionString = SetConnectionString();
            Settings.Default.Save();
            CloseWindow(obj as Window);


            var metroWindow = Application.Current.MainWindow as MetroWindow;
            metroWindow.ShowMessageAsync("Info",ConnetionString,MessageDialogStyle.Affirmative);

            
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }
        private void CloseWindow(Window window)
        {
            window.Close();
        }

        public string SetConnectionString()
        {
            //Server=(local)\SQLEXPRESS;Database=StudentDiary;User Id=DiaryUser;Password=Diary;
            var cs = 
                $"Server={DbServerAddress}\\{DbServerName};" +
                $"Database={DbName};" +
                $"User Id={DbUser};" +
                $"Password={DbPassword};";

            return cs;
        }
    }
}
