﻿using StudentDiary_WPF.Models.Domains;
using StudentDiary_WPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudentDiary_WPF.Models.Converters;
using StudentDiary_WPF.Models;
using System.Runtime.Remoting.Contexts;

namespace StudentDiary_WPF
{
    public class Repository
    {
        public List<Group> GetGroups() 
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Groups.ToList();
            }
        }

        public List<StudentWrapper> GetStudents(int groupId)
        {
            using (var context = new ApplicationDbContext()) 
            {
                var students = context
                    .Students
                    .Include(x => x.Group)
                    .Include(x=>x.Ratings)
                    .AsQueryable();

                if (groupId !=0) 
                    students = students.Where(x => x.GroupId == groupId);

                return students
                    .ToList()
                    .Select(x=>x.ToWrapper())
                    .ToList();
            }
        }
        
        public void AddStudent(StudentWrapper studentWrapper)
        {
            var student = studentWrapper.ToDao();
            var ratings = studentWrapper.ToRatingDao();

            using(var context = new ApplicationDbContext())
            {
                var dbSudent = context.Students.Add(student);
                ratings.ForEach(x =>
                {
                    x.StudentId = dbSudent.Id;
                    context.Ratings.Add(x);
                });
                
                context.SaveChanges();

                    
            }
        }

        public void DeleteStudent(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var studentToDelete = context.Students.Find(id);
                context.Students.Remove(studentToDelete);
                context.SaveChanges();
            }
        }
        public void UpdateStudent(StudentWrapper studentWrapper)
        {
            var student = studentWrapper.ToDao();
            var ratings = studentWrapper.ToRatingDao();

            using (var context = new ApplicationDbContext())
            {
                UpdateStudentProperties(context,student);

                var studentsRatings = GetStudentsRatings(context, student);

                UpdateRate(student,ratings,context,studentsRatings,
                    Subject.Math);
                UpdateRate(student,ratings,context,studentsRatings,
                    Subject.Physics);
                UpdateRate(student,ratings,context,studentsRatings,
                    Subject.Technology);
                UpdateRate(student,ratings,context,studentsRatings,
                    Subject.PolishLang);
                UpdateRate(student,ratings,context,studentsRatings,
                    Subject.ForeignLang);

                context.SaveChanges();

            }
        }
        private static List<Rating> GetStudentsRatings(ApplicationDbContext context, Student student)
        {
            return  context
                    .Ratings
                    .Where(x => x.StudentId == student.Id)
                    .ToList();
        }
        private static void UpdateStudentProperties(ApplicationDbContext context,Student student)
        {
            var studentToUpdate = context.Students.Find(student.Id);
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.Activities = student.Activities;
            studentToUpdate.Comments = student.Comments;
            studentToUpdate.GroupId = student.GroupId;
        }
        private static void UpdateRate(Student student,List<Rating> newRatings,
            ApplicationDbContext context,List<Rating> studentsRatings,Subject subject)
        {
            var subRatings = studentsRatings
                .Where(x => x.SubjectId == (int)subject)
                .Select(x => x.Rate);

            var newSubRatings = newRatings
                .Where(x => x.SubjectId == (int)subject)
                .Select(x => x.Rate);

            var subRaitingsToDelete = subRatings.Except(newSubRatings).ToList();
            var subRaitingsToAdd = newSubRatings.Except(subRatings).ToList();

            subRaitingsToDelete.ForEach(x =>
            {
                var ratingToDelete = context.Ratings.First(y =>
                    y.Rate == x &&
                    y.StudentId == student.Id &&
                    y.SubjectId == (int)subject);

                context.Ratings.Remove(ratingToDelete);
            });

            subRaitingsToAdd.ForEach(x =>
            {
                var ratingToAdd = new Rating
                {
                    Rate = x,
                    StudentId = student.Id,
                    SubjectId = (int)subject
                };

                context.Ratings.Add(ratingToAdd);
            });

        }
       
    }
}
