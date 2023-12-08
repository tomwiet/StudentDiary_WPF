﻿using MahApps.Metro.Controls;
using StudentDiary_WPF.Models;
using StudentDiary_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentDiary_WPF.Views
{
    /// <summary>
    /// Interaction logic for UserSettingsView.xaml
    /// </summary>
    public partial class UserSettingsView : MetroWindow
    {
        public UserSettingsView(UserSettings userSettings)
        {
            InitializeComponent();
            DataContext = new UserSettingsViewModel(userSettings);
        }
    }
}
