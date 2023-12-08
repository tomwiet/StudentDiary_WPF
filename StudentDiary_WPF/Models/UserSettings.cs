using StudentDiary_WPF.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDiary_WPF.Models
{
    public class UserSettings
    {
        public string DbServerAddress
        {
            get
            {
                return Settings.Default.DbServerAddress;
            }
            
            set
            {
                Settings.Default.DbServerAddress = value;
            }
        }
        public string DbServerName
        {
            get { return Settings.Default.DbServerName; }
            set { Settings.Default.DbServerName = value; }
        }
    }
}
