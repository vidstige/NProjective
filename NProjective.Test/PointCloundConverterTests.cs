using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NProjective.Test
{
    [TestClass]
    public class PointCloundConverterTests
    {
        [TestMethod]
        public void Foobar()
        {
            var converter = new PointCloundConverter();
            short[] buffer = new short[9] { 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000 };
            var result = converter.Convert(buffer, 3, 3, 3, 525);

            //Assert.AreEqual(new Point3d(0, 0, 0), result[0]);
            //Assert.AreEqual(new Point3d(0, 0, 0), result[1]);
            //Assert.AreEqual(new Point3d(1, 1, 1), result[2]);
            //Assert.AreEqual(new Point3d(1, 1, 1), result[3]);
            //Assert.AreEqual(new Point3d(1, 1, 1), result[4]);
            //Assert.AreEqual(new Point3d(1, 1, 1), result[5]);
            //Assert.AreEqual(new Point3d(1, 1, 1), result[6]);
            //Assert.AreEqual(new Point3d(1, 1, 1), result[7]);
            //Assert.AreEqual(new Point3d(1, 1, 1), result[8]);
        }
    }
}
