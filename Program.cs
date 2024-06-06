using System;
using System.IO;
using System.Reflection.Metadata;
using System.Text;

namespace WordReplaceThursday
{
    class Program
    {
        static void Main(string[] args)
        {
            string? inputfile = null;
            string? outputfile = null;
            string? oldword = null;
            string? newword = null;

            bool count = false;
            bool caseInsensitive = true;

            //loops through the arguments given on the command line
            for (int i = 0; i < args.Length - 1; i++)
            {
                switch (args[i])
                {
                    //fill in the input variables
                    case "-inputfile":
                        if (i < args.Length) inputfile = args[++i];
                        //i += 1;
                        break;

                    case "-outputfile":
                        if (i < args.Length) outputfile = args[++i];
                        break;

                    case "-oldword":
                        if (i < args.Length) oldword = args[++i];
                        break;

                    case "-newword":
                        if (i < args.Length) newword = args[++i];
                        break;

                    case "-count":
                        count = true;
                        break;

                    case "-insensitive":
                        caseInsensitive = true;
                        break;

                    case "-sensitive":
                        caseInsensitive = false;
                        break;

                    default:
                        Console.WriteLine("Argumento invalido: " + args[i]);
                        return;

                }
            }

            //Mandatory arguments
            //IsNullOrEmpty - This is the function that observes whether it is null and whether it has at least 1 character
            if (string.IsNullOrEmpty(inputfile) || string.IsNullOrEmpty(outputfile) || string.IsNullOrEmpty(oldword))
            {
                Console.WriteLine("Ausencia de comandos obrigatorios de entrada.");
                return;
            }

            //Read the file
            string reader = File.ReadAllText(inputfile);

            //Sensitivity treatment - sensitive option will be the default
            if (caseInsensitive)
            {
                reader = reader.ToLower();
                oldword = oldword.ToLower();
            }

            //For word count 
            int wordcount = CountOcurrences(reader, oldword);
            Console.WriteLine($"A palavra {oldword} ocorre {wordcount} vezes");

            //So that you don't make substitutions
            if (count)
            {
                return;
            }

                //validation of the new word 
                if (string.IsNullOrEmpty(newword))
            {
                Console.WriteLine("Ausencia da nova palavra!");
                return;
            }

            //replacement 
            reader = ReplaceWord(reader, oldword, newword, caseInsensitive);

            //output writing
            File.WriteAllText(outputfile, reader);
            Console.WriteLine("Arquivo gravado!");


            ///////FUNCTIONS 

            static int CountOcurrences(string reader, string word)
            {
                int count = 0; //specified: int
                int index = 0;

                while ((index = reader.IndexOf(word, index)) != -1)
                {
                    count++;
                    index += word.Length; //update to next character
                }
                return count;
            }

            static string ReplaceWord(string reader, string oldword, string newword, bool caseInsensitive) //attention for the type the caseInsensitive
            {
                if (caseInsensitive) return ReplaceCaseInsensitive(reader, oldword, newword);
                return reader.Replace(oldword, newword);
            }

            //optimizing with StringBuilder
            static string ReplaceCaseInsensitive(string reader, string oldword, string newword)
            {
                System.Text.StringBuilder result = new System.Text.StringBuilder();
                int prevIndex = 0;
                int index = 0;
                while ((index = reader.IndexOf(oldword, prevIndex)) != -1)
                {
                    result.Append(reader.Substring(prevIndex, index - prevIndex)).Append(newword);
                    prevIndex = index + oldword.Length;
                }
                result.Append(reader.Substring(prevIndex));
                return result.ToString();
            }
        }
    }
}












