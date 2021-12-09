using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOCK_DATA_CREATOR
{
    class COURSETYPE
    {
        private ArrayList papers = new ArrayList();
      
        public COURSETYPE(ArrayList[] Levels)
        {
            for(int i =0; i< Levels.Length; i++)
            {
                for (int j = 0; j < Levels[i].Count; j++)
                {
                    papers.Add(Levels[i][j]);
                }
            }

        }
       
        public ArrayList getPaper(int counter)
        {
            ArrayList Result = new ArrayList();
            int count = 0;
            for (int i = counter *4; i < papers.Count; i++)
            {
                Result.Add(papers[i]);

                count++;
                if(count == 4)
                {
                    break;
                }
            }
           
            
            
            return Result;
        }
    }
}
