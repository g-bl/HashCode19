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
        static void Main(string[] args)
        {
            GBLSolver solverA = new GBLSolver("a_example.in", "a_example.out", ' ');
            GBLSolver solverB = new GBLSolver("b_lovely_landscapes.in", "b_lovely_landscapes.out", ' ');
            GBLSolver solverC = new GBLSolver("c_memorable_moments.in", "c_memorable_moments.out", ' ');
            GBLSolver solverD = new GBLSolver("d_pet_pictures.in", "d_pet_pictures.out", ' ');
            GBLSolver solverE = new GBLSolver("e_shiny_selfies.in", "e_shiny_selfies.out", ' ');
            Console.ReadKey();
        }
    }
}
