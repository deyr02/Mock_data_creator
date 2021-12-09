using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOCK_DATA_CREATOR
{
    class YearSemester
    {
        public YearSemester (int year, int semester)
        {
            Year = year;
            Semester = semester;
        }
        public int Year { get; set; }
        public int Semester { get; set; }
    }
}
