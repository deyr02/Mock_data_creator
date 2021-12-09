using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;

namespace MOCK_DATA_CREATOR
{
    class Program
    {
        
        private ArrayList ReadFile (TextFieldParser filePath)
        {
            ArrayList Result = new ArrayList();
            using (TextFieldParser parser = filePath)
            {
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string data = parser.ReadLine();
                    Result.Add(data);
                  //  Console.WriteLine(data);
                }
            }
            return Result;
        }

        private string selectedClass (int year, int semester, string COUSEID)
        {
            string Resutl = "";
            ArrayList AllClass = this.ReadFile(new TextFieldParser(@"D:\Capstone Project\MOCK DATA\COURSE_CLASS\COURSE_CLASS_TABLE.csv"));
            for(int i =0; i< AllClass.Count; i++)
            {
                string[] data = AllClass[i].ToString().Split(',');

                if((data[1] == COUSEID) && (data[5] == year.ToString()) && (data[3]== semester.ToString()))
                {
                    Resutl = data[0];
                    break;
                }
            }
            return Resutl;
        }

        public string Invoice_output(Double Cost, int supplierID, DateTime Purchased_Date, string Invoice_Picture, string userid)
        {
            string result = "";
            result = "new INVOICE {COST =  (decimal)" + Cost;
            result += ',' + "SUPPLIERID = "  + supplierID ;
            result += ',' + "PURCHASED_DATE = " +" Convert.ToDateTime("+ '"'+ Purchased_Date + '"'+")";
            result += ',' + "INVOICE_PICTURE = " +'"'+ Invoice_Picture+ '"';
            result += ',' + "Id = " + '"'+userid + '"';
            result += "}" + ',' + "\n";

            return result;
        }

        public ArrayList RandomIndex(int numberofItems, int productIndex)
        {
            ArrayList Result = new ArrayList();
            Random R = new Random();
            int Items = R.Next(1, numberofItems);
            
            for(int i =0; i< Items; i++)
            {
                int index = R.Next(productIndex);
                Result.Add(index);
            }
            return Result;

        }

        #region Enrolment Methods
        private ArrayList StudentLimit (ArrayList rowdata, int startIndex, int endIndex)
        {
            ArrayList Result = new ArrayList();

            for(int i =startIndex; i<= endIndex; i++)
            {
                string[] data = rowdata[i].ToString().Split(',');
                Result.Add(data[0]);
            }

            return Result;

        }

