using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnit
{
    [TestFixture]
    public class ProjectControllerNunitTest
    {
        [Test]
        public void twoIsTwo()
        {
            Assert.AreEqual(2, 32, "ow noooo");
        }
    }
}
