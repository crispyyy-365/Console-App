using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForMonday
{
    internal class Group
    {
        public int _num { get; set; }
        public Category _category { get; set; }
        public string _name { get; set; }
        public bool _isOnline { get; set; }
        public static int _limit { get; set; }

        public Student[] students = new Student[_limit];
    }
}
