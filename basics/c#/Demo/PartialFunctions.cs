using System;
using NUnit.Framework;

namespace CSharpClassLibrary
{
    [TestFixture]
    public class PartialFunctions
    {
        [Test]
        public void PartialAdd()
        {
            Func<int,int,int> normalAdd = (a,b) => a + b;

//            normalAdd(10);

            Func<int, Func<int, int>> add = ((a) => (b => (a + b)));

            var add10 = add(10);

            Console.Out.WriteLine("add10 20 = {0}", add10(20));
        }
    }
}