using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace checkout_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Checkout
    {
        List<char> items = new List<char>();
        public Checkout Scan(char item)
        {
            items.Add(item);
            return this;
        }

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in items)
            {
                switch (item)
                {
                    case 'A':
                        total += 50m;
                        break;
                    case 'B':
                        total += 30m;
                        break;
                }
            }
            return total;
        }
    }

    [TestFixture]
    public class TestSomething
    {
        [Test]
        public void CanScanOneItem()
        {
            var checkout = new Checkout();
            checkout.Scan('A');
            var actual = checkout.Total();
            actual.Should().Be(50m);
        }

        [Test]
        public void CanScanTwoOfSameItem()
        {
            var checkout = new Checkout();
            checkout.Scan('A').Scan('A');
            var actual = checkout.Total();
            actual.Should().Be(100m);
        }

        [Test]
        public void CanScanTwoDifferentItems()
        {
            var checkout = new Checkout();
            checkout.Scan('A').Scan('B');
            var actual = checkout.Total();
            actual.Should().Be(80m);
        }
    }
}
