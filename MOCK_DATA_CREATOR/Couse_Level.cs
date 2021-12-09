using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOCK_DATA_CREATOR
{
    class Couse_Level
    {
        public ArrayList List0fPapper (int level , ArrayList list , int count)
        {
            ArrayList Result = new ArrayList();

            for(int i =0; i<list.Count; i++)
            {
                string[] data = list[i].ToString().Split(',');
                if(data[0][4].ToString() == level.ToString())
                {
                    Result.Add(data[0]);
                }

            }
            return RandomSelection(Result, count);
           
        }


        public ArrayList RandomSelection (ArrayList allData, int _count) 
        {
            ArrayList Result = new ArrayList();
            if(_count > allData.Count)
            {
                Console.WriteLine("Selection Error");
            }
            else
            {
                
                Random random = new Random();
                for(int i =0; i<_count; i++)
                {
                    int Index = random.Next(allData.Count);
                    Result.Add(allData[Index]);
                    allData.RemoveAt(Index);
                }
            }
            return Result;
        }
    }
}
