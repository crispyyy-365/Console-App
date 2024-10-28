using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForMonday
{
    internal class CourseService
    {
        static Student[] students = new Student[0];
        static Group[] groups = new Group[0];
        public static void AddGroup(Group group)
        {
            Array.Resize(ref groups, groups.Length + 1);
            groups[groups.Length - 1] = group;
        }
        public static Group[] RemoveGroup(int num)
        {
            RemoveStudents(num);

            Group[] newArr = new Group[0];

            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i]._num != num)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = groups[i];
                }
            }
            groups = newArr;
            return groups;
        }
        public static void ShowAllGroups()
        {
            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine($"Group name : {groups[i]._name} Group category : {groups[i]._category} Is the group online ? {groups[i]._isOnline}");
            }
        }
        public static bool CheckNum(int num)
        {
            for (int i = 0; i < groups.Length; i++) 
            {
                if (groups[i]._num == num)
                {
                    return false;
                }
            }
            return true;
        }
        public static int ChangeNum(int groupNum, int number)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i]._num == groupNum)
                {
                    groups[i]._num = number;
                    return groups[i]._num;
                }
            }
            return 0;
        }
        public static bool CheckOnline(int num)
        {
            if (groups[num]._isOnline)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void AddStudent(Student student, Group group)
        {
            for (int i = 0; i < group.students.Length; i++) 
            {
                if (group.students[i] == null)
                {
                    group.students[i] = student;
                    break;
                }
            }
        }
        public static void AddStudentToAll(Student student)
        {
            Array.Resize(ref students, students.Length + 1);
            students[students.Length - 1] = student;
        }
        public static void ShowAllStudents()
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"Name : {students[i]._name}, Surname : {students[i]._surname}, Group name : {students[i]._groupName}, Is guaranteed ? {students[i]._type}.");
            }
        }
        public static void ShowStudents(Group group)
        {
            for (int i = 0; i < group.students.Length; i++)
            {
                Console.WriteLine($"Name : {group.students[i]._name}, Surname : {group.students[i]._surname}, Group name : {group.students[i]._groupName}, Is guaranteed ? {group.students[i]._type}.");
            }
        }
        public static Group FindGroup(int num)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i]._num == num)
                {
                    return groups[i];
                }
            }
            return null;
        }
        public static Student[] RemoveStudent(string surname)
        {
            Student[] newArr = new Student[0];

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i]._surname != surname)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = students[i];
                }
            }
            students = newArr;
            return students;
        }
        public static bool CheckStudent(string surname)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i]._surname == surname)
                {
                    return true;
                }
            }
            return false;
        }
        public static Student[] RemoveStudents(int groupNum)
        {
            Student[] newArr = new Student[0];

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i]._groupNo != groupNum)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = students[i];
                }
            }
            students = newArr;
            return students;
        }
    }
}