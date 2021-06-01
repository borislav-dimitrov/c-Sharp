using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentsExercise
{
    class Program
    {

        static void Main(string[] args)
        {
            // create an empty list to store all of the students
            List<Student> allStudents = new List<Student>();

            // loop so it feels more like a real program
            while (true)
            {
                // preview the available operations to the user
                Console.WriteLine("1. View info for all students");
                Console.WriteLine("2. View info for particular student");
                Console.WriteLine("3. Add new Student.\n");

                // get user input for desired operation and check his input
                int userInput = CheckOperation();

                // if user input is valid execute desired operation
                DoOperation(userInput, allStudents);
            }
        }

        #region CheckUserInput

        // check if user input meet our conditions via Regex
        //
        // Regex() is a method that can check if string contains only
        // our desired symbols, characters, numbers, etc..
        //
        // check user input for student name
        private static string CheckName()
        {
            string checkedName = "";
            
            // check if user input consists only from letters a-z or A-Z
            var regexCheck = new Regex("^[a-zA-Z]*$");

            while (true)
            {
                string name = Console.ReadLine();

                // check if user input meets our conditions and it is not empty
                if (regexCheck.IsMatch(name) && name.Length > 0)
                {
                    checkedName = name;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid name, try again !");
                }
            }

            return checkedName;
        }

        // check user input for student surname
        private static string CheckSurName()
        {
            string checkedSurName = "";
            var regexCheck = new Regex("^[a-zA-Z]*$");

            while (true)
            {
                string surName = Console.ReadLine();

                // check if user input meets our conditions and it is not empty
                if (regexCheck.IsMatch(surName) && surName.Length > 0)
                {
                    checkedSurName = surName;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid surname, try again !");
                }
            }

            return checkedSurName;
        }

        // check user input for student age
        private static int CheckAge()
        {
            int checkedAge = 0;

            // check if input consists only from numbers
            var regexCheck = new Regex("^[0-9]*$");

            while (true)
            {
                string age = Console.ReadLine();

                // check if user input meets our conditions
                if (regexCheck.IsMatch(age))
                {
                    // if input is numeric check if it is between our desired values
                    if(Convert.ToInt32(age) >= 13 && Convert.ToInt32(age) <= 18)
                    {
                        checkedAge = Convert.ToInt32(age);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Student should be atleast 13 and at most 18, try again !");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid age, try again !");
                }
            }

            return checkedAge;
        }

        // check user input for student speciallity
        private static string CheckSpeciallity()
        {
            string checkedSpeciallity = "";
            var regexCheck = new Regex("^[a-zA-Z]*$");

            while (true)
            {
                string speciallity = Console.ReadLine();

                // check if user input meets our conditions and it is not empty
                if (regexCheck.IsMatch(speciallity) && speciallity.Length > 0)
                {
                    checkedSpeciallity = speciallity;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid speciallity, try again !");
                }
            }

            return checkedSpeciallity;
        }

        // check user input for student grade
        private static int CheckGrade()
        {
            int checkedGrade = 0;
            var regexCheck = new Regex("^[0-9]*$");

            while (true)
            {
                string grade = Console.ReadLine();

                // check if user input meets our conditions
                if (regexCheck.IsMatch(grade))
                {
                    // if input is numeric check if it is between our desired values
                    if (Convert.ToInt32(grade) >= 7 && Convert.ToInt32(grade) <= 12)
                    {
                        checkedGrade = Convert.ToInt32(grade);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Grade should be atleast 7 and at most 12, try again !");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid grade, try again !");
                }
            }

            return checkedGrade;
        }

        // check user input for student gpu
        private static float CheckGpu()
        {
            float checkedGpu = 0;

            // this time we want the input to also have "." in it so we can convert to float
            var regexCheck = new Regex(@"^[0-9\.]*$");

            while (true)
            {
                string gpu = Console.ReadLine();
                // check if user input meets our conditions and it is not empty
                if (regexCheck.IsMatch(gpu))
                {
                    // if input is numeric check if it is between our desired values
                    if (float.Parse(gpu) >= 2f && float.Parse(gpu) <= 6f)
                    {
                        checkedGpu = float.Parse(gpu);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Valid gpu's are between 2 and 6, try again !");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid gpu, try again !");
                }
            }

            return checkedGpu;
        }

        // check user input for operation
        private static int CheckOperation()
        {
            int checkedOperationNum = 0;
            
            // filter the input to be valid only if its 1 2 or 3
            var regexCheck = new Regex("^[1-3]*$");

            while (true)
            {
                string operationNum = Console.ReadLine();

                // regex = if input is between the numbers in the Regex() method (also this is our opeartions that we show on the main screen) then it's valid
                if (regexCheck.IsMatch(operationNum))
                {
                    checkedOperationNum = Convert.ToInt32(operationNum);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid operation, try again !");
                }
            }

            return checkedOperationNum;
        }
        #endregion

        #region DoOperation

        private static void DoOperation(int chosenOperation, List<Student> students)
        {
            // do the desired operation based on the user input
            if(chosenOperation == 1)
            {
                PreviewAllStudentsInfo(students);
            }
            else if (chosenOperation == 2)
            {
                ViewInfoForStudentName(students);
            }
            else if (chosenOperation == 3)
            {
                CreateNewStudent(students);
            }
            
        }
        #endregion

        #region Operations

        private static void PreviewAllStudentsInfo(List<Student> students)
        {
            // clear the console for the user
            Console.Clear();

            // check if there are any students in the DB
            if (students.Count > 0)
            {
                // iterate over each existing student
                foreach (Student student in students)
                {
                    // call method from the Student class
                    student.PrintStudentInfo();
                    Console.WriteLine("\n\n");
                }
            }
            else
            {
                Console.WriteLine("\nThere are no students yet !\n");
            }
        }

        private static void CreateNewStudent(List<Student> students)
        {
            // clear the console for the user
            Console.Clear();

            // get user input and check if it meets our conditions then if it does store it in a variable
            Console.WriteLine("Input name for student: ");
            string name = CheckName();

            Console.WriteLine("Input surname for student: ");
            string surName = CheckSurName();

            Console.WriteLine("Input age for student: ");
            int age = CheckAge();

            Console.WriteLine("Input speciallity for student: ");
            string speciallity = CheckSpeciallity();

            Console.WriteLine("Input grade for student: ");
            int grade = CheckGrade();

            Console.WriteLine("Input average GPU for student: ");
            float averageGpu = CheckGpu();

            // with already confirmed inputs create new object from the Student class
            Student student = new Student(name, surName, age, speciallity, grade, averageGpu);
            students.Add(student);
            Console.Clear();
        }

        private static void ViewInfoForStudentName(List<Student> students)
        {
            // clear the console for the user
            Console.Clear();

            // get the user input for the desired student names
            Console.WriteLine("Input name of student to look for: ");
            string studentName = Console.ReadLine();

            Console.WriteLine("Input surname of student to look for: ");
            string studentSurName = Console.ReadLine();

            // iterate over all existing students
            foreach (Student student in students)
            {
                // if current student name + surname is equal to the user input name + surname
                if (student._name + " " + student._surName == studentName + " " + studentSurName)
                {
                    // print student info
                    student.PrintStudentInfo();
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.WriteLine("There is no such student !\n\n");
                }
            }
        }
        #endregion
    }
}
