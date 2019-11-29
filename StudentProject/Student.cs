using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject
{
    class Student
    {
        public Student()
        {
            this.Name = "";
            this.University = "";
            this.GPA = "";
            this.RollNo = "";
            Console.WriteLine("");
            Console.WriteLine("Without Parameters Constructor Called");
            Console.WriteLine(GetStudentDetails(this));
            Console.WriteLine("");
        }
        public Student(string myName, string myUniversity, string myGPA, string myRollNo)
        {
            this.Name = myName;
            this.University = myUniversity;
            this.GPA = myGPA;
            this.RollNo = myRollNo;
            Console.WriteLine("");
            Console.WriteLine("Parameters Constructor Called");
            Console.WriteLine(GetStudentDetails(this));
            Console.WriteLine("");
        }
        public string Name
        {
            set;
            get;
        }
        public string University
        {
            set;
            get;
        }
        public string RollNo
        {
            set;
            get;
        }
        protected string GPA
        {
            set;
            get;
        }
        protected void increaseGPA(int num)
        {
            IncreaseGPAby(this, num);
        }
        protected void SampleFunction(int num, int num2, int num3, int num4)
        {
            Console.WriteLine("I am sample Function");
        }
        private static void IncreaseGPAby(Student myStudent, int increase)
        {
            myStudent.GPA = myStudent.GPA + increase;
        }

        public static string GetStudentDetails(Student myobj)
        {
            return "Name : " + myobj.Name + "\n" +
                "University : " + myobj.University + "\n" +
                "RollNo : " + myobj.RollNo + "\n" +
                "GPA : " + myobj.GPA + "\n";

        }
        public string GetStudent()
        {
            return "Name : " + this.Name + "\n" +
                    "University : " + this.University + "\n" +
                    "RollNo : " + this.RollNo + "\n" +
                    "GPA : " + this.GPA + "\n";

        }
        public void PrintStudent()
        {
             Console.WriteLine(
                "Name : " + this.Name + "\n" +
                "University : " + this.University + "\n" +
                "RollNo : " + this.RollNo + "\n" +
                "GPA : " + this.GPA + "\n");
        }

        public void InputStudentDetails()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("Please Enter the details of the student");
            Console.WriteLine("=======================================");

            Console.WriteLine("Enter the name of student : ");
            this.Name = Console.ReadLine();
            Console.WriteLine("Enter the University of student : ");
            this.University = Console.ReadLine();
            Console.WriteLine("Enter the Roll Number of student : ");
            this.RollNo = Console.ReadLine();
            Console.WriteLine("Enter the GPA of student : ");
            this.GPA = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("");
        }
        static void Main() // static with a void (or int) return type
        {
            Console.WriteLine("Hello World");
            Console.ReadKey();
        }

    }
}
