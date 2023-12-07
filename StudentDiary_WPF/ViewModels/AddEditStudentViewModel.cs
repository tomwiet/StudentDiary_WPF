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
    internal class AddEditStudentViewModel : ViewModelBase
    {
        public AddEditStudentViewModel(Student student = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            throw new Exception("A to się narobiło");

            if (student == null) 
            {
                Student = new Student();
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
        
        private Student _student;
        public Student Student
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
            Groups = new ObservableCollection<Group>
            {
                new Group {Id=0,Name="--brak--"},
                new Group {Id=1,Name="1A"},
                new Group {Id=2,Name="1B"},
                new Group {Id=3,Name="1C"},

            };

            Student.Group.Id = 0;

        }
    }
    

        
}
