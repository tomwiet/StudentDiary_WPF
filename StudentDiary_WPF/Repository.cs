using StudentDiary_WPF.Models.Domains;
using StudentDiary_WPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudentDiary_WPF.Models.Converters;
using StudentDiary_WPF.Models;

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
                var studentToUpdate = context.Students.Find(student.Id);
                studentToUpdate.FirstName = student.FirstName;
                studentToUpdate.LastName = student.LastName;
                studentToUpdate.Activities = student.Activities;
                studentToUpdate.Comments = student.Comments;
                studentToUpdate.GroupId = student.GroupId;

                var studentsRatings = context
                    .Ratings
                    .Where(x=>x.StudentId == student.Id)
                    .ToList();

                var mathRatings = studentsRatings
                    .Where(x=>x.SubjectId == (int)Subject.Math)
                    .Select(x=>x.Rate);

                var newMathRatings = ratings
                    .Where(x=>x.SubjectId == (int)Subject.Math)
                    .Select(x=>x.Rate);

                var mathRaitingsToDelete = mathRatings.Except(newMathRatings).ToList();
                var mathRaitingsToAdd = newMathRatings.Except(mathRatings).ToList();

                mathRaitingsToDelete.ForEach(x =>
                    {
                        var ratingToDelete = context.Ratings.First(y =>
                            y.Rate == x &&
                            y.StudentId == student.Id &&
                            y.SubjectId == (int)Subject.Math);

                        context.Ratings.Remove(ratingToDelete);
                    });

                mathRaitingsToAdd.ForEach(x =>
                {
                    var ratingToAdd = new Rating
                    {
                        Rate = x,
                        StudentId = student.Id,
                        SubjectId = (int)Subject.Math
                    };

                    context.Ratings.Add(ratingToAdd);
                });
            }

        }
    }
}
