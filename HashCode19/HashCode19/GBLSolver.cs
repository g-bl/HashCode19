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
        public string id;
        public bool horizontal;
        public List<string> tags = new List<string>();
    }

    public class Slide
    {
        public List<Photo> photos = new List<Photo>();
        public List<string> tags = new List<string>();

        public override string ToString()
        {
            string output = "";
            foreach (Photo photo in photos)
            {
                output = String.Join(" ", output, photo.id);
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

            Console.WriteLine("Input loading... " + inputFileName);

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string[] lines = File.ReadAllLines(inputFilePath);
            
            int photosCount = int.Parse(lines[0]);

            //Content
            for (int i = 0; i < photosCount; i++)
            {
                string[] splittedLine = lines[i + 1].Split(delimiter);

                Photo photo = new Photo();
                photo.id = i.ToString();
                photo.horizontal = splittedLine[0] == "H";

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

            // Handle verticale

            List<Photo> verticalePhotos = photos.Where(p => !p.horizontal).ToList();
            photos.RemoveAll(p => !p.horizontal);

            verticalePhotos = verticalePhotos.OrderBy(p => -p.tags.Count).ToList();

            List<Photo> listV1 = new List<Photo>();
            List<Photo> listV2 = new List<Photo>();

            bool flag = false;
            foreach (Photo photo in verticalePhotos)
            {
                if (flag)
                    listV1.Add(photo);
                else
                    listV2.Add(photo);

                flag = !flag;
            }
            listV2.Reverse();
            
            for (int i = 0; i < listV2.Count; i++)
            {
                Photo leftPhoto = listV1[i];
                Photo rightPhoto = listV2[i];

                Photo newPhoto = new Photo();
                newPhoto.id = leftPhoto.id + " " + rightPhoto.id;
                newPhoto.horizontal = true;
                newPhoto.tags = leftPhoto.tags.Concat(rightPhoto.tags).Distinct().ToList();

                photos.Add(newPhoto);
            }

            // TRI PAR LE MILIEU
            /*List<Photo> list1 = new List<Photo>();
            List<Photo> list2 = new List<Photo>();
            bool flag = false;
            foreach (Photo photo in photos)
            {
                if (flag)
                    list1.Add(photo);
                else
                    list2.Add(photo);

                flag = !flag;
            }
            list2.Reverse();
            photos = list1.Concat(list2).ToList();*/



            photos = photos.OrderBy(p => -p.tags.Count).ToList(); //sortAscending

            // First
            Slide firstSlide = new Slide();
            firstSlide.photos.Add(photos[0]);
            firstSlide.tags.Concat(photos[0].tags);

            slides.Add(firstSlide);
            photos.Remove(photos[0]);

            while (photos.Count > 0)
            {
                Photo lastPhoto = slides.Last().photos.First();
                Photo selectedPhoto = null;
                int scoreMax = -1;

                int counter = 0;
                foreach (Photo nextPhoto in photos)
                {
                    int score = GetScore(lastPhoto, nextPhoto);
                    if (score > scoreMax)
                    {
                        scoreMax = score;
                        selectedPhoto = nextPhoto;
                    }

                    counter++;
                    if (counter > 100)
                        break;
                }
                
                if (selectedPhoto == null)
                {
                    Console.WriteLine("break");
                    break;
                }

                Slide nextSlide = new Slide();
                nextSlide.photos.Add(selectedPhoto);
                nextSlide.tags.Concat(selectedPhoto.tags);

                slides.Add(nextSlide);
                photos.Remove(selectedPhoto);
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

            Console.WriteLine("Done. :" + slides.Count);
        }

        public int GetScore(Photo photo1, Photo photo2)
        {
            int duplicateTagsCount = photo1.tags.Count + photo2.tags.Count - photo1.tags.Concat(photo2.tags).ToList().Distinct().Count();
            int exclusivePhoto1Count = photo1.tags.Count - duplicateTagsCount;
            int exclusivePhoto2Count = photo2.tags.Count - duplicateTagsCount;

            int score = Math.Min(Math.Min(duplicateTagsCount, exclusivePhoto1Count), exclusivePhoto2Count);

            return score;
        }
    }
}