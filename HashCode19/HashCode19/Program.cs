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
        private static string inputFileName = "e_high_bonus.in"; // a_example b_should_be_easy c_no_hurry d_metropolis e_high_bonus
        private static string outputFileName = "e_high_bonus.out";
        private static char delimiter = ' ';

        static void Main(string[] args)
        {
            GBLSolver solver = new GBLSolver(inputFileName, outputFileName, delimiter);
        }
    }
}
