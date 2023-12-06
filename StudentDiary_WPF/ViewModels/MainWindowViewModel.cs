using StudentDiary_WPF.Commands;
using StudentDiary_WPF.Models;
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
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            RefreshStudentsCommand = new RelayCommand(RefreshStudents, canRefreshStudends);
            Students = new ObservableCollection<Student>
            { 
                new Student 
                {
                    Id=1,
                    FirstName="Jan",
                    LastName="Kowalski",
                    Group = new Group { Id = 1}
                },
                new Student
                {
                    Id=2,
                    FirstName="Piotr",
                    LastName="Nowak",
                    Group = new Group { Id = 2}
                },
                new Student
                {
                    Id=3,
                    FirstName="Adam",
                    LastName="Abacki",
                    Group = new Group { Id = 1}
                }

            };
        }
        
        public ICommand RefreshStudentsCommand { get; set; }
        
        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set 
            { 
                _selectedStudent = value;
                OnPropertychanged();
            }
        }

        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertychanged();
            }
        }



        private void RefreshStudents(object obj)
        {
         
        }
        
        private bool canRefreshStudends(object obj)
        {
            return true;
        }

        
    }
}
