using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode19
{
    public class Photo
    {
        public int id;
        public bool horizontal;
        public List<string> tags;
    }

    public class Slide
    {
        public List<Photo> photos;

        public override string ToString()
        {
            string output = "";
            foreach (Photo photo in photos)
            {
                output = String.Join(" ", output, photo.id.ToString());
            }

            return output.Remove(0, 1);
        }
    }

    class GBLSolver
    {
        public GBLSolver(string inputFileName, string outputFileName, char delimiter)
        {
            List<Photo> photos = new List<Photo>();
            List<Slide> slides = new List<Slide>();

            /**************************************************************************************
             *  Input loading
             **************************************************************************************/

            Console.WriteLine("Input loading...");

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string[] lines = File.ReadAllLines(inputFilePath);
            
            int photosCount = int.Parse(lines[0]);

            //Content
            for (int i = 0; i < photosCount; i++)
            {
                string[] splittedLine = lines[i + 1].Split(delimiter);

                Photo photo = new Photo();
                photo.id = i;
                photo.horizontal = splittedLine[0] == "H";
                photo.tags = new List<string>();

                int tagsCount = int.Parse(splittedLine[1]);
                for (int j = 0; j < tagsCount; j++)
                {
                    photo.tags.Add(splittedLine[2+j]);
                }

                photos.Add(photo);
            }

            /**************************************************************************************
             *  Solver
             **************************************************************************************/

            Console.WriteLine("Solving...");

            foreach (Photo photo in photos)
            {
                if (photo.horizontal)
                {
                    Slide slide = new Slide();
                    slide.photos = new List<Photo>();
                    slide.photos.Add(photo);

                    slides.Add(slide);
                }
            }


            /**************************************************************************************
             *  Output
             **************************************************************************************/

            Console.WriteLine("Output to file...");

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), outputFileName)))
            {
                outputFile.WriteLine(slides.Count);

                foreach (Slide slide in slides)
                {
                    outputFile.WriteLine(slide.ToString());
                }
            }

            Console.WriteLine("Done.");
        }

    }
}