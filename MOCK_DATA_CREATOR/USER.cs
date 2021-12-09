using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOCK_DATA_CREATOR
{
    class USER
    {
       
        public USER (string Data, int _male_Counter, int _female_Counter)
        {
            string[] _data = Data.Split(',');
            FIRST_NAME = _data[0];
            LAST_NAME = _data[1];
            Email = _data[2];
            Gender = _data[3];
            VET_STATUS = true;
            EmailConfirmed = true;
            AUTHORIZED = true;
            MaleCounter = _male_Counter;
            FemaleCounter = _female_Counter;

            USER_TYPEID = 3;

        }
        public string LAST_NAME { get; set; }
        public string FIRST_NAME { get; set; }
        public bool AUTHORIZED { get; set; }
        public bool VET_STATUS { get; set; }
        public string Gender { get; set; }
        public string PROFILE_PICTURE()
        {
            string Result = "";
            if (Gender == "Male")
            {
                Result = "/images/Profile_Picture/Male -  (" +MaleCounter+").jpg";
                MaleCounter++;
            }
            else if (Gender == "Female")
            {
                Result = "/images/Profile_Picture/Female -  ("+FemaleCounter+").jpg";
                FemaleCounter++;
            }
            return Result;
        }
        public int USER_TYPEID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        
        public int MaleCounter { get; set; }
        public int FemaleCounter { get; set; }
        public string USERID()
        {
            Random random = new Random();
            string Result = LAST_NAME.Substring(0, 3) + FIRST_NAME.Substring(0, 2) +"0" + random.Next(1, 9);
            return '"' + Result + '"';
            
        }

        public string output()
        {
            string result = "";
            result = "new ApplicationUser {USERID = " + USERID().ToUpper();
            result += ',' + "LAST_NAME = " + '"' + LAST_NAME + '"';
            result += ',' + "FIRST_NAME = " + '"' + FIRST_NAME + '"';
            result += ',' + "VET_STATUS = "  + VET_STATUS.ToString().ToLower();

            result += ',' + "PhoneNumber = " + '"' + PhoneNumber + '"';
            result += ',' + "Email = " + '"' + Email + '"';
            result += ',' + "EmailConfirmed = "+ EmailConfirmed.ToString().ToLower();
            result += ',' + "USER_TYPEID = " + USER_TYPEID;
            result += ',' + "AUTHORIZED = " + AUTHORIZED.ToString().ToLower();
            result += ',' + "PROFILE_PICTURE = " + '"' + PROFILE_PICTURE() + '"';
            result += ',' + "UserName = " + '"' + Email + '"';
            result += "}" + ',' +"\n";
         
            return result;
        }
    }
    
}
