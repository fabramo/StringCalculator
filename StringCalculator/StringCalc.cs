using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalc
    {
        /*public StringCalc()
        {
            
        }*/

        public int Add(string str)
        {
            List<string> separator = new List<string>(new[] {",", "\n"}); //default value
            string[] stringSeparators = {"//", "[", "]"};

            //is empty
            if (str == "")
            {
                return 0;
            }

            //if start with // means that the separator is change
            if (str.StartsWith("//"))
            {
                //[]\n... => result split is //[] and ...
                //separator\n... => result split is //separator and ...
                //first element contains the separator, second element contains the number
                string[] strSplit = str.Split(new[] {'\n'}, 2);

                str = strSplit.Last();
                strSplit = strSplit[0].Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                separator.AddRange(strSplit);
            }

            string[] valueArray = str.Split(separator.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            int[] numbersArrary;

            try
            {
                numbersArrary = valueArray.Select(n =>
                {
                    int i = Convert.ToInt32(n);
                    if (i > 1000)
                        i = 0;

                    return i;
                }).ToArray();

                int[] negativeNumbers = numbersArrary.Where(i => i < 0).ToArray();

                if (negativeNumbers.Length > 0)
                    throw new ArgumentException($"Negatives not allowed {string.Join(",", negativeNumbers)}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }

            return numbersArrary.Sum();
        }
    }
}