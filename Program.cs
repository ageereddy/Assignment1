using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }


        //method printTriangle returns the triangle based on the users input
        private static void printTriangle(int n)
        {
            try
            {
                int count= n-1;
                for (int i = 1; i <= n; i++)//outer loop to iterate for the position of the rows
                {
                    Console.Write(" ");
                    for (int j = 1; j <=count; j++)//for loop to arrange the spaces in the pyramid pattern
                     

                        Console.Write(" ");//adds spaces in the pyramid
                    
                    count--;
                    for (int K = 1; K <= 2 * i - 1; K++)//inner loop to print stars in the pyramid pattern
                        Console.Write("*");                   
                    Console.Write("\n");//enters new line after completion of inner loops

                }
 
            }
            catch (Exception)
            {

                throw;
            }

        }

 
 //method printPellSeries return the pell series number till the input value.
        private static void printPellSeries(int n2)
        {
            try
            {

                int firstnum = 0;//assigns first and second terms in the pell series i.e 0 and 1.
                int secondnum = 1;
                if (n2 == 1)//prints only one term in the pellseries if the input is 1
                {
                    Console.Write(firstnum + " ");//print first term in the pell series
                }
                else if (n2 == 2)//checks if the input is 2 and prints 2 numbers in the pell series
                {
                    Console.Write(firstnum + " ");// prints two terms in the series
                    Console.Write(secondnum + " ");
                }
                else
                {
                    Console.Write(firstnum + " ");
                    Console.Write(secondnum + " ");
                    for (int i = 1; i <= (n2 - 2); i++)//loop to iterate till the given input
                    {
                        int newterm;
                        newterm = 2 * secondnum + firstnum;//calculates the term in the pell series
                        firstnum = secondnum;//swaps the first and second terms in the series
                        secondnum = newterm;
                        Console.Write(secondnum + " ");//prints spaces between each terms in the pell series.

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        //Method squareSums chcek the all possible factors and provides the sum of squares of 2 factors by equating to the given input.
        private static bool squareSums(int n3)
        {
            try
            {
                for (int i = 1; i * i <= n3; i++)//outer loop to iterate till the given input
                {
                    for (int j = 1; j * j <= n3; j++)//inner loop to iterate for other factor
                        if (i * i + j * j == n3)//equates the sum of two factors to the given input
                        {
                            return true;//returns true if the factors square is equal to sum
                        }
                }
                return false;//returns false if no possibilty of the sum of squares.

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Method diffPairs returns all the distict pairs possible with the given difference
        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                HashSet<int> input = new HashSet<int>();//creates hashset with the input
                HashSet<int> result = new HashSet<int>();//creates hashset for the output
                if (k < 0)
                    return 0;
                for (int i = 0; i < nums.Length; i++)//loop to iterate over the input array
                {
                    if (input.Contains(nums[i]))
                        result.Add(nums[i]);
                    else
                        input.Add(nums[i]);
                }
                int count = 0;
                foreach (int val in input)
                {
                    if (input.Contains(val + k))//iterates over each value in the input and checks with contains
                        count++;// counters the pssible distinct pairs
                }
                if (k == 0)
                {
                    return result.Count;// returns the count of distinct possible pairs with the difference 
                }
                return count;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }


//method UniqueEmials returns the possible emails by removing periods and ignoring the characters after +.
        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                ISet<string> result = new HashSet<string>();//creates a hashset for storing the input of emails
                foreach (string email in emails)//iterates for each mail in list of mails
                {

                    string[] words = email.Split('@');//splits each mail with @ for domain name 
                    words[0] = words[0].Remove(words[0].IndexOf('+'));//removes the + and characters after the + in email.
                    words[0] = words[0].Replace(".", "");//Replaces the period with the empty space
                    words[0] = words[0].Trim();// trims the extra spaces
                    string final = words[0] + "@" + words[1];//combines the emails 
                    result.Add(final);
                }
                return result.Count;//returns the count of distinct emails in the list
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

//method DestCity returns the final destination in the given list
        private static string DestCity(string[,] paths)
        {
            try
            {
                string[] source = { paths[0, 0], paths[1, 0], paths[2, 0] };//stores all the sources from the list in a string
                string[] destination = { paths[0, 1], paths[1, 1], paths[2, 1] };//stores all the destinations from the list in a  string
                foreach (string i in destination)//iterats over the destinations
                { 
                    if (source.Contains(i) == false)//checks if the given destination is not in source
                    {
                        string final = i;
                        return final;//returns final destination.
                    }
                }

                return "";



            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}
