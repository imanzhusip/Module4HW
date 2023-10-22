using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class Students
    {
        public string FullName { get; set; }
        public string GroupNumber { get; set; }
        public int[] Grades { get; set; }

        public double GetAverageGrade()
        {
            return Grades.Average();
        }

    }
}