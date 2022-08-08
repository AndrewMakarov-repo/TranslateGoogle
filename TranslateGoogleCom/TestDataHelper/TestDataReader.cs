using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace TranslateGoogleCom.TestDataHelper
{
    public class TestDataReader
    {
        public static List<TestCaseData> TestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(@"C:\Users\Andrey_Makarov\source\repos\TranslateGoogleCom\TestData.txt"))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' },
                                StringSplitOptions.None);

                            string text = Convert.ToString(split[0]);
                            string expectedResult = Convert.ToString(split[1]);
                            string sourceLanguage = Convert.ToString(split[2]);
                            string targetLanguage = Convert.ToString(split[3]);

                            var testCase = new TestCaseData(text, expectedResult, sourceLanguage, targetLanguage);
                            testCases.Add(testCase);
                        }
                    }
                }
                return testCases;
            }
        }
    }
}
