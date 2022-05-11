using ConsoleTestApp.Extension;
using ConsoleTestApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    class Program
    {
        const string FileName = "000113065_WattsWater.json";

        static void Main(string[] args)
        {
            ////CountOccurrence();
            ////PrintCaseConversion();
            ////FarthestFromZero();
            ReadDataFromJsonFile();
            Console.Read();
        }

        private static void CountOccurrence()
        {
            int numberOfInputs = Convert.ToInt32(Console.ReadLine());
            char[] inputArray;
            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();
                inputArray = input.ToCharArray();
                var result = inputArray.GroupBy(c => c);

                foreach(var grpItem in result)
                {
                    Console.Write("{0}{1}", grpItem.Key, grpItem.Count());
                }

                Console.Write("\n");
            }
        }

        static void PrintCaseConversion()
        {
            int numberOfInputs = Convert.ToInt32(Console.ReadLine());
            var result = new StringBuilder();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();
                result.Append(input.ToLower());
                bool isUpperCaseChar = false;
                int numberOfAddedUnderScoreCount = 0;

                for (int j = 0; j < input.Length; j++)
                {
                    if (Char.IsUpper(input[j]))
                    {
                        isUpperCaseChar = true;
                    }

                    if (j > 0 && isUpperCaseChar)
                    {
                        result.Insert(j + numberOfAddedUnderScoreCount, "_");
                        numberOfAddedUnderScoreCount++;
                    }

                    isUpperCaseChar = false;
                }

                Console.WriteLine(result.ToString());

                result.Clear();
            }
        }

        static void FarthestFromZero()
        {
            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];

            for (int i =0; i < size; i++)
            {
                string input = Console.ReadLine();

                array = input.Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
            }

            int maxElement = array.Max();

            Console.WriteLine(maxElement);
        }

        static void ReadDataFromJsonFile()
        {
            var accountData = JsonFileReader.ReadJsonDataByFileName<MemberOrOrganizationDataModel>(FileName);
            ////string appExecutalePath = Directory.GetCurrentDirectory();
            ////string filePath = $"{appExecutalePath}\\{fileName}";
        }
    }
}
