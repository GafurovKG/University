using System;


namespace M02_Creating_types
{
    internal class Student
    {
        private readonly string studfullName;
        private readonly string studemail;

        public Student (string Email)
        {
            studemail = Email;
            string[] emailsplit = Email.Split('.', '@');
            studfullName = emailsplit[0] + " " + emailsplit[1]; // поскать дргуой способ
            
        }
        public Student (string name, string surname)
        {
            studfullName = name + " " + surname;
            studemail = name + "." + surname + "@epam.com";
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   studemail == student.studemail;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(studemail, studfullName); // можно было и Combine, по любому полю хватило бы.
        }
        public string ShowInfo()
        {
            return studfullName + " " + this.studemail + ":";
        }
    }
}
