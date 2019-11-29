using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace ReflectionStudent
{
    class Program
    {
        public static Assembly DLL = Assembly.LoadFile(@"C:\Users\umerh\source\repos\StudentProject\StudentProject\bin\Debug\StudentProject.dll");
        public static Type myType = DLL.GetType("StudentProject.Student");

        static void Main(string[] args)
        {
            // var DLL = System.Configuration.ConfigurationManager.AppSettings["Path"].ToString();


            Console.WriteLine("");
            Console.WriteLine("");
            // Printing All Student Methods
            GetAllMethod();
            Console.WriteLine("");
            Console.WriteLine("");

            // Printing All Student Non Public Methods
            MethodInfo[] info2 = myType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Non Public Methods of current type is as Follow: ");
            Console.WriteLine("");
            // Printing All Student Methods
            for (int i = 0; i < info2.Length; i++)
                Console.WriteLine(" {0}", info2[i]);

            Console.WriteLine("");

            // Printing All Student Methods Details Using GetFields
            FieldInfo[] myFieldInfo2;
            myFieldInfo2 = myType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            Console.WriteLine("The fields of FieldInfoClass are :");
            for (int i = 0; i < myFieldInfo2.Length; i++)
            {
                Console.WriteLine("Name            : "+  myFieldInfo2[i].Name + "\n" +
                                "Declaring Type  : " +  myFieldInfo2[i].DeclaringType + "\n" +
                                "IsPublic        : " + myFieldInfo2[i].IsPublic + "\n" +
                                "MemberType      : " + myFieldInfo2[i].MemberType + "\n" +
                                "FieldType       : " + myFieldInfo2[i].FieldType + "\n" +
                                "IsFamily        : " + myFieldInfo2[i].IsFamily + "\n");
            }

            Console.WriteLine("");
            Console.WriteLine("");

            // Printing All Student Properties
            PropertyInfo[] myPropertyInfo;
            myPropertyInfo = myType.GetProperties();
            Console.WriteLine("Following are the Public Properties of Student");
            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                Console.WriteLine(myPropertyInfo[i].ToString());
            }

            // Now creating instances using reflections
            //Assembly assembly = Assembly.LoadFrom(@"C:\Users\umerh\source\repos\StudentProject\StudentProject\bin\Debug\StudentProject.dll");
            //foreach (Type ti in assembly.GetTypes().Where(x => x.IsClass))
            //{
            //    if (ti.Name == "Student")
            //    {
            //        Console.WriteLine(ti);
            //        ti.GetMethod("set_Name");
            //    }
            //
            //}

            // having myType in the start of the program
            //ConstructorInfo ctor = myType.GetConstructor(new[] { typeof(string), typeof(string), typeof(string)});
            //object instance = ctor.Invoke(new object[] { "Reflection", "Nice", "Thing" });

            try
            {
                object MyInstantiatedStudentObject = CallConstructorWithInstance();
                Console.WriteLine("Do you want to create an object of the class? Yes/No.");
                string Answer = Console.ReadLine();
                if (Answer == "y" || Answer.ToLower() == "yes")
                {
                    try
                    {
                        while (true)
                        {
                            Console.WriteLine("1) All methods of Student?.");
                            Console.WriteLine("2) All methods of Student(Only Name)?.");
                            Console.WriteLine("3) All methods of Student?(With Attributes).");
                            Console.WriteLine("4) Call Default Constructor (Student) With Instance?.");
                            Console.WriteLine("5) Call Default Constructor (Student) Without Instance?.");
                            Console.WriteLine("6) Call Parametrized Constructor (Student) With Instance?.");
                            Console.WriteLine("7) Call Parametrized Constructor (Student) Without Instance?.");
                            Console.WriteLine("8) Get Name.");
                            Console.WriteLine("9) Get University.");
                            Console.WriteLine("10) Get RollNumber");
                            Console.WriteLine("11) Get GPA (This will show error because it is private in Student class)");
                            Console.WriteLine("12) Exit");

                            //MyInstantiatedStudentObject
                            int intTemp = Convert.ToInt32(Console.ReadLine());
                            if (intTemp == 1)
                            {
                                GetAllMethod();
                            }
                            else if (intTemp == 2)
                            {
                                GetAllMethodName();
                            }
                            else if (intTemp == 3)
                            {
                                GetAllMethodNameWithParams();
                            }
                            else if (intTemp == 4)
                            {
                                MyInstantiatedStudentObject = CallConstructorWithInstance();
                            }
                            else if (intTemp == 5)
                            {
                                CallConstructorWithoutInstance();
                            }
                            else if (intTemp == 6)
                            {
                                Console.WriteLine("=======================================");
                                Console.WriteLine("Please Enter the details of the student");
                                Console.WriteLine("=======================================");

                                Console.WriteLine("Enter the name of student : ");
                                string Name = Console.ReadLine();
                                Console.WriteLine("Enter the University of student : ");
                                string University = Console.ReadLine();
                                Console.WriteLine("Enter the Roll Number of student : ");
                                string RollNo = Console.ReadLine();
                                Console.WriteLine("Enter the GPA of student : ");
                                string GPA = Console.ReadLine();
                                Console.WriteLine("");
                                Console.WriteLine("");
                                MyInstantiatedStudentObject = CallConstructorWithInstance(Name, University, RollNo, GPA);
                            }
                            else if (intTemp == 7)
                            {
                                Console.WriteLine("=======================================");
                                Console.WriteLine("Please Enter the details of the student");
                                Console.WriteLine("=======================================");

                                Console.WriteLine("Enter the name of student : ");
                                string Name = Console.ReadLine();
                                Console.WriteLine("Enter the University of student : ");
                                string University = Console.ReadLine();
                                Console.WriteLine("Enter the Roll Number of student : ");
                                string RollNo = Console.ReadLine();
                                Console.WriteLine("Enter the GPA of student : ");
                                string GPA = Console.ReadLine();
                                Console.WriteLine("");
                                Console.WriteLine("");

                                CallConstructorWithoutInstance(Name, University, RollNo, GPA);
                            }
                            else if (intTemp == 8)
                            {
                                MethodInfo method2 = myType.GetMethod("get_Name");
                                Console.WriteLine("Answer = " + method2.Invoke(MyInstantiatedStudentObject, new object[] { }));
                            }
                            else if (intTemp == 9)
                            {
                                MethodInfo method2 = myType.GetMethod("get_University");
                                Console.WriteLine("Answer = " + method2.Invoke(MyInstantiatedStudentObject, new object[] { }));
                            }
                            else if (intTemp == 10)
                            {
                                MethodInfo method2 = myType.GetMethod("get_RollNo");
                                Console.WriteLine("Answer = " + method2.Invoke(MyInstantiatedStudentObject, new object[] { }));
                            }
                            else if (intTemp == 11)
                            {
                                MethodInfo method2 = myType.GetMethod("get_GPA");
                                Console.WriteLine("Answer = " + method2.Invoke(MyInstantiatedStudentObject, new object[] { }));
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception" + ex);
                    }
                }
                else
                {
                    Console.WriteLine("Thank you :)");
                    Console.WriteLine("");
                }
                /***
                 * 
                    object instantiatedType = CallConstructorWithInstance("Umer", "FAST", "2.54", "k163893");
                    MethodInfo method2 = myType.GetMethod("InputStudentDetails");
                    method2.Invoke(instantiatedType, new object[] { });

                    MethodInfo method = myType.GetMethod("PrintStudent");
                    method.Invoke(instantiatedType, new object[] { });

                    GetAllMethodNameWithParams();
                 ***/
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't Create Assembly Instance" + e);
            }
            Console.ReadLine();
        }
        public static void GetAllMethod()
        {
            MethodInfo[] info1 = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("Public Methods of current type is as Follow: ");
            Console.WriteLine("");
            for (int i = 0; i < info1.Length; i++)
                Console.WriteLine(" {0}", info1[i]);
        }
        public static void GetAllMethodName()
        {
            MethodInfo[] info1 = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("Public Methods of current type is as Follow: ");
            Console.WriteLine("");
            for (int i = 0; i < info1.Length; i++)
                Console.WriteLine("{1})  {0}", info1[i].Name, i);
        }
        public static void GetAllMethodNameWithParams()
        {
            MethodInfo[] info1 = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("Public Methods of current type is as Follow: ");
            Console.WriteLine("");
            for (int i = 0; i < info1.Length; i++)
                Console.WriteLine("{0})  {1} ->  {2}", i+1, info1[i].Name, info1[i].Attributes);
        }
        public static void CallConstructorWithoutInstance()
        {
            Type[] stringArgumentTypes = new Type[] {};
            ConstructorInfo stringConstructor = myType.GetConstructor(stringArgumentTypes);
            object newStringCustomer = stringConstructor.Invoke(new object[] { });
        }
        public static void CallConstructorWithoutInstance(string myName, string myUniversity, string myGPA, string myRollNo)
        {
            Type[] stringArgumentTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            ConstructorInfo stringConstructor = myType.GetConstructor(stringArgumentTypes);
            object newStringCustomer = stringConstructor.Invoke(new object[] { myName, myUniversity, myGPA, myRollNo });
        }
        public static object CallConstructorWithInstance()
        {
            object instantiatedType = Activator.CreateInstance(myType,
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Instance,
                null, new object[] { }, null);
            return instantiatedType;
        }
        public static object CallConstructorWithInstance(string myName, string myUniversity, string myGPA, string myRollNo)
        {
            object instantiatedType = Activator.CreateInstance(myType,
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Instance,
                null, new object[] { myName, myUniversity, myGPA, myRollNo }, null);
            return instantiatedType;
        }
    }
}
