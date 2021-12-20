using System;


namespace M02_Creating_types
{
    internal class Student
    {
        public string FullName { get; }
        public string Email { get; }

        public Student (string StudEmail)
        {
            Email = StudEmail;
            string[] emailsplit = StudEmail.Split('.', '@');
            FullName = emailsplit[0] + " " + emailsplit[1]; // поскать дргуой способ
            
        }
        public Student (string name, string surname)
        {
            FullName = name + " " + surname;
            Email = name + "." + surname + "@epam.com";
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Email == student.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email, FullName); // можно было и Combine, по любому полю хватило бы.
        }
        public string ShowInfo()
        {
            return FullName + " " + Email + ":";
        }
    }
}
