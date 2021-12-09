using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOCK_DATA_CREATOR
{
    class COURSE_CLASS
    {
        public COURSE_CLASS(string classID, string startdate, string finishDate, int Year, int semester, string CourseID)
        {
            this.COURSE_CLASSID = classID;
            this.START_DATE = startdate;
            this.FINISH_DATE = finishDate;
            this.YEAR = Year;
            this.SEMESTER_TYPEID = semester;
            this.COURSEID = CourseID;
        }
        public string COURSE_CLASSID { get; set; }

  
        public string START_DATE { get; set; }


        public string FINISH_DATE { get; set; }

        public int YEAR { get; set; }


        public int SEMESTER_TYPEID { get; set; }
        public string COURSEID { get; set; }

        public string output()
        {
            string result = "";
            result = " new COURSE_CLASS {COURSE_CLASSID = " + '"' + COURSE_CLASSID + '"';
            result += ',' + "COURSEID = " + '"' + COURSEID + '"';
            result += ',' + "SEMESTER_TYPEID = " + SEMESTER_TYPEID;
            result += ',' + "YEAR = " + YEAR;

            result += ',' + "FINISH_DATE = " + "Convert.ToDateTime(" +'"' + FINISH_DATE+ '"'+")";
            result += ',' + "START_DATE = " + "Convert.ToDateTime(" +'"'+START_DATE+'"'+")";
            result += "}" + ',' + "\n";

            return result;

        }

    }
}
