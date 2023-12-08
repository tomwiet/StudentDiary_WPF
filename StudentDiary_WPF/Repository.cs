using StudentDiary_WPF.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
