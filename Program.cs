using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1_Summer2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:

            int[] arr = { 1, 2, 3, 1, 1, 3 };
            int gp = NumIdenticalPairs(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp);


            //Question 4:
            int[] arr1 = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4:");
            int pivot = PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();

        }

        
        private static bool JudgeCircle(string moves)
        {
            try
            {
                var dict = new Dictionary<char, int[]>();//dictionary declaration
                dict['R'] = new int[] { 1, 0 };//loading as co-ordiantes
                dict['L'] = new int[] { -1, 0 };
                dict['U'] = new int[] { 0, 1 };
                dict['D'] = new int[] { 0, -1 };

                int x = 0, y = 0;
                foreach (var move in moves)
                {//checking values
                    var step = dict[move];
                    x += step[0];
                    y += step[1];
                }

                if (x == 0 && y == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }


        private static bool CheckIfPangram(string s)
        {
            try

            {
                if (s.Length < 26) return false;
                //checking index of the word and adding to check the value
                for (var i = 1; i <= 26; i++)
                    if (s.IndexOf((char)(i + 96)) < 0)
                        return false;

                return true;

            }
            catch (Exception)
            {

                throw;
            }

        }


        /*

        <summary>
        Given an array of integers nums
        A pair (i,j) is called good if nums[i] == nums[j] and i < j.
        Return the number of good pairs.
        Example:
        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        return type : int
        </summary>
        <returns>int </returns>
        */

        private static int NumIdenticalPairs(int[] arr)

        {
            try
            {
                int ans = 0;
                //running through first element
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    //running through the next element
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] == arr[j])//checking if condition is same or not.
                            ans++;
                    }
                }
                return ans;


            }
            catch (Exception)
            {

                throw;
            }
        }





        
        private static int PivotIndex(int[] nums)

        {
            try
            {
                if (nums.Length == 0)//checking if length is zero
                    return -1;
                int sum = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];//adding the values to check with pivot
                }
                int secondSum = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    sum -= nums[i];//subtracting the sum
                    if (sum == secondSum)
                        return i;
                    secondSum += nums[i];
                }
                return -1;

            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

       

        private static string MergeAlternately(string word1, string word2)
        {
            try
            {
                int i = 0, j = i + 1, k = 0;
                char[] c = new char[word1.Length + word2.Length];


                while (i < c.Length)//checking for length of the string
                {
                    if (i < word1.Length)//checking if i is less than length of the word
                    {
                        c[k] = word1[i];
                    }
                    else
                    {
                        break;
                    }

                    if (i < word2.Length)//checking for next word
                    {
                        c[k + 1] = word2[i];
                    }
                    else
                    {
                        break;
                    }
                    i++;
                    k += 2;
                }
                //combining both and returning the result
                for (; i < word1.Length; i++)
                {
                    c[k++] = word1[i];
                }

                for (; i < word2.Length; i++)
                {
                    c[k++] = word2[i];
                }


                return new string(c);
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }
       
        private static string ToGoatLatin(string sentence)
{

    try

    {
                StringBuilder sb = new StringBuilder();
                string[] arr = sentence.Split(' ');
                char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
                int aCount = 1;
                //checking if there are vowels in the string and replacing them.
                foreach (string s in arr)
                {
                    StringBuilder nsb = new StringBuilder();

                    if (vowels.Contains(char.ToLower(s[0])))
                        nsb.Append(s);
                    else
                        nsb.Append(s.Substring(1)).Append(s[0]);

                    nsb.Append("ma").Append(new string('a', aCount));
                    sb.Append(nsb).Append(' ');

                    aCount++;
                }

                return sb.ToString().TrimEnd();

            }
    catch (Exception)
    {

        throw;
    }


}


}
}