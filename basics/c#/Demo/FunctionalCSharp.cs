using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using System.Linq;

namespace CSharpClassLibrary
{
    [TestFixture]
    public class FunctionalCSharp
    {
        [Test]
        public void ReturnsListOfEvenNumbers()
        {
            IEnumerable<int> nums = Enumerable.Range(1,100);

            IEnumerable<int> evenNums = nums.Where(i => i%2 == 0);

            evenNums.ToList().ForEach(i => Console.Write("i = {0},"));
            
            IEnumerable<string> evenNumStr = nums.Where(i => i % 2 == 0).Select(i => String.Format(" i = {0},", i));

            Console.Out.WriteLine(string.Join("", evenNumStr.ToArray()));
        }

        [Test]
        public void SumOfSquares() 
        {
            Console.Out.WriteLine("sum = {0}", Enumerable.Range(1, 100).Select(i => i * i).Sum());

        }

        [Test]
        public void SumOfCubes()
        {
            Console.Out.WriteLine("sum = {0}", Enumerable.Range(1, 100).Select(i => i * i * i).Sum());

        }

    }
}