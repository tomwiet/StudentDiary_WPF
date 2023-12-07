using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using StudentDiary_WPF.Commands;
using StudentDiary_WPF.Models;
using StudentDiary_WPF.Models.Wrappers;
using StudentDiary_WPF.Views;
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
  
            AddStudentCommand = new RelayCommand(AddEditStudent);
            EditStudentCommand = new RelayCommand(AddEditStudent, canEditDeleteStudent);
            DeleteStudentCommand = new AsyncRelayCommand(DeleteStudent, canEditDeleteStudent);
            RefreshStudentsCommand = new RelayCommand(RefreshStudents);

            RefreshDiary();
            InitGroups();
        }


        public ICommand AddStudentCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }
        public ICommand RefreshStudentsCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        
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

        private ObservableCollection<GroupWrapper> _groups;

        public ObservableCollection<GroupWrapper> Groups
        {
            get { 
                return _groups; 
            }
            set { 
                _groups = value;
                OnPropertychanged();
            }
        }


        private void RefreshStudents(object obj)
        {
            RefreshDiary();
        }
        
        private void RefreshDiary()
        {
            Students = new ObservableCollection<StudentWrapper>
            {
                new StudentWrapper
                {
                    Id=1,
                    FirstName="Jan",
                    LastName="Kowalski",
                    Group = new GroupWrapper { Id = 1}
                },
                new StudentWrapper
                {
                    Id=2,
                    FirstName="Piotr",
                    LastName="Nowak",
                    Group = new GroupWrapper { Id = 2}
                },
                new StudentWrapper
                {
                    Id=3,
                    FirstName="Adam",
                    LastName="Abacki",
                    Group = new GroupWrapper { Id = 1}
                }

            };
        }
        private void InitGroups()
        {
            Groups = new ObservableCollection<GroupWrapper> 
            {
                new GroupWrapper {Id=0,Name="Wszyscy"},
                new GroupWrapper {Id=1,Name="1A"},
                new GroupWrapper {Id=2,Name="1B"},
                new GroupWrapper {Id=3,Name="1C"},
            
            };

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

            //todo: usuwanie ucznia z bazy

            RefreshDiary();

        }

        private bool canEditDeleteStudent(object obj)
        {
            return SelectedStudent != null;
        }

        

        

    }
}
