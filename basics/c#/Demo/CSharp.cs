using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace CSharpClassLibrary
{
    [TestFixture]
    public class CSharp
    {
        private List<int> GetListOf(int n)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
                list.Add(i + 1);
            return list;
        }

        [Test]
        public void ReturnsListOfEvenNumbers()
        {
            var list = new List<int>();

            for (int i = 0; i < 100; i++) list.Add(i + 1);

            List<int> evenInts = GetEvenInts(list);

            foreach (var i in evenInts) Console.Out.Write("i = {0}, ", i);
        }

        private List<int> GetEvenInts(List<int> list)
        {
            var evenInts = new List<int>();

            foreach (var i in list)
            {
                if (i%2 == 0)
                {
                    evenInts.Add(i);
                }
            }
            return evenInts;
        }


        [Test]
        public void SumOfSquares()
        {
            List<int> list = GetListOf(100);

            int sum = 0;

            foreach (var i in list)
            {
                sum += i*i;
            }

            Console.Out.WriteLine("sum = {0}", sum);
        }

        [Test]
        public void SumOfNums()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < 100; i++)
                list.Add(i + 1);

            int sum = GetSum(list);

            Console.Out.WriteLine("sum = {0}", sum);
        }

        [Test]
        public void SumOfSquares2()
        {
            List<int> list = GetListOf(100);

            List<int> squares = new List<int>();

            foreach (var i in list)
                squares.Add(i*i);

            int sum = GetSum(squares);

            Console.Out.WriteLine("sum = {0}", sum);
        }

        [Test]
        public void SumOfCubes()
        {
            List<int> list = GetListOf(100);

            List<int> cubes = new List<int>();

            foreach (var i in list)
                cubes.Add(i*i*i);

            int sum = GetSum(cubes);

            Console.Out.WriteLine("sum = {0}", sum);
        }

        private int GetSum(List<int> squares)
        {
            int sum = 0;
            foreach (var i in squares)
            {
                sum += i;
            }
            return sum;
        }


        [Test]
        public void Points()
        {
            var rover = new Rover {pos = new Point(0, 0)};
            Point point = rover.pos;
            point.Offset(1, 2);
            Assert.That(rover.pos, Is.EqualTo(new Point(1, 2)));
        }

        [Test]
        public void MergeLists()
        {
            List<int> list1 = new List<int> {2, 1, 4};
            List<int> list2 = new List<int> {7, 3, 8};

            List<int> list3 = concat(list1, list2);

            list1.Sort();
            list2.Sort();

            Assert.That(list3, Is.EqualTo(new List<int> {1, 2, 4, 3, 7, 8}));
        }

        private List<int> concat(List<int> list1, List<int> list2)
        {
            List<int> list = new List<int>(list1);
            list.AddRange(list2);
            return list;
        }
    }

    public class Rover
    {
        public Point pos { get; set; }
    }
}