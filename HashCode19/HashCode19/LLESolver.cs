using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode19
{
    class LLESolver
    {
        public LLESolver(string inputFileName, string outputFileName, char delimiter)
        {
            /**************************************************************************************
             *  Input loading
             **************************************************************************************/

            Debug.WriteLine("Input loading...");

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string[] lines = File.ReadAllLines(inputFilePath);

            //First Line
            string[] firstLine = lines[0].Split(delimiter);

            int R = int.Parse(firstLine[0]); // number of rows
            int C = int.Parse(firstLine[1]); // number of columns
            int X = int.Parse(firstLine[2]); // number of vehicles
            int XX = int.Parse(firstLine[3]); // 
            int XXX = int.Parse(firstLine[4]); // 
            int XXXX = int.Parse(firstLine[5]); // 

            //Content
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splittedLine = lines[i].Split(delimiter);


            }

            /**************************************************************************************
             *  Solver
             **************************************************************************************/
        }

    }
}