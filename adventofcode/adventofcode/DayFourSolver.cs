using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode
{
    class DayFourSolver : Solver
    {
        public override string SolvePartOne(string inputString)
        {
            int badLists = 0;

            string[] passphraseLists = inputString.Split('\n');

            foreach (string passphraseList in passphraseLists)
            {
                List<string> storedPassphrases = new List<string>();

                // Remove the sneaky newline characters
                string passphraseListNoNewline = Regex.Replace(passphraseList, @"\n|\r", "");
                string[] passphrases = passphraseListNoNewline.Split(' ');

                if(!(passphrases.Length > 1))
                {
                    badLists++;
                    continue;
                }

                foreach(string passphrase in passphrases)
                {
                    if (!storedPassphrases.Contains(passphrase))
                    {
                        storedPassphrases.Add(passphrase);
                    }
                    else
                    {
                        Console.WriteLine("Duplicate detected - " + passphrase + " has already appeared in list (" + passphraseList + ")");
                        badLists++;
                        break;
                    }
                }
            }

            return (passphraseLists.Length - badLists).ToString();
        }

        public override string SolvePartTwo(string inputString)
        {
            int badLists = 0;

            string[] passphraseLists = inputString.Split('\n');

            foreach (string passphraseList in passphraseLists)
            {
                List<string> storedWords = new List<string>();

                // Remove the sneaky newline characters
                string passphraseNoNewline = Regex.Replace(passphraseList, @"\n|\r", "");
                string[] words = passphraseNoNewline.Split(' ');

                if (!(words.Length > 1))
                {
                    badLists++;
                    continue;
                }

                Boolean conflict = false;

                foreach (string word in words)
                {
                    foreach (string storedWord in storedWords)
                    {
                        if (storedWords.Count == 0)
                        {
                            break;
                        }

                        if (word.Length != storedWord.Length)
                        {
                            continue;
                        }  

                        // If the sum off all the characters in the strings match - this might be an anagram
                        if (storedWord.Sum(x=>x) == word.Sum(x=>x))
                        {
                            // verify that this is indeed an anagram

                            List<char> temp = storedWord.ToList();

                            foreach (char character in word)
                            {
                                if(temp.Contains(character))
                                {
                                    temp.Remove(character);
                                }
                            }

                            if (temp.Count == 0)
                            {
                                Console.WriteLine(word + " is an anagram of " + storedWord);
                                conflict = true;
                                break;
                            }
                        }
                    }

                    if(!conflict)
                    {
                        storedWords.Add(word);
                    }
                    else
                    {
                        badLists++;
                        break;
                    }
                }
            }

            return (passphraseLists.Length - badLists).ToString();
        }

        public override string ToString()
        {
            return "Day 4";
        }
    }
}
