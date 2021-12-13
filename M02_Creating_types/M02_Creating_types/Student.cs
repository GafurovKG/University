using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M02_Creating_types
{
    internal class Student
    {
        private string fullName;
        private string email;

        public Student (string email)
        {
            this.email = email;
            string[] emailsplit = email.Split('.', '@');
            this.fullName = emailsplit[0] + " " + emailsplit[1]; // поскать дргуой способ
            
        }
        public Student (string name, string surname)
        {
            this.fullName = name + " " + surname;
            this.email = name + "." + surname + "@epam.com";
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   email == student.email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(email, fullName); // можно было и Combine, по любому полю хватило бы.
        }
        public string ShowInfo()
        {
            return this.fullName + " " + this.email + ":";
        }
    }
}
