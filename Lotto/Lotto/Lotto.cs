using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Concurrent;

namespace Lotto
{
    [TestClass]
    public class Lotto
    {
        [TestMethod]
        public void TestMethod1()
        {
            CollectionAssert.AreEqual(new int[] { 1, 7, 19, 27, 28, 34 }, OrderLottoNumbers(new int[] { 1, 27, 28 }, new int[] { 7, 19, 34 }));
        }

        public int[] OrderLottoNumbers(int[] originalLine, int[] newNumbers)
        {
            int ok = 0;
            for (int i = 0; i < newNumbers.Length; i++)
            {
                for (int j = 0; j < originalLine.Length; j++)
                {
                    if (ok == 1)
                        break;
                    if (newNumbers[i] < originalLine[j])
                    {
                        originalLine = InsertNewNumber(originalLine, j, newNumbers[i]);
                        ok = 1;
                        break;
                    }
                    if(i == newNumbers.Length-1)
                    {
                        originalLine = InsertNewNumber(originalLine, originalLine.Length-1, newNumbers[i]);
                        ok = 1;
                    }
                }
                ok = 0;
            }
            return originalLine;
        }

        [TestMethod]
        public void TestInsertion()
        {
            CollectionAssert.AreEqual(new int[] { 1, 7, 14, 15}, InsertNewNumber(new int[] { 1, 7, 14 }, 2, 15));
        }

        public int[] InsertNewNumber(int[] originalLine, int maxIndex, int numberToBeInserted)
        {
            if (maxIndex == originalLine.Length - 1)
            {
                Array.Resize(ref originalLine, originalLine.Length + 1);
                originalLine[originalLine.Length - 1] = numberToBeInserted;
                return originalLine;
            }
            int[] newLine = new int [originalLine.Length+1];
            for (int i = 0; i < newLine.Length; i++)
            {
                if (i == maxIndex)
                    newLine[i] = numberToBeInserted;
                if (i < maxIndex)
                    newLine[i] = originalLine[i];
                if (i > maxIndex)
                    newLine[i] = originalLine[i-1];
            }
            return newLine;
        }
    }
}
