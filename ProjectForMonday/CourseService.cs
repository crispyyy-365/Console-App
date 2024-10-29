using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForMonday
{
    internal class CourseService
    {
        static Student[] allStudents = new Student[0];
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
            if (CheckNum(groupNum))
            {
                FindGroup(groupNum)._num = number;
                return FindGroup(groupNum)._num;
            }
            else
            {
                return 0;
            }
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
            if (group.students.Length < group._limit)
            {
                Array.Resize(ref group.students, group.students.Length + 1);
                group.students[group.students.Length - 1] = student;
                Console.WriteLine($"\nStudent Created and added to {group._name}.");
            }
            else
            {
                Console.Beep();
                Console.WriteLine("Group is full !");
            }
        }
        public static void AddStudentToAll(Student student)
        {
            Array.Resize(ref allStudents, allStudents.Length + 1);
            allStudents[allStudents.Length - 1] = student;
        }
        public static void ShowAllStudents()
        {
            for (int i = 0; i < allStudents.Length; i++)
            {
                Console.WriteLine($"Name : {allStudents[i]._name}, Surname : {allStudents[i]._surname}, Group name : {allStudents[i]._groupName}, Is guaranteed ? {allStudents[i]._type}.");
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

            for (int i = 0; i < allStudents.Length; i++)
            {
                if (allStudents[i]._surname != surname)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = allStudents[i];
                }
            }
            allStudents = newArr;
            return allStudents;
        }
        public static bool CheckStudent(string surname)
        {
            for (int i = 0; i < allStudents.Length; i++)
            {
                if (allStudents[i]._surname == surname)
                {
                    return true;
                }
            }
            return false;
        }
        public static Student[] RemoveStudents(int groupNum)
        {
            Student[] newArr = new Student[0];

            for (int i = 0; i < allStudents.Length; i++)
            {
                if (allStudents[i]._groupNo != groupNum)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = allStudents[i];
                }
            }
            allStudents = newArr;
            return allStudents;
        }
        public static bool CheckName(string name)
        {
            if (name.Length < 3 || name.Length > 25)
            {
                return false;
            }
            for (int i = 0; i < name.Length; i++) 
            {
                if (char.IsLetter(name[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }
        public static string Capitalise(string name)
        {
            return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
        }
    }
}