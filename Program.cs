using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Exercises
    {
        static void Main(string[] args)
        {

            //EXERCISE 1
            ValidateInputNumber();
            MethodSeparator();

            //EXERCISE 2
            DisplayMaxNumber();
            MethodSeparator();

            //EXERCISE 3
            DisplayImageOrientation();
            MethodSeparator();

            //EXERCISE 4
            DisplaySpeed();
            MethodSeparator();

            //EXERCISE 5
            DisplayNumbersDivisibleBy();
            MethodSeparator();

            //EXERCISE 6
            SumOfInputNumbers();
            MethodSeparator();

            //EXERCISE 7
            DisplayFactorial();
            MethodSeparator();

            //EXERCISE 8
            GuessingGame();
            MethodSeparator();

            //EXERCISE 9
            DisplayMaxFromASeriesOfNumbers();
            MethodSeparator();

            //EXERCISE 10
            CheckAndDisplayTotalLikes();
            MethodSeparator();

            //EXERCISE 11
            DisplayReversedName();
            MethodSeparator();

            //EXERCISE 12
            SortNumbers();
            MethodSeparator();

            //EXERCISE 13
            GetUniqueNumbers();
            MethodSeparator();

            //EXERCISE 14
            GetSmallestThreeNumbers();
            MethodSeparator();

            //EXERCISE 15
            CheckNumbersConsecutiveness();
            MethodSeparator();

            //EXERCISE 16
            CheckDuplicates();
            MethodSeparator();

            //EXERCISE 17
            DisplayTime();
            MethodSeparator();

            //EXERCISE 18
            DisplayPascalCaseNotation();
            MethodSeparator();

            //EXERCISE 19
            DisplayVowelsCounter();
            MethodSeparator();

            //EXERCISE 20
            var path = @"C:\Users\Traian\Desktop\test.txt";
            ReadTextFile(path);
            MethodSeparator();

            //EXERCISE 21
            DisplayLongestWord(path);
        }

        /*Exercise 1
        Write a program and ask the user to enter a number. The number should be between 1 to 10.
        If the user enters a valid number, display "Valid" on the console. Otherwise, display "Invalid".
        */
        public static void ValidateInputNumber()
        {
            Console.Write("Enter a number: ");
            var input1 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input1))
                return;

            var number = Convert.ToInt32(input1);
            if (IsValidNumber(number))
                Console.WriteLine("{0} is a valid number", number);
            else
                Console.WriteLine("{0} is an invalid number", number);
        }

        private static bool IsValidNumber(int number)
        {
            return number > 0 && number <= 10;
        }

        /*Exercise 2
        Write a program which takes two numbers from the console and displays the maximum of the two.
        */
        public static void DisplayMaxNumber()
        {
            Console.WriteLine("Enter a first and second number below:");
            Console.Write("First: ");
            var firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Second: ");
            var secondNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Max is " + GetMaxNumber(firstNumber, secondNumber));
        }

        private static int GetMaxNumber(int num1, int num2)
        {
            return (num1 > num2) ? num1 : num2;
        }

        /*Exercise 3
        Write a program and ask the user to enter the width and height of an image. Then tell if the image is landscape or portrait.
        */
        public static void DisplayImageOrientation()
        {
            Console.WriteLine("Enter the width and height of an image:");
            Console.Write("Width: ");
            var width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Height: ");
            var height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Image orientation is " + CheckImageOrientation(width, height));
        }

        private static ImageOrientation CheckImageOrientation(int width, int height)
        {
                return (width > height) ? ImageOrientation.Landscape : ImageOrientation.Portrait;
        }

        public enum ImageOrientation
        {
            Landscape,
            Portrait
        }

        /*Exercise 4
        Write a program that asks the user to enter the speed limit. Once set, the program asks for the speed of a car.
        If the user enters a value less than the speed limit, program should display Ok on the console.
        If the value is above the speed limit, the program should calculate the number of demerit points.
        For every 5km/hr above the speed limit, 1 demerit points should be incurred and displayed on the console.
        If the number of demerit points is above 12, the program should display License Suspended.
        */
        public static void DisplaySpeed()
        {
            Console.WriteLine("Checking speed..");
            Console.Write("Speed limit: ");
            var speedLimit = Convert.ToInt32(Console.ReadLine());

            Console.Write("Car speed: ");
            var carSpeed = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(CheckSpeed(speedLimit, carSpeed));
        }

        private static string CheckSpeed(int speedLimit, int carSpeed)
        {
            if (carSpeed < speedLimit)
                return "Speed OK.";

            var demeritPoints = (carSpeed - speedLimit) / 5;
            if (demeritPoints > 12.0)
                return "License Suspended.";

            return "Demerit points acumulated: " + demeritPoints;
        }

        /*Exercise 5
        Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. Display the count on the console.
        */
        public static void DisplayNumbersDivisibleBy()
        {
            Console.WriteLine("Checking divisibility...");
            Console.Write("Enter a number: ");
            var upperLimit = Convert.ToInt32(Console.ReadLine());
            Console.Write("Divisible by: ");
            var number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("There are {0} numbers between 1 and {1} which are divisible by {2}", CountNumbersFromRangeDivisibleBy(number, upperLimit), upperLimit, number);
        }

        private static int CountNumbersFromRangeDivisibleBy(int num, int range)
        {
            var count = 0;
            for (var i = 1; i <= range; i++)
            {
                if (i % num == 0)
                    count++;
            }

            return count;
        }

        /* Exercise 6
        Write a program and continuously ask the user to enter a number or "ok" to exit. 
        Calculate the sum of all the previously entered numbers and display it on the console.
        */
        private static void SumOfInputNumbers()
        {
            var sum = 0;
            while (true)
            {
                Console.Write("Enter a number or 'ok' to exit: ");
                var input = Console.ReadLine();
                if (input.ToLower() == "ok" || string.IsNullOrWhiteSpace(input))
                    break;
            
                sum += Convert.ToInt32(input);
                Console.WriteLine("Sum: " + sum);
            }
        }

        /* Exercise 7
        Write a program and ask the user to enter a number. Compute the factorial of the number and print it on the console. 
        */
        public static void DisplayFactorial()
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0}! = {1}", num, GetFactorialOf(num));
        }

        private static int GetFactorialOf(int number)
        {
            var factorial = 1;

            for (var i = number; i > 1; i--)
                factorial *= i;

            return factorial;
        }

        /* Exercise 8 
        Write a program that picks a random number between 1 and 10.Give the user 4 chances to guess the number.
        If the user guesses the number, display “You won"; otherwise, display “You lost".
        */
        private static void GuessingGame()
        {
            var random = new Random();
            var number = random.Next(1, 10);
            //Console.WriteLine("Random number: " + number);
            var isGuessed = false;
            for(var i = 4; i > 0; i--)
            {
                Console.WriteLine("Guess the number..");
                var input = Convert.ToInt32(Console.ReadLine());
                if (input == number)
                {
                    isGuessed = true;
                    Console.WriteLine("You won.");
                    break;
                }
            }
            if(!isGuessed)
                Console.WriteLine("You lost. The number was: " + number);
        }

        /* Exercise 9
        Write a program and ask the user to enter a series of numbers separated by comma. Find the maximum of the numbers and display it on the console.
        */
        public static void DisplayMaxFromASeriesOfNumbers()
        {
            Console.Write("Enter a series of numbers separated by comma: ");
            var nums = Console.ReadLine();
            Console.WriteLine("Max is: " + GetMaxNumberFromASeries(nums));
        }

        private static int GetMaxNumberFromASeries(string input)
        {
            var numbers = input.Split(',');
            
            var max = Convert.ToInt32(numbers[0]);
            foreach (var str in numbers)
            {
                var number = Convert.ToInt32(str);
                if (number > max)
                    max = number;
            }

            return max;
        }

        /* Exercise 10
        When you post a message on Facebook, depending on the number of people who like your post, Facebook displays different information.
        If no one likes your post, it doesn't display anything.
        If only one person likes your post, it displays: [Friend's Name] likes your post.
        If two people like your post, it displays: [Friend 1] and[Friend 2] like your post.
        If more than two people like your post, it displays: [Friend 1], [Friend 2] and[Number of Other People] others like your post.
        Write a program and continuously ask the user to enter different names, until the user presses Enter (without supplying a name).
        Depending on the number of names provided, display a message based on the above pattern.
        */
        private static void CheckAndDisplayTotalLikes()
        {
            var names = new List<string>();
            while (true)
            {
                Console.Write("Enter a name or hit 'Enter' to quit: ");
                var input = Console.ReadLine();
            
                if ( string.IsNullOrWhiteSpace(input))
                    break;
            
                names.Add(input);
            }
            
            if (names.Count > 2)
                Console.WriteLine("{0}, {1} and {2} other/s like your post", names[0], names[1], (names.Count - 2));
            else if (names.Count == 2)
                Console.WriteLine("{0} and {1} like your post", names[0], names[1]);
            else if (names.Count == 1)
                Console.WriteLine("{0} likes your post", names[0]);
            else
                Console.WriteLine();
        }

        /* Exercise 11
        Write a program and ask the user to enter their name. Use an array to reverse the name and then store the result in a new string. Display the reversed name on the console.
        */
        public static void DisplayReversedName()
        {
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Reversed name: " + ReverseNameInput(name));
        }

        private static string ReverseNameInput(string name)
        {
            //var charArray = name.ToCharArray();
            //Array.Reverse(charArray);
            var charArray = new char[name.Length];
            for (var i = name.Length; i > 0; i--)
                charArray[name.Length - i] = name[i - 1];
            
            return new string(charArray);
        }

        /*Exercise 12
        Write a program and ask the user to enter 5 numbers. If a number has been previously entered, display an error message and ask the user to re-try.
        Once the user successfully enters 5 unique numbers, sort them and display the result on the console.
        */
        private static void SortNumbers()
        {
            Console.WriteLine("Sorting...");
            /*var numbers = new int[5];
            for(var i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Enter 5 numbers..");
                var input = Convert.ToInt32(Console.ReadLine());

                if(Array.IndexOf(numbers, input) != -1)
                {
                    Console.WriteLine("The number has been previously entered. Please try again..");
                    i--;
                    continue;
                }
                numbers[i] = input;
            }

            Array.Sort(numbers);
            Console.WriteLine();

            foreach (var number in numbers)
            {
                Console.WriteLine("The numbers are: " + number);
            }*/

            var numbers = new List<int>();
            
            while (numbers.Count < 5)
            {
                Console.Write("Enter a number: ");
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    return;

                var number = Convert.ToInt32(input);
                if (numbers.Contains(number))
                {
                    Console.WriteLine("You've previously entered " + number);
                    continue;
                }
                numbers.Add(number);
            }
            
            numbers.Sort();

            Console.WriteLine("Sorted numbers: ");
            foreach (var number in numbers)
            {
                Console.Write(number);
                Console.Write(" ");

            }
            Console.WriteLine();
        }

        /*Exercise 13
        Write a program and ask the user to continuously enter a number or type "Quit" to exit.
        The list of numbers may include duplicates.Display the unique numbers that the user has entered.
        */
        private static void GetUniqueNumbers()
        {
            var numbers = new List<int>();
            while (true)
            {
                Console.Write("Enter a number or type 'Quit' to exit (or hit 'enter'): ");
                var input = Console.ReadLine();
            
                if (input.ToLower() == "quit" || string.IsNullOrWhiteSpace(input))
                    break;
            
                numbers.Add(Convert.ToInt32(input));
            }
            
            var uniqueNumbers = numbers.Distinct().ToList();

            Console.Write("Unique Numbers: ");
            foreach (var number in uniqueNumbers)
            {
                Console.Write(number);
                Console.Write(" ");
            }
            Console.WriteLine();
        }


        /* Exercise 14
        Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10).
        If the list is empty or includes less than 5 numbers, display "Invalid List" and ask the user to re-try; otherwise, display the 3 smallest numbers in the list.
        */
        private static void GetSmallestThreeNumbers()
        {
            Console.Write("Enter a list of numbers (at least 5) separated by comma: ");

            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    return;

                var numbers = input.Split(',');
            
                if (numbers.Length < 5)
                {
                    Console.Write("Invalid List. Please retry: ");
                    continue;
                }
            
                Array.Sort(numbers);

                Console.Write("Smallest three numbers are:");
                for (var i = 0; i < 3; i++)
                {
                    Console.Write(numbers[i]);
                }
                break;
            }

            Console.WriteLine();
        }

        /*Exercise 15
        Write a program and ask the user to enter a few numbers separated by a hyphen. Work out if the numbers are consecutive.
        For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", display a message: "Consecutive"; otherwise, display "Not Consecutive".
        */
        private static void CheckNumbersConsecutiveness()
        {
            Console.Write("Enter a few numbers separated by a hyphen: ");

            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return;

            var numbers = new List<int>();
            
            foreach (var number in input.Split('-'))
            {
                numbers.Add(Convert.ToInt32(number));
            }
            numbers.Sort();
            
            var isConsecutive = true;
            for (var i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] != numbers[i - 1] + 1)
                {
                    isConsecutive = false;
                    break;
                }
            }
            
            var message = isConsecutive ? "consecutive" : "NOT consecutive";
            Console.WriteLine("Numbers are " + message);
        }

        /* Exercise 16
        Write a program and ask the user to enter a few numbers separated by a hyphen.
        If the user simply presses Enter, without supplying an input, exit immediately; otherwise, check to see if there are duplicates. If so, display "Duplicate" on the console.
        */
        public static void CheckDuplicates()
        {
            Console.Write("Enter a few numbers separated by a hyphen: ");
            var input = Console.ReadLine();
            Console.WriteLine("Duplicate Numbers? " + AreDuplicateNumbers(input));
        }

        private static bool AreDuplicateNumbers(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            var numbers = new List<int>();

            foreach (var number in input.Split('-'))
            {
                numbers.Add(Convert.ToInt32(number));
            }

            var unique = new List<int>();

            foreach (var number in numbers)
            {
                if (unique.Contains(number))
                    return true;

                 unique.Add(number);
            }

            return false;
        }


        /* Exercise 17
        Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00).
        A valid time should be between 00:00 and 23:59. If the time is valid, display "Ok"; otherwise, display "Invalid Time".
        If the user doesn't provide any values, consider it as invalid time.
        */
        public static void DisplayTime()
        {
            Console.Write("Enter a time value in the 24-hour time format (e.g. 19:00): ");
            var time = Console.ReadLine();
            if (IsValidTime(time))
                Console.WriteLine(time + " Ok");
        }

        private static bool IsValidTime(string time)
        {
            if (string.IsNullOrWhiteSpace(time))
            {
                Console.WriteLine("Invalid time.");
                return false;
            }

            var components = time.Split(':');
            if (components.Length != 2)
            {
                Console.WriteLine("Invalid time: " + time);
                return false;
            }

            try
            {
                var hour = Convert.ToInt32(components[0]);
                var minutes = Convert.ToInt32(components[1]);

                if (hour >= 0 && hour <= 23 && minutes >= 0 && minutes <= 59)
                    return true;
                Console.WriteLine("Invalid time: " + time);
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid time: " + time);
                return false;
            }
        }

        /* Exercise 18
        Write a program and ask the user to enter a few words separated by a space. Use the words to create a variable name with PascalCase.
        For example, if the user types: "number of students", display "NumberOfStudents". Make sure that the program is not dependent on the input.
        So, if the user types "NUMBER OF STUDENTS", the program should still display "NumberOfStudents".
        */
        public static void DisplayPascalCaseNotation()
        {
            Console.Write("Enter a few words separated by a space: ");
            var words = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(words)) return;
            Console.WriteLine("Pascal Case Notation: " + GetPascalCaseNotation(words));
        }

        private static string GetPascalCaseNotation(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";

            var variableName = "";
            foreach (var word in input.Split(' '))
            {
                var wordWithPascalCase = char.ToUpper(word[0]) + word.Substring(1).ToLower();
                variableName += wordWithPascalCase;
            }

            return variableName;
        }

        /* Exercise 19
        Write a program and ask the user to enter an English word. Count the number of vowels (a, e, o, u, i) in the word.
        So, if the user enters "inadequate", the program should display 6 on the console.
        */
        public static void DisplayVowelsCounter()
        {
            Console.Write("Insert an eglish word: ");
            var word = Console.ReadLine().ToLower();
            var vowelsCounter = GetVowelsCount(word);
            Console.WriteLine("{0} vowel/s in '{1}': ", vowelsCounter, word);
        }

        private static int GetVowelsCount(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            var vowels = new[] { 'a', 'e', 'o', 'u', 'i' };
            var vowelsCounter = 0;

            foreach (var str in input)
            {
                if (vowels.Contains(str))
                    vowelsCounter++;
            }

            return vowelsCounter;
        }

        /* Exercise 20
        Write a program that reads a text file and displays the number of words.
        */
        private static void ReadTextFile(string path)
        {
            File.WriteAllText(path,"This is my test file for all the I/O operations : creating, reading, writing and deleting the file.");
            var text = File.ReadAllText(path);
            var totalWords = 0;
            foreach (var txt in text.Split(' '))
            {
                totalWords++;
            }
            Console.WriteLine("File Text: "+ text);
            Console.WriteLine("Total words: " + totalWords);
        }

        /* Exercise 21
        Write a program that reads a text file and displays the longest word in the file
        */

        public static void DisplayLongestWord(string path)
        {
            var text = File.ReadAllText(path);
            var longestWord = GetLongestWord(text);
            Console.WriteLine("The longest word in file: " + longestWord);
        }

        private static string GetLongestWord(string text)
        {
            var words = text.Split(' ');
            var longestWord = words[0];

            foreach (var word in words)
            {
                if (word.Length > longestWord.Length)
                    longestWord = word;
            }

            return longestWord;
        }

        private static void MethodSeparator()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
        }
    }
}
