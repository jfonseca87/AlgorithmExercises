using System.Diagnostics;
using System;
using System.Text.RegularExpressions;
using System.Text;

namespace AlgorithmExercises
{
    public class MergeNames
    {
        public static string[] UniqueNames(string[] names1, string[] names2)
        {
            return names1.Concat(names2).Distinct().ToArray();
        }

        // public static void Main(string[] args)
        // {
        //     string[] names1 = new string[] { "Ava", "Emma", "Olivia" };
        //     string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };
        //     Console.WriteLine(string.Join(", ", MergeNames.UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia
        // }
    }

    public class SortedSearch
    {
        //public static int CountNumbers(int[] sortedArray, int lessThan)
        //{
        //    return sortedArray.Where(number => number < lessThan).Count();
        //}

        public static int CountNumbers(int[] sortedArray, int lessThan)
        {
            int counter = 0;
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (sortedArray[i] <= lessThan)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }
            return counter;
        }

        // public static void Main(string[] args)
        // {
        //     Console.WriteLine(SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4));
        // }
    }

    public class DateFunctions
    {
        public void DateFunction()
        {
            DateTime newStartDate = new DateTime(2023, 8, 16);
            DateTime newEndDate = new DateTime(2023, 8, 23);
            DateTime DBStartDate = new DateTime(2023, 8, 14);
            DateTime DBEndDate = new DateTime(2023, 8, 18);

            //if (newStartDate >= DBStartDate || newEndDate <= DBEndDate)
            //{
            //    Console.WriteLine("newStartDate and newEndDate are within the DBStartDate and DBEndDate range.");
            //}

            string input = "//;##11;11";
            string pattern = @"\/\/(.*?)#";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string customDelimiter = match.Groups[1].Value;
                Console.WriteLine($"Custom delimiter: {customDelimiter}");
            }

            Console.ReadLine();
        }
    }

    public class SumaMaximaExercise
    {
        public void Exercise()
        {
            // int[] numbers = new int[] { 4, -3, 5, -2, -1, 2, 6, -2 };
            int[] numbers = GenerateRamdomNumbers(10000);
            int sumaActual = 0;
            int maximaSuma = 0;
            Stopwatch sw = new Stopwatch();

            // excersice way one
            sw.Start();
            for (int i = 0; i < numbers.Length; i++)
            {
                sumaActual += numbers[i];
                if (sumaActual > maximaSuma)
                {
                    maximaSuma = sumaActual;
                }
            }
            sw.Stop();
            Console.WriteLine($"El resultado de la opcion uno es: {maximaSuma} y tardó: {sw.ElapsedTicks}");
            Console.WriteLine("");

            // excersice way two
            sw.Start();
            maximaSuma = TotalSum(numbers);
            sw.Stop();
            Console.WriteLine($"El resultado de la opcion dos es: {maximaSuma} y tardó: {sw.ElapsedTicks}");
            Console.ReadLine();
        }

        int[] GenerateRamdomNumbers(int quantity)
        {
            int[] numbers = new int[0];
            for (int i = 0; i < quantity; i++)
            {
                numbers[i] = new Random().Next(-100, 100);
            }

            return numbers;
        }

        int TotalSum(int[] numbers, int sumaMaxima = 0, int sumaActual = 0, int pos = 0)
        {
            if (pos == (numbers.Length - 1))
            {
                return sumaMaxima;
            }

            sumaActual += numbers[pos];

            if (sumaActual > sumaMaxima)
            {
                sumaMaxima = sumaActual;
            }

            pos += 1;
            return TotalSum(numbers, sumaMaxima, sumaActual, pos);
        }
    }

    internal class StringCalculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var asd = Add("//[abc][****]#45abc99****16");

            Console.ReadLine();
        }

        public static int Add(string numbers)
        {
            string oneDelimiterPattern = @"^\/\/(.*?)#";
            Match oneDelimiterMatch = Regex.Match(numbers, oneDelimiterPattern);
            string delimiter = oneDelimiterMatch.Groups[1].Value;
            string[] moreThanOneDelimiterParts = numbers.Split(new string[] { "//[", "][", "]#" }, StringSplitOptions.RemoveEmptyEntries);
            int lastPosition = numbers.LastIndexOf('#');
            string stringNumbers = numbers.Substring((lastPosition + 1));

            string[] numbersArray = new string[] { };
            if (moreThanOneDelimiterParts.Length == 1)
            {
                numbersArray = stringNumbers.Split(delimiter == "" ? "," : delimiter);
            }
            else
            {
                string commonDelimiter = "@@@";
                stringNumbers = stringNumbers.Replace(moreThanOneDelimiterParts[0], commonDelimiter)
                                             .Replace(moreThanOneDelimiterParts[1], commonDelimiter);
                numbersArray = stringNumbers.Split(commonDelimiter);
            }

            int total = 0;
            for (int i = 0; i < numbersArray.Length; i++)
            {
                int.TryParse(numbersArray[i], out int number);
                if (number < 0)
                {
                    throw new Exception("Negatives not allowed");
                }

                total += number > 1000 ? 0 : number;
            }

            return total;
        }
    }

    internal class StairProblem
    {
        static void Main(string[] args)
        {
            var asnwer = Solution(6);
            Console.WriteLine("Hello World!");
        }

        public static long Solution(long n)
        {
            if (n <= 2)
                return n;
            if (n == 3)
                return 4;

            int[] ways = new int[n + 1];
            ways[0] = 1;
            ways[1] = 1;
            ways[2] = 2;
            ways[3] = 4;

            for (int i = 4; i <= n; i++)
            {
                var a = ways[i - 1];
                var b = ways[i - 2];
                var c = ways[i - 3];

                ways[i] = ways[i - 1] + ways[i - 2] + ways[i - 3];
            }

            return ways[n];
        }
    }

    internal class RoundedGradesProblem
    {
        static void Main(string[] args)
        {
            List<int> grades = new List<int> { 4, 73, 67, 38, 33 };
            var result = RoundGrades(grades);
        }

        static List<int> RoundGrades(List<int> grades)
        {
            List<int> roundedGrades = new List<int>();
            grades.RemoveAt(0);

            foreach (int grade in grades)
            {
                if (grade < 38)
                {
                    roundedGrades.Add(grade);
                }
                else
                {
                    int closestFiveMultiply = (int)Math.Ceiling(grade / 5.0) * 5;
                    roundedGrades.Add((closestFiveMultiply - grade) < 3
                        ? closestFiveMultiply
                        : grade);
                }
            }

            return roundedGrades;
        }
    }

    internal class ApplesAndOrangesCloseHome
    {
        static void Main(string[] args)
        {
            CountApplesAndOranges(7, 11, 5, 15, new List<int> { -2, 2, 1 }, new List<int> { 5, -6 });
            Console.ReadKey();
        }

        public static void CountApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            apples = apples.Select(apple => apple + a).ToList();
            oranges = oranges.Select(apple => apple + b).ToList();

            int applesInTomHouse = 0;
            int orangesInTomHouse = 0;

            foreach (int apple in apples)
            {
                if (apple >= s && apple <= t)
                {
                    applesInTomHouse++;
                }
            }

            foreach (int orange in oranges)
            {
                if (orange >= s && orange <= t)
                {
                    orangesInTomHouse++;
                }
            }

            Console.WriteLine($"{applesInTomHouse}\n{orangesInTomHouse}");
        }
    }

    internal class KangarooJumps
    {
        static void Main(string[] args)
        {
            var result = kangaroo(0, 2, 5, 3);
            Console.ReadKey();
        }

        public static string kangaroo(int x1, int v1, int x2, int v2)
        {
            int v1t = x1 + v1;
            int v2t = x2 + v2;
            string samePosition = "NO";

            for (int i = 0; i < 12000; i++)
            {
                if (v1t == v2t)
                {
                    samePosition = "YES";
                    break;
                }

                v1t += v1;
                v2t += v2;
            }

            return samePosition;
        }
    }

    internal class ClosestTemperatureProblem
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 2;
            int c = a / b;

            int response = ClosetTemperature(null);
            Console.ReadKey();
        }

        static int ClosetTemperature(int[] ts)
        {
            if (ts is null || !ts.Any())
            {
                return 0;
            }

            int closest = ts[0];
            foreach (int t in ts)
            {
                int a = Math.Abs(t);
                int b = Math.Abs(closest);

                if (a < b)
                {
                    closest = t;
                }
                else if (a == b && t > closest)
                {
                    closest = t;
                }
            }

            return closest;
        }
    }

    internal class RepeatedWordsProblem
    {
        static void Main(string[] args)
        {
            var response = RepeatedWords("She wants to get money and she would like to also get a job");
        }

        static int[] RepeatedWords(string sentence)
        {
            string[] words = sentence.Split(' ');
            Dictionary<string, int> repeatedWords = new Dictionary<string, int>();
            foreach (string word in words)
            {

                if (repeatedWords.ContainsKey(word))
                    repeatedWords[word]++;
                else repeatedWords[word] = 1;
            }

            return repeatedWords.Select(x => x.Value)
                                .OrderBy(n => n)
                                .ToArray();
        }
    }

    internal class ThreadSafeProblem
    {
        static object lockCounter = new object();

        static void Main()
        {
            var asd = Convert.ToString(10, 2);

            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    ShowCounter();
                });
                threads[i].Start();
            }

            Console.ReadKey();
        }

        static void ShowCounter()
        {
            lock (lockCounter)
            {
                Console.WriteLine($"Thread No: {Thread.CurrentThread.ManagedThreadId}");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Number: {i + 1}");
                }
            }
        }
    }

    internal class SomeExercisesProblems
    {
        static void Main(string[] args)
        {
            // Reverse Sentence with the same white spaces as the original
            // var a = Something("codewars");
            // var b = Something("your code");
            // var c = Something("your code rocks"); // skco redo cruoy

            // Applying a Func as a filter to an array as a callback
            Func<int, bool> func = (value) => value % 2 == 0;
            var result = Something(new int[] { 2, 4, 6, 8, 1, 2, 5, 4, 3, 2 }, func);
        }

        static int Something(int x)
        {
            return Convert.ToString(x, 2).Count(c => c == '1');
        }

        static int Something(int start, int finish)
        {
            int diff = finish - start;
            var a = (diff / 3);
            var b = (diff % 3);
            return (diff / 3) + diff % 3;
        }

        static string Something(string s)
        {
            Stack<char> stack = new Stack<char>(s.Replace(" ", "").ToCharArray());
            StringBuilder sb = new StringBuilder();
            int currentEmptyIndex = s.IndexOf(' ');
            int i = 0;

            foreach (char c in stack)
            {
                if (i == currentEmptyIndex)
                {
                    sb.Append(' ');
                    currentEmptyIndex = s.IndexOf(' ', currentEmptyIndex + 1);
                    i++;
                }

                sb.Append(c);
                i++;
            }

            return sb.ToString();
        }

        public static int[] Something(int[] arr, Func<int, bool> pred)
        {
            return arr.Where(x => pred(x)).ToArray();
        }
    }

    internal class FactorProblem
    {
        static void Main(string[] args)
        {
            GetTotalX(new List<int> { 2, 6 }, new List<int> { 24, 36 });
        }

        static bool CheckF(List<int> v, int x)
        {
            for (int i = 0; i < v.Count; i++)
            {
                if (x % v[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckS(int x, List<int> v)
        {
            foreach (var i in v)
            {
                if (i % x != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int GetTotalX(List<int> a, List<int> b)
        {
            a.Sort();
            b.Sort();
            int cnt = 0;
            for (int i = a[0]; i <= b[1]; i++)
            {
                if (CheckF(a, i) && CheckS(i, b))
                {
                    cnt++;
                }
            }
            return cnt;
        }
    }

    internal class SomeExercisesProblemsTwo
    {
        public class Student
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        static void DoTask(ref int i)
        {
            i = 6;
        }

        //static void Main(string[] args)
        //{
        //    List<int> list = new List<int>();
        //    for (int i = 1; i <= 200; i++)
        //    {
        //        list.Add(i);
        //    }

        //    var result = GetEventNumbers(list, 3);
        //    foreach (var number in result)
        //    {
        //        Console.WriteLine(number);
        //    }
        //}

        static void Main(string[] args)
        {
            // Sample case 1
            // var result = CardsToBuy(new List<int> { 1, 3, 4 }, 7);
            // Sample case 2
            var result = CardsToBuy(new List<int> { 4, 6, 12, 8 }, 14);
            // Sample case 3 
            // var result = CardsToBuy(new List<int> { 1,2,3,4 }, 5);

            foreach (var card in result)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine("Process complete!");
            Console.ReadKey();
        }

        static List<int> GetEventNumbers(List<int> numbers, int maxnumbers)
        {
            return numbers.Where(n => n % 2 == 0).Take(maxnumbers).ToList();
        }

        static List<int> CardsToBuy(List<int> collection, int d)
        {
            List<int> cardsAdquired = new List<int>();
            // List<int> sortedCollection = collection.OrderBy(x => x).ToList();
            bool stillHavingMoney = true;
            int i = 0;

            while (stillHavingMoney)
            {
                i++;
                bool repeatedCard = collection.Any(c => c == i);
                stillHavingMoney = (cardsAdquired.Sum() + i) <= d;

                if (!repeatedCard && stillHavingMoney)
                {
                    cardsAdquired.Add(i);
                }
            }

            return cardsAdquired;
        }
    }

    class SomeExercisesProblemsThree
    {
        static void Main(string[] args)
        {
            // var numberArray = new int[] { 1, 99, 101, 15, 48, 2, 88, 34, 67, 10, 9, 5 };
            // var sortedArray = SortNumberArray(numberArray);

            //for (int i = 0; i < sortedArray.Length; i++)
            //{
            //    Console.WriteLine(sortedArray[i]);
            //}
            //List<List<int>> ints = new List<List<int>>
            //{
            //    new List<int> { 11, 2, 4 },
            //    new List<int> { 4, 5, 6 },
            //    new List<int> { 10, 8, -12 }
            //};

            //var result = DiagonalDifference(ints);

            //List<int> ints = new List<int> { -4, 3, -9, 0, 4, 1 };
            //PlusMinus(ints);

            // Staircase(6);

            // List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            //List<int> numbers = new List<int> { 256741038, 623958417, 467905213, 714532089, 938071625 };
            //MiniMaxSum(numbers);

            //List<int> numbers = new List<int> { 3, 2, 1, 3 };
            //Console.WriteLine(BirthdayCakeCandles(numbers));

            //string hour = "12:45:54PM";
            //Console.WriteLine(TimeConversion(hour));

            var people = FillPeopleTable();

            people
                .Where(x => x.IsDeleted != true)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Id));

            Console.ReadKey();
        }

        public static int DiagonalDifference(List<List<int>> arr)
        {
            int arrayDimension = arr[0].Count;
            int firstDiagonalResult = 0;
            int secondDiagonalResult = 0;

            for (int i = 0; i < arrayDimension; i++)
            {
                firstDiagonalResult += arr[i][i];
                secondDiagonalResult += arr[i][(arrayDimension - 1) - i];
            }

            return Math.Abs(firstDiagonalResult - secondDiagonalResult);
        }

        public static int[] SortNumberArray(int[] source)
        {
            int[] sortedArray = source;
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < sortedArray.Length; i++)
                {
                    if ((i + 1) == sortedArray.Length)
                    {
                        continue;
                    }

                    int currentNumber = sortedArray[i];
                    int nextNumber = sortedArray[i + 1];
                    if (nextNumber < currentNumber)
                    {
                        isSorted = false;
                        sortedArray[i] = nextNumber;
                        sortedArray[i + 1] = currentNumber;
                    }
                }
            }

            return sortedArray;
        }

        public static void PlusMinus(List<int> arr)
        {
            int arrayLength = arr.Count;
            int positiveNumbers = 0;
            int negativeNumbers = 0;
            int ceroNumbers = 0;

            for (int i = 0; i < arrayLength; i++)
            {
                int number = arr[i];
                if (number > 0)
                {
                    positiveNumbers += 1;
                }
                else if (number == 0)
                {
                    ceroNumbers += 1;
                }
                else if (number < 0)
                {
                    negativeNumbers += 1;
                }
            }

            Console.WriteLine(string.Format("{0:N6}", (decimal)positiveNumbers / arrayLength));
            Console.WriteLine(string.Format("{0:N6}", (decimal)negativeNumbers / arrayLength));
            Console.WriteLine(string.Format("{0:N6}", (decimal)ceroNumbers / arrayLength));
        }

        public static void Staircase(int n)
        {
            for (int i = 0; i < n; i++)
            {
                int position = i + 1;
                string template = $"{string.Empty.PadLeft(n - position, ' ')}{string.Concat(Enumerable.Repeat("#", position))}";
                Console.WriteLine(template);
            }
        }

        public static void MiniMaxSum(List<int> arr)
        {
            long minResult = long.MaxValue;
            long maxResult = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                long result = 0;
                for (int j = 0; j < arr.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    result += arr[j];
                }

                if (result < minResult)
                {
                    minResult = result;
                }

                if (result > maxResult)
                {
                    maxResult = result;
                }
            }

            Console.WriteLine($"{minResult} {maxResult}");
        }

        public static int BirthdayCakeCandles(List<int> candles)
        {
            Dictionary<int, int> countDict = new Dictionary<int, int>();
            int maxCount = 0;

            foreach (int candle in candles)
            {
                if (countDict.ContainsKey(candle))
                {
                    countDict[candle]++;
                }
                else
                {
                    countDict[candle] = 1;
                }

                if (countDict[candle] > maxCount)
                {
                    maxCount = countDict[candle];
                }
            }

            return maxCount;
        }

        public static string TimeConversion(string s)
        {
            Dictionary<string, string> formatHours = new Dictionary<string, string>
        {
            { "01", "13" },
            { "02", "14" },
            { "03", "15" },
            { "04", "16" },
            { "05", "17" },
            { "06", "18" },
            { "07", "19" },
            { "08", "20" },
            { "09", "21" },
            { "10", "22" },
            { "11", "23" },
            { "12", "00" },
        };

            string[] splittedHour = s.Split(':');
            bool isNightHour = (s.Contains("PM") && splittedHour[0] != "12") || (splittedHour[0].Equals("12") && s.Contains("AM"));
            string formattedHour = isNightHour
                ? splittedHour[0].Replace(splittedHour[0], formatHours[splittedHour[0]])
                : splittedHour[0];


            // string value = $"{formattedHour}:{splittedHour[1]}:{splittedHour[2].Replace("AM", string.Empty).Replace("PM", string.Empty)}";
            return string.Empty;
        }

        public static List<Person> FillPeopleTable()
        {
            return new List<Person>
        {
            new Person { Id = 1, Firstname = "Name1", Lastname = "Lastname1", IsDeleted = null },
            new Person { Id = 2, Firstname = "Name2", Lastname = "Lastname2", IsDeleted = null },
            new Person { Id = 3, Firstname = "Name3", Lastname = "Lastname3", IsDeleted = false },
            new Person { Id = 4, Firstname = "Name4", Lastname = "Lastname4", IsDeleted = true },
        };
        }

        public class Person
        {
            public int Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public bool? IsDeleted { get; set; }
        }
    }

    internal class ReverseArrayProblem
    {
        static void Main(string[] args)
        {
            List<int> array = new List<int>
            {
                1,
                4,
                3,
                2
            };

            List<int> result = ReverseArray(array);
        }

        public static List<int> ReverseArray(List<int> a)
        {
            List<int> newList = new List<int>();
            int arrayLength = a.Count;

            for (int i = arrayLength; i > 0; i--)
            {
                newList.Add(a[i - 1]);
            }

            return newList;
        }
    }
}