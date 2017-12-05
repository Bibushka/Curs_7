using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Priorities
{
    public enum TypesOfPriorities
    {
        High = 1,
        Medium = 2,
        Low = 4,
    }

    public struct Product
    {
        public TypesOfPriorities priority;
        public string description;

        public Product(TypesOfPriorities priority, string description)
        {
            this.priority = priority;
            this.description = description;
        }
    }

    [TestClass]
    public class Priorities
    {
        [TestMethod]
        public void TestMethod1()
        {
            Product samsung = new Product (TypesOfPriorities.High, "bad condition");
            Product iPhone = new Product (TypesOfPriorities.High, "cracked display");
            Product LG = new Product (TypesOfPriorities.Low, "needs screen protection");
            Product huawei = new Product (TypesOfPriorities.Medium, "battery replacement");
            TypesOfPriorities[] result = new TypesOfPriorities[] { TypesOfPriorities.High,
                TypesOfPriorities.High, TypesOfPriorities.Medium, TypesOfPriorities.Low };
            Product[] cases = new Product[] { samsung, iPhone, LG, huawei };
            CollectionAssert.AreEqual(result, SortPriority(cases));
        }

        public TypesOfPriorities[] SortPriority(Product[] cases)
        {
            int[] levelsOfPriority = ConvertEnumToInt(cases);
            levelsOfPriority = OrderNumbers(levelsOfPriority, 0, levelsOfPriority.Length-1);
            return ConvertIntToEnum(levelsOfPriority);
        }

        public int[] ConvertEnumToInt(Product[] cases)
        {
            int[] ints = new int[0];
            for (int i = 0; i < cases.Length; i++)
                ints[i] = (int)cases[i].priority;
            return ints;
        }

        public TypesOfPriorities[] ConvertIntToEnum(int[] levelsOfPriority)
        {
            TypesOfPriorities[] enums = new TypesOfPriorities[0];
            for(int i = 0; i < levelsOfPriority.Length; i++)
                switch (levelsOfPriority[i])
                {
                    case 1: enums[i] = TypesOfPriorities.High; break;
                    case 2: enums[i] = TypesOfPriorities.Medium; break;
                    case 4: enums[i] = TypesOfPriorities.Low; break;
                }
            return enums;
        }

        [TestMethod]
        public void OrderTest()
        {
            int[] numbers = new int[] { 2, 2, 0, 3, 5, 0, 7};
            CollectionAssert.AreEqual(new int[] { 0, 0, 2, 2, 3, 5, 7 }, OrderNumbers(numbers, 0, numbers.Length - 1));
        }

        public int[] OrderNumbers(int[] original, int i, int j)
        {
            if (ExitCondition(original))
                return original;
            int temp;
            int first = i;
            int last = j;
            int middle = original[((first + last) / 2)+1];
            while (first <= last)
            {
                while (original[first].CompareTo(middle) < 0)
                    first++;
                while (original[last].CompareTo(middle) > 0)
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
            return OrderNumbers(original, i, j);
        }

        public bool ExitCondition(int[] original)
        {
            int ok = 0;
            for (int i = 0; i < original.Length - 2; i++)
                if (original[i] > original[i + 1])
                    ok = 1;
            if (ok == 1)
                return false;
            return true;
        }
    }
}
