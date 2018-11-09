using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLib;
using System.Collections.Generic;

namespace FakerUnitTest
{
    [TestClass]
    public class FakerTests
    {
        private Faker faker;
        private Foo foo;

        [TestInitialize]
        public void SetUp()
        {
            faker = new Faker();
            foo = faker.Create<Foo>();
        }

        [TestMethod]
        public void ObjectGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void CharGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void ByteGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void SByteGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void IntGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void UIntGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void ShortGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void USortGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void LongGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void ULongGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void DecimalGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void FloatGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void DoubleGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void DateGeneratorTest()
        {
            //Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void StringGeneratorTest()
        {
            Assert.IsTrue(foo.GetString() != null && foo.GetString() != String.Empty);
        }

        [TestMethod]
        public void ListGeneratorTest2()
        {
            Assert.IsTrue(foo.GetList() != null && foo.GetList() is List<short>);
        }

        [TestMethod]
        public void BarGeneratorTest()
        {
            Assert.IsTrue(foo.GetBar() != null && foo.GetBar()._string != null && foo.GetBar()._string != String.Empty);
        }
    }
}
