﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using StudentDiary_WPF.Commands;
using StudentDiary_WPF.Models;
using StudentDiary_WPF.Models.Domains;
using StudentDiary_WPF.Models.Wrappers;
using StudentDiary_WPF.Properties;
using StudentDiary_WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentDiary_WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();
        
        public MainWindowViewModel()
        {

            AddStudentCommand = new RelayCommand(AddEditStudent,canAddRefreshStudent);
            EditStudentCommand = new RelayCommand(AddEditStudent, canEditDeleteStudent);
            DeleteStudentCommand = new AsyncRelayCommand(DeleteStudent, canEditDeleteStudent);
            RefreshStudentsCommand = new RelayCommand(RefreshStudents,canAddRefreshStudent);
            EditSettingsCommand = new RelayCommand(EditUserSettings);
            
            var conn = SqlHelper.IsServerConnected();

            if (conn.isConnected)
            {
                RefreshDiary();
                InitGroups();
            }
            
            ConnectionErrorText = SqlHelper.ConnectionErrorMessage;
        }

        public ICommand AddStudentCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }
        public ICommand RefreshStudentsCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand EditSettingsCommand { get; set; }

        private StudentWrapper _selectedStudent;
        public StudentWrapper SelectedStudent
        {
            get { return _selectedStudent; }
            set 
            { 
                _selectedStudent = value;
                OnPropertychanged();
            }
        }

        private ObservableCollection<StudentWrapper> _students;
        public ObservableCollection<StudentWrapper> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertychanged();
            }
        }

        private int _selectedGroupId;
        public int SelectedGroupId
        {
            get { 
                return _selectedGroupId; 
            }
            set { 
                _selectedGroupId = value;
                OnPropertychanged();
            }
        }

        private ObservableCollection<Group> _groups;
        public ObservableCollection<Group> Groups
        {
            get { 
                return _groups; 
            }
            set { 
                _groups = value;
                OnPropertychanged();
            }
        }

        private bool _isGroupEmpty;
        public bool IsGroupEmpty
        {
            get { return _isGroupEmpty; }
            set 
            { 
                _isGroupEmpty = !value;
                OnPropertychanged();
            }
        }
        private string _connectionErrorText;

        public string ConnectionErrorText
        {
            get 
            { 
                return _connectionErrorText; 
            }
            set 
            { 
                _connectionErrorText = value;
                OnPropertychanged();
            }
        }

        private void RefreshDiary()
        {
            Students = new ObservableCollection<StudentWrapper>(
                _repository.GetStudents(SelectedGroupId));
            
        }
        private void InitGroups()
        {
            IsGroupEmpty = false;
            var groups = _repository.GetGroups();
            groups.Insert(0,new Group{Id=0,Name="Wszyscy"});

            Groups = new ObservableCollection<Group>(groups); 
            
            SelectedGroupId = 0;
            
        }
        private void AddEditStudent(object obj)
        {
            var addEditStudentWindow = new AddEditStudentView(obj as StudentWrapper);
            addEditStudentWindow.Closed += AddEditStudentWindow_Closed;
            addEditStudentWindow.ShowDialog();
        }
        private void AddEditStudentWindow_Closed(object sender, EventArgs e)
        {
            RefreshDiary();
        }
        private async Task DeleteStudent(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync(
                                                            "Usuwanie ucznia",
                                                            $"Czy chcesz usunąc ucznia " +
                                                            $"{SelectedStudent.FirstName} " +
                                                            $"{SelectedStudent.LastName}?",
                                                            MessageDialogStyle.AffirmativeAndNegative);
            if (dialog != MessageDialogResult.Affirmative)
                return;

            _repository.DeleteStudent(_selectedStudent.Id);

            RefreshDiary();

        }
        private void RefreshStudents(object obj)
        {
            RefreshDiary();
            if (Groups == null)
                InitGroups();
        }
        private bool canEditDeleteStudent(object obj)
        {
            return SelectedStudent != null;
        }
        private bool canAddRefreshStudent(object obj)
        {
            var conn = SqlHelper.IsServerConnected();
            return conn.isConnected;
        }
        private void EditUserSettings(object obj)
        {
            var editUserSettingsWindow = new UserSettingsView();
            editUserSettingsWindow.Closed += EdidtUserSettingsWindow_Closed;
            editUserSettingsWindow.ShowDialog();

            editUserSettingsWindow.Closed -= EdidtUserSettingsWindow_Closed;
        }
        private void EdidtUserSettingsWindow_Closed(object sender, EventArgs e)
        {
                var conn = SqlHelper.IsServerConnected();
                if (!conn.isConnected)
                {
                    Students = null;
                    IsGroupEmpty = true;
                }
                else
                {
                     IsGroupEmpty = false;
                     RefreshDiary();
                     InitGroups();
                }
                ConnectionErrorText = SqlHelper.ConnectionErrorMessage;
               
        }
    }
}
