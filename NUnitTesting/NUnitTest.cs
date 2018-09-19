using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTesting
{
    [TestFixture]
    public class NUnitTest
    {
        [Test]
        public void test()
        {
            Assert.AreEqual(1, 2, "ooooh noooo");
        }
    }
}
