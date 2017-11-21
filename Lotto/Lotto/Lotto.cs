using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        public int[] OrderLottoNumbers(int[] originalLine, int[] newLine)
        {
            return new int[] {0};
        }

    }
}
