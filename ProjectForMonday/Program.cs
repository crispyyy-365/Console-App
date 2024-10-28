using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectForMonday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CourseService service = new CourseService();

            string option;
            do
            {
                Console.WriteLine("\n\n1.Create a new group\n2.Show all the groups\n3.Edit gorup\n4.Create a student\n5.Show all the students\n6.Show all the students in the group\n7.Remove Group\n8.Remove Student\n\n0.Exit\n\n");
                option = Console.ReadLine().Trim();

                switch (option)
                {
                    case "1":
                        Group group = new Group();
                        do
                        {
                            Console.WriteLine("\nEnter the number of the group : \n");
                            group._num = Convert.ToInt32(Console.ReadLine());

                            if (group._num > 99 && group._num < 1000) 
                            {
                                if (CourseService.CheckNum(group._num) == false)
                                {
                                    Console.Beep();
                                    Console.WriteLine("\nThe number is taken, please enter another number.\n");
                                }
                            }
                            else
                            {
                                Console.Beep();
                                Console.WriteLine("\nThe number is invalid, must be a three digit number.\n");
                            }
                        }
                        while (group._num < 100 || group._num > 999 || CourseService.CheckNum(group._num) == false);

                        string choice;

                        int numb;

                        do
                        {
                            Console.WriteLine("\nEnter the category of the group : \n\n1.Programming\n2.Design\n3.System Adminstration\n");

                            choice = Console.ReadLine().Trim();

                            if (int.TryParse(choice, out numb))
                            {
                                switch (numb)
                                {
                                    case (int)Category.Programming:
                                        group._category = Category.Programming;
                                        group._name = $"P-{group._num}";
                                        break;
                                    case (int)Category.Design:
                                        group._category = Category.Design;
                                        group._name = $"C-{group._num}";
                                        break;
                                    case (int)Category.SystemAdminstration:
                                        group._category = Category.SystemAdminstration;
                                        group._name = $"SA-{group._num}";
                                        break;
                                    case 0:
                                        break;
                                    default:
                                        Console.Beep();
                                        Console.WriteLine("\nInvalid option !\n");
                                        break;
                                }
                            }
                            else
                            {
                                Console.Beep();
                                Console.WriteLine("\nInvalid option !\n");
                            }
                        }
                        while (choice != "1" && choice != "2" && choice != "3");

                        string choice1;

                        do
                        {
                            Console.WriteLine("\nIs the group online ?\n\n1.Yes\n2.No\n");
                            choice1 = Console.ReadLine().Trim();

                            switch(choice1)
                            {
                                case "1":
                                    group._isOnline = true;
                                    Group._limit = 10;
                                    break;
                                case "2":
                                    group._isOnline = false;
                                    Group._limit = 15;
                                    break;
                                case "0":
                                    break;
                                default:
                                    Console.Beep() ;
                                    Console.WriteLine("\nInvalid option !\n");
                                    break;
                            }
                        }
                        while (choice1 != "1" && choice1 != "2");

                        CourseService.AddGroup(group);
                        break;
                    case "2":
                        Console.WriteLine("\nList of all the groups :\n");

                        CourseService.ShowAllGroups();
                        break;
                    case "3":

                        int changing;

                        int changed;

                        do
                        {
                            Console.WriteLine("\nEnter the number of the group :\n");
                            changing = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("\nEnter the new number : \n");
                            changed = Convert.ToInt32(Console.ReadLine());

                            if (CourseService.CheckNum(changed) == false)
                            {
                                Console.Beep();
                                Console.WriteLine("\nThe number is taken, please try another number.\n");
                            }
                            else
                            {
                                CourseService.ChangeNum(changing, changed);
                                Console.WriteLine($"\nThe number of the group is changed from {changing} to {changed}.\n");
                                break;
                            }
                        }
                        while (CourseService.CheckNum(changed) == false);
                        break;
                    case "4":
                        Student student = new Student();
                        do
                        {
                            Console.WriteLine("\nEnter the name of the student : \n");
                            student._name = Console.ReadLine().Trim();

                            if (student._name.Length < 3 || student._name.Length > 25)
                            {
                                Console.Beep();
                                Console.WriteLine("\nThe name is invalid, it should be between 3 and 25 letters.\n");
                            }
                        }
                        while (student._name.Length < 3 || student._name.Length > 25);
                        do
                        {
                            Console.WriteLine("\nEnter the Surname :\n");
                            student._surname = Console.ReadLine().Trim();

                            if (student._surname.Length < 3 || student._surname.Length > 25)
                            {
                                Console.Beep();
                                Console.WriteLine("\nThe surname is invalid, it should be between 3 and 25 letters.\n");
                            }
                        }
                        while (student._surname.Length < 3 || student._surname.Length > 25);

                        string gurantee;

                        do
                        {
                            Console.WriteLine("\nIs the student guranteed ? \n1.Yes\n2.No\n");
                            gurantee = Console.ReadLine().Trim();

                            switch (gurantee)
                            {
                                case "1":
                                    student._type = true;
                                    break;
                                case "2":
                                    student._type = false;
                                    break;
                                default:
                                    Console.Beep();
                                    Console.WriteLine("\nInvalid option.\n");
                                    break;
                            }
                        }
                        while (gurantee != "1" && gurantee != "2");
                        do
                        {
                            Console.WriteLine("\nEnter the group number :\n");
                            student._groupNo = Convert.ToInt32(Console.ReadLine());

                            if (CourseService.CheckNum(student._groupNo))
                            {
                                Console.Beep();
                                Console.WriteLine("\nGroup does not exist.\n");
                            }
                            else
                            {
                                CourseService.AddStudent(student, CourseService.FindGroup(student._groupNo));
                                student._groupName = CourseService.FindGroup(student._groupNo)._name;
                                Console.WriteLine($"\nStudent is created and added to {student._groupName} group.\n");
                            }
                        }
                        while (CourseService.CheckNum(student._groupNo));

                        CourseService.AddStudentToAll(student);
                        break;
                    case "5":
                        Console.WriteLine("\nList of all the students in the course :\n");
                        CourseService.ShowAllStudents();
                        break;
                    case "6":
                        int groupNo;
                        do
                        {
                            Console.WriteLine("\nEnter the number of the group.");
                            groupNo = Convert.ToInt32(Console.ReadLine());

                            if (CourseService.CheckNum(groupNo) == false)
                            {
                                Console.WriteLine($"\nList of the students int the {CourseService.FindGroup(groupNo)._name} group :");
                                CourseService.ShowStudents(CourseService.FindGroup(groupNo));
                            }
                            else
                            {
                                Console.WriteLine($"There is no such group with {groupNo} number.");
                            }
                        }
                        while (CourseService.CheckNum(groupNo));
                        break;
                    case "7":
                        int number;
                        do
                        {
                            Console.WriteLine("\nType the number of the group :\n");
                            number = Convert.ToInt32(Console.ReadLine());

                            if (CourseService.CheckNum(number))
                            {
                                Console.Beep();
                                Console.WriteLine("\nThe group does not exist.\n");
                            }
                            else
                            {
                                CourseService.RemoveGroup(number);
                                Console.WriteLine("\nGroup deleted.\n");
                            }
                        }
                        while (CourseService.CheckNum(number));
                        break;
                    case "8":
                        string surname;
                        do
                        {
                            Console.WriteLine("\nType the surname of the student : \n");
                            surname = Console.ReadLine().Trim();

                            if (CourseService.CheckStudent(surname))
                            {
                                CourseService.RemoveStudent(surname);
                                Console.WriteLine($"\nthe student {surname} is removed.\n");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"\nStudent with a surname {surname} doesn't exist.\n");
                            }
                        }
                        while (CourseService.CheckStudent(surname) == false);
                        break;
                    case "0":
                        break;
                    default:
                        Console.Beep();
                        Console.WriteLine("\nInvalid option !\n");
                        break;
                }
            }
            while (option != "0");
        }
    }
}