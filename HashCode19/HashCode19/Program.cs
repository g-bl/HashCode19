using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode19
{
    class HashCodeMainClass
    {
        private static string inputFileName = "a_example.in"; // a_example b_lovely_landscapes c_memorable_moments d_pet_pictures e_shiny_selfies
        private static string outputFileName = "a_example.out";
        private static char delimiter = ' ';

        static void Main(string[] args)
        {
            GBLSolver solver = new GBLSolver(inputFileName, outputFileName, delimiter);
        }
    }
}
