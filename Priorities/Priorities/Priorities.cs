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
            CollectionAssert.AreEqual(new string[] { "H", "H", "M", "M", "M", "M", "L", "L", "L"}, 
                SortPriority(new string[] {"M", "L", "M", "L", "H", "L", "M", "H", "M" }));
        }

        public string[] SortPriority(string[] originalString)
        {
            return new string[] {"0", "0"};
        }
    }
}
