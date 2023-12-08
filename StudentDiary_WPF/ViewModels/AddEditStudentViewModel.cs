﻿using StudentDiary_WPF.Commands;
using StudentDiary_WPF.Models;
using StudentDiary_WPF.Models.Domains;
using StudentDiary_WPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentDiary_WPF.ViewModels
{
    internal class AddEditStudentViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();
        public AddEditStudentViewModel(StudentWrapper student = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            if (student == null) 
            {
                Student = new StudentWrapper();
            }
            else 
            { 
                Student = student;
                IsUpdate = true;
            }

            InitGroups();
        }

        

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        
        private StudentWrapper _student;
        public StudentWrapper Student
        {
            get { 
                return _student; 
            }
            set { 
                _student = value;
                OnPropertychanged();
            }
        }
        private bool _isUpdate;

        public bool IsUpdate
        {
            get { 
                return _isUpdate; 
            }
            set { 
                _isUpdate = value;
                OnPropertychanged();
            }
        }
        private int _selectedGroupId;

        public int SelectedGroupId
        {
            get
            {
                return _selectedGroupId;
            }
            set
            {
                _selectedGroupId = value;
                OnPropertychanged();
            }
        }

        private ObservableCollection<Group> _groups;

        public ObservableCollection<Group> Groups
        {
            get
            {
                return _groups;
            }
            set
            {
                _groups = value;
                OnPropertychanged();
            }
        }



        private void Confirm(object obj)
        {
           
            if (!IsUpdate)
                AddStudent();
            else
                UpdateStudent();

            CloseWindow(obj as Window);
        }

        private void UpdateStudent()
        {
            //todo: zapis danych do bazy
        }

        private void AddStudent()
        {
            //todo aktualizacja danych w bazie
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);

        }
        private void CloseWindow(Window window) 
        {
            window.Close();
        }
      
        private void InitGroups()
        {
            var groups = _repository.GetGroups();
            groups.Insert(0, new Group { Id = 0, Name = "--brak--" });

            Groups = new ObservableCollection<Group>(groups);

            Student.Group.Id = 0;

        }
    }
    

        
}