        #endregion
        static void Main(string[] args)
        {
            Program _program = new Program();
            #region User
            int Male = 1;
            int Female = 1;

            ArrayList _user = _program.ReadFile(new TextFieldParser(@"D:\Capstone Project\MOCK DATA\USER\MOCK_DATA.csv"));

            for (int i = 0; i < _user.Count; i++)
            {
                USER U = new USER(_user[i].ToString(), Male, Female);
                if (U.Gender == "Male") // && Male <= 62)
                {
                    Male++;
                    Console.Write(U.output());
                }
                else if (U.Gender == "Female")// && Female <= 69)
                {
                    Female++;
                    Console.Write(U.output());
                }
            }

            Console.WriteLine("Male = " + Male);
            Console.WriteLine("Female = " + Female);
            #endregion

            #region Course Class
            //ArrayList CourseList = _program.ReadFile( new TextFieldParser(@"D:\Capstone Project\MOCK DATA\COURSE\Course.csv"));
            //int ClassCounter = 1000;
            //for(int i =0; i< CourseList.Count; i++)
            //{

            //    int counter = 0;
            //    string[] CourseData = CourseList[i].ToString().Split(',');
            //    for(int year =2016 ; year<= 2019; year++)
            //    {
            //        for(int Semester = 1; Semester<=2; Semester++)
            //        {
            //            string startDate = "";
            //            string finishDate = "";
            //            if(Semester == 1)
            //            {
            //                startDate = "28/02/" + year;
            //                finishDate = "30/06/" + year;
            //            }
            //            else
            //            {
            //                startDate = "15/07/" + year;
            //                finishDate = "30/11/" + year;
            //            }
            //            if (counter < 7)
            //            {
            //                COURSE_CLASS CC = new COURSE_CLASS(ClassCounter.ToString(), startDate, finishDate, year, Semester, CourseData[0].ToString());
            //               Console.WriteLine( CC.output());
            //                ClassCounter++;
            //                counter++;
            //            }
            //        }
            //    }


            //}
            #endregion

            #region Enrollment
            var Timeline = new YearSemester[]
            {
                new YearSemester(2016, 1),
                  new YearSemester(2016, 2),
                  new YearSemester(2017, 1),
                  new YearSemester(2017, 2),
                  new YearSemester(2018, 1),
                  new YearSemester(2018, 2),
                  new YearSemester(2019, 1),
            };

            /*
            //string dt = DateTime.Now.ToShortDateString();
            //DateTime dt1 = Convert.ToDateTime(dt);
            //Console.WriteLine(dt);
            //Console.WriteLine(dt1);


            ArrayList AllStudent = _program.StudentLimit(_program.ReadFile(new TextFieldParser(@"D:\Capstone Project\MOCK DATA\USER\USER_TABLE.csv")), 0, 1000);
            ArrayList AllPaper = _program.ReadFile(new TextFieldParser(@"D:\Capstone Project\MOCK DATA\COURSE\Course.csv"));
            YearSemester[] allSemester = new[]
            {
                new YearSemester(2016,1),
                new YearSemester(2016,2),
                new YearSemester(2017,1),
                new YearSemester(2017,2),
                new YearSemester(2018,1),
                new YearSemester(2018,2),
                new YearSemester(2019,1)
            };

         
        //    COURSETYPE[] AllCourses = new[]
        //    {
        //        //level - 3 (1 semester)
        //        new COURSETYPE(new [] {Level.List0fPapper(3, AllPaper, 3), Level.List0fPapper(4, AllPaper, 1) }),
        //        //level -4 (2 semester)
        //         new COURSETYPE(new [] {Level.List0fPapper(3, AllPaper, 3), Level.List0fPapper(4, AllPaper, 5) }),
        //         /// level -5 (2 semester)
        //          new COURSETYPE(new [] {Level.List0fPapper(4, AllPaper, 2), Level.List0fPapper(5, AllPaper, 6) }),
        //           /// level -6 (4 semester)
        //          new COURSETYPE(new [] {Level.List0fPapper(5, AllPaper, 8), Level.List0fPapper(6, AllPaper, 8) }),
        //          // level -7 (6 semester)
        //          new COURSETYPE(new [] { Level.List0fPapper(4, AllPaper, 7), Level.List0fPapper(5, AllPaper, 8), Level.List0fPapper(6, AllPaper, 7), Level.List0fPapper(7, AllPaper, 2) })
        //};
            Random random = new Random();

            for (int i =0; i< AllStudent.Count; i++)
            {
                Couse_Level Level = new Couse_Level();
                COURSETYPE[] AllCourses = new[]
            {
                //level - 3 (1 semester)
                new COURSETYPE(new [] {Level.List0fPapper(3, AllPaper, 3), Level.List0fPapper(4, AllPaper, 1) }),
                //level -4 (2 semester)
                 new COURSETYPE(new [] {Level.List0fPapper(3, AllPaper, 3), Level.List0fPapper(4, AllPaper, 5) }),
                 /// level -5 (2 semester)
                  new COURSETYPE(new [] {Level.List0fPapper(4, AllPaper, 2), Level.List0fPapper(5, AllPaper, 6) }),
                   /// level -6 (4 semester)
                  new COURSETYPE(new [] {Level.List0fPapper(5, AllPaper, 8), Level.List0fPapper(6, AllPaper, 8) }),
                  // level -7 (6 semester)
                  new COURSETYPE(new [] { Level.List0fPapper(4, AllPaper, 7), Level.List0fPapper(5, AllPaper, 8), Level.List0fPapper(6, AllPaper, 7), Level.List0fPapper(7, AllPaper, 2) })
        };
                // Select start semester
                int _startSemeterIndex = random.Next(allSemester.Length);
               // Console.WriteLine("Start semester" + _startSemeterIndex);
                // Setect COuse Type index
                int _courseTypeIndex = random.Next(AllCourses.Length);
               // Console.WriteLine("Course level" + _courseTypeIndex);
                /// Student semeter
                int counter = 0;
               for(int j = _startSemeterIndex; j<allSemester.Length; j++)
                {
                    COURSETYPE SelectedCourse = AllCourses[_courseTypeIndex];
                    for(int k =0; k<SelectedCourse.getPaper(counter).Count; k++)
                    {
                        string COURSEID = SelectedCourse.getPaper(counter)[k].ToString();
                        string CLASSID = _program.selectedClass(allSemester[j].Year, allSemester[j].Semester, COURSEID);
                        string StudentID = AllStudent[i].ToString();
                        // Console.WriteLine(SelectedCourse.getPaper(counter)[k]);
                        /// new ENROLLMENT { Id= "DEYR02", COURSE_CLASSID = "2800" },
                        /// 

                        var output = "new ENROLLMENT { Id= " + '"' + StudentID + '"' + ", COURSE_CLASSID = " + '"' + CLASSID + '"' + "},";
                        Console.WriteLine(output);
                    }
                    counter++;
                }
            }

           

           // COURSETYPE Level7 = new COURSETYPE(new [] { Level.List0fPapper(4, AllPaper, 7), Level.List0fPapper(5, AllPaper, 8), Level.List0fPapper(6, AllPaper, 7), Level.List0fPapper(7, AllPaper, 2) });
            

           //for(int j =0; j<6; j++)
           // {
           //     Console.WriteLine("semester " + j);
           //     for (int i = 0; i < Level7.getPaper(j).Count; i++)
           //     {
           //         Console.WriteLine(Level7.getPaper(j)[i]);
           //     }
           // }
           */
            #endregion

            #region Invoice
//            ArrayList ProductInvoiceOutput = new ArrayList();
//            int InvoiceID = 1;
//            Invoice_Product IP;
//            ArrayList CurrentProducts = _program. ReadFile(new TextFieldParser(@"D:\Capstone Project\MOCK DATA\PRODUCT_INVOICE\PRODUCT.csv"));
//            string[] userID = {"2013a6cc-9d6b-4a3a-8b10-f2a4cc6eeb32", "5e204afa-c00b-49c5-8da1-471051338377","7afaaf31-1b35-4f42-a882-1d92e8f6aeb2",
//"cac15241-4161-4a35-b0a9-04847bde381d"};
//            ///Year
//            Random random = new Random();
//            for(int i =2016; i<=2018; i++)
//            {
                
//                for (int j = 1; j<=12; j++)
//                {
//                    int Number_of_Time_Each_Month = random.Next(1, 13);
//                    for (int k =0; k<Number_of_Time_Each_Month; k++)
//                    {

//                        int date = random.Next(1, 28);
//                        string pd = date + "/" + j + '/' + i;
//                        DateTime PurchasedDate = Convert.ToDateTime(pd);

                        


//                        ArrayList Result = new ArrayList();
                     
//                        int Items = random.Next(1, 6);

//                        for (int A = 0; A < Items; A++)
//                        {
//                            int index = random.Next(CurrentProducts.Count);
//                            Result.Add(index);
//                        }
                      
//                        IP = new Invoice_Product(InvoiceID++, CurrentProducts, Result);
//                        for(int B =0; B<IP.getDaitls().Count; B++)
//                        {
//                            ProductInvoiceOutput.Add(IP.getDaitls()[B]);
//                        }

//                        //InvoiceID++;
//                        double price = IP.TotalCost(); //random.Next(1, 1000);
//                        string id = userID[random.Next(userID.Length)];
//                        int imageid = random.Next(1, 6);
//                        string Image_Url = "/images/Invoice_Picture/Invoice_" + imageid + ".jpg";
//                         Console.WriteLine(_program.Invoice_output(price, 3, PurchasedDate, Image_Url, id));
                      



//                    }
//                }
//            }
//            Console.WriteLine("\n");
//            Console.WriteLine("\n");
//            Console.WriteLine("\n");
//            Console.WriteLine("\n");
//            Console.WriteLine("\n");
//            Console.WriteLine("\n");
//            Console.WriteLine("\n");
//            Console.WriteLine("\n");
//            Console.WriteLine("\n");
//            Console.WriteLine("\n");
//            for (int i =0; i<ProductInvoiceOutput.Count; i++)
//            {
//                Console.WriteLine(ProductInvoiceOutput[i]);
//            }


            #endregion

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
