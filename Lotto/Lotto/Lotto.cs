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
            CollectionAssert.AreEqual(new int[] { 1, 7, 19, 27, 28, 34 }, OrderLottoNumbers(new int[] { 1, 27, 28 }, new int[] { 7, 19, 34 }, 0));
        }

        public int[] OrderLottoNumbers(int[] originalLine, int[] newNumbers, int i)
        {
            if (i == newNumbers.Length)
                return originalLine;
            return OrderLottoNumbers(InsertNewNumber(originalLine, newNumbers[i]), newNumbers, i + 1);
        }
        
        public int[] InsertNewNumber(int[] originalLine, int number)
        {
            int temp;
            Array.Resize(ref originalLine, originalLine.Length + 1);
            originalLine[originalLine.Length - 1] = number;
            for (int i = 0; i < originalLine.Length; i++)
                for (int j = 0; j < originalLine.Length - 1; j++)
                    if (originalLine[j] > originalLine[j + 1])
                    {
                        temp = originalLine[j + 1];
                        originalLine[j + 1] = originalLine[j];
                        originalLine[j] = temp;
                    }
            return originalLine;
        }
    }
}
