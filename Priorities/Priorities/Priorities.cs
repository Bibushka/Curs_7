using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Priorities
{
    [TestClass]
    public class Priorities
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] original = new string[] { "M", "L", "M", "L", "H", "L", "M", "H", "M" };
            string[] result = new string[] { "H", "H", "M", "M", "M", "M", "L", "L", "L" };
            CollectionAssert.AreEqual(result, SortPriority(original));
        }

        public string[] SortPriority(string[] originalString)
        {
            return NumbersToLetters(OrderNumbers(LettersToNumbers(originalString), 0, originalString.Length-1));
        }

        public int[] LettersToNumbers(string[] originalString)
        {
            int[] originalInt = new int[originalString.Length];
            for (int i = 0; i < originalString.Length; i++)
                switch (originalString[i])
                {
                    case "H": originalInt[i] = 1; break;
                    case "M": originalInt[i] = 2; break;
                    case "L": originalInt[i] = 3; break;
                }
            return originalInt;
        }

        public string[] NumbersToLetters(int[] originalInt)
        {
            string[] originalString = new string[originalInt.Length];
            for (int i = 0; i < originalInt.Length; i++)
                switch (originalInt[i])
                {
                    case 1: originalString[i] = "H"; break;
                    case 2: originalString[i] = "M"; break;
                    case 3: originalString[i] = "L"; break;
                }
            return originalString;
        }

        [TestMethod]
        public void OrderTest()
        {
            int[] numbers = new int[] { 2, 1, 2, 0, 3 };
            CollectionAssert.AreEqual(new int[] { 0, 1, 2, 2, 3 }, OrderNumbers(numbers, 0, numbers.Length-1));
        }

        public int[] OrderNumbers(int[] original, int i, int j)
        {
            if (j == 0)
                return original;
            int temp;
            int first = i;
            int last = j;
            int middle = (first + last) / 2;
            while (first <= last)
            {
                while (original[first] < original[middle])
                    first++;
                while (original[last] > original[middle])
                    last--;
                if (first <= last)
                {
                    temp = original[first];
                    original[first] = original[last];
                    original[last] = temp;
                    first++;
                    last--;
                }
            }
            if (j < last)
            {
                return OrderNumbers(original, j, last);
            }

            if (first < i)
            {
                return OrderNumbers(original, first, i);
            }
            return original;
        }
    }
}
