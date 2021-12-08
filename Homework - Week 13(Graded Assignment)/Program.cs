using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

         /// File Name: Homework - Lab - Week 13(Graded Assignment)
         /// Student: Samuel Peppetta
        /// Miracosta college fall 2021
       /// Professor Mark Akola

namespace SL
{

    class NameNumbers
    {
           //boynames Download boynames

           //girlnames Download girlnames

           //They contain a list of the 1000 most popular boy and girl names in the United States for the year 2003
           //as compiled by the Social Security Administration.
           //These are blank-delimited files where the most popular name is listed first,
           //the second most popular second, and so on to the 1000th most popular name which is listed last.
           //Each line consists of the first name followed by a blank space and then the number of registered
           //births using that name in the year.For example the girlnames.txt file begins with:
           
            //Emily 25494
           //Emma 22532
           //Madison 19986
           //This indicates that Emily was the most popular name with 25494 registered namings,
           //Emma was the second most popular with 22532, and Madison was the third most popular with 19986. 
           //Write a program that reads both the girl’s and boy’s files into memory using a dictionary.
           //The key should be the name and value should be a user defined object which is the count and rank of
           //the name.Allow the user to input a name, the program should find the name in the dictionary and print
           //out the rank and the number of namings.If the name isn’t a key in the dictionary then the program should
           //note this and say that no match exists.
           //If the user enters the name “Walter”, then the program should output:
           //Walter is not ranked among the top 1000 girl names.
            //Walter is ranked 356 in popularity among boys with 775 namings.
  
        public NameNumbers(int r, int t)
        {
            Rank = r;
            TimesUsed = t;
        }
        public int Rank, TimesUsed;
    }
    class Program
    {

        static void Main(string[] args)
        {
            //<---type of object called dictionary where string is the key and NameNumbers are the values
            Dictionary<string, NameNumbers> boysNames = new Dictionary<string, NameNumbers>();
            Dictionary<string, NameNumbers> girlsNames = new Dictionary<string, NameNumbers>();

            try
            {
                using (StreamReader SR = new StreamReader("C:\\Users\\Samuel\\Desktop\\programing\\boynames.txt"))
                {
                    int rank = 0;
                    string line;
                    while ((line = SR.ReadLine()) != null)
                    {
                        string[] entry = line.Split();//this has two strings index 0 and index 1 is the value

                        // note below!!!! ++rank is incrementing rank first  entry 1 is how many times it was used that's why we are passing it into the name numbers 
                        boysNames.Add(entry[0], new NameNumbers(++rank, int.Parse(entry[1])));

                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Could not open the boy's file");
            }
            try
            {
                using (StreamReader SR = new StreamReader("C:\\Users\\Samuel\\Desktop\\programing\\girlnames.txt"))
                {
                    int rank = 0;
                    string line;
                    while ((line = SR.ReadLine()) != null)
                    {
                        string[] entry = line.Split();//this has two strings index 0 and index 1 is the value

                        // note below!!!! ++rank is incrementing rank first  entry 1 is how many times it was used that's why we are passing it into the name numbers 
                        girlsNames.Add(entry[0], new NameNumbers(++rank, int.Parse(entry[1])));

                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Could not open the girl's file");
            }
            // first half done with the two dictionaries filled with boy and girl names!!

            Console.WriteLine("Please enter name");
            string userinput = Console.ReadLine();
            bool wasFound = false;

            // For the boys

            foreach (KeyValuePair<string, NameNumbers> item in boysNames)
            {
                if (item.Key.Equals(userinput))
                {
                    Console.WriteLine(userinput + " is ranked " + item.Value.Rank + " in popularity among boys with "
                        + item.Value.TimesUsed + " namings.");

                    wasFound = true;
                    break;
                }
            }
            if (!wasFound)
            {
                Console.WriteLine(userinput + "is not ranked among the top 1000 boy names.");
            }
            wasFound = false;

            //for the girls

            foreach (KeyValuePair<string, NameNumbers> item in girlsNames)
            {
                if (item.Key.Equals(userinput))
                {
                    Console.WriteLine(userinput + " is ranked " + item.Value.Rank + " in popularity among girls with "
                        + item.Value.TimesUsed + " namings.");

                    wasFound = true;
                    break;
                }
            }
            if (!wasFound)
            {
                Console.WriteLine(userinput + "is not ranked among the top 1000 girl names.");
            }
            wasFound = false;
            Console.ReadLine();
        }
    }
}