using ConsoleTestApp.Extension;
using ConsoleTestApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            string s = "19-DEC-52";
            DateTime dt;
            DateTime.TryParseExact(s, "dd-MMM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

            var accountData = JsonFileReader.ReadJsonDataByFileName<MemberOrOrganizationDataModel>(FileName);

            List<MemberOrOrganizationRelationshipItemModel> allMemberAssociatedWithOrg = accountData?.
                OutputParameters?.
                X_ACCOUNT_TAB?.
                X_ACCOUNT_TAB_ITEM?.
                RELATIONSHIP?.
                RELATIONSHIP_ITEM;

            foreach(var item in allMemberAssociatedWithOrg)
            {
                DateTime.TryParseExact(item.START_DATE.Substring(0, 9), "dd-MMM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                item.StartDate = dt;

                DateTime.TryParseExact(item.END_DATE.Substring(0, 9), "dd-MMM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                item.EndDate = dt;

                DateTime.TryParseExact(item.END_DATE, "dd-MMM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            }

            ////string appExecutalePath = Directory.GetCurrentDirectory();
            ////string filePath = $"{appExecutalePath}\\{fileName}";
            ///
            var activeData = allMemberAssociatedWithOrg.Where(m => m.RELATIONSHIP_STATUS.Equals("A")).ToList();
            var  inActiveData= allMemberAssociatedWithOrg.Where(m => m.RELATIONSHIP_STATUS.Equals("I")).ToList();

            DateTime march31_2022 = new DateTime(2022, 03, 31);
            var activeDataAfter31March2022 = allMemberAssociatedWithOrg
                .Where(m => m.StartDate >= march31_2022 && m.RELATIONSHIP_STATUS.Equals("A")).ToList();
            var inActiveDataAfter31March2022 = allMemberAssociatedWithOrg
                .Where(m => m.StartDate >= march31_2022 && m.RELATIONSHIP_STATUS.Equals("I")).ToList();
        }
    }
}
