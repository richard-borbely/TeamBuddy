using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuddy.App.Model;

namespace TeamBuddy.App.ViewModel
{
    class UserViewModel
    {
        public ObservableCollection<Student> Students
        {
            get;
            set;
        }

        public void LoadUser()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();

            students.Add(new Student { FirstName = "Kokot" });

            Students = students;
        }
    }
}
