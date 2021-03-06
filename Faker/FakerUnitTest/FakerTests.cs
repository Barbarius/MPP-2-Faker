﻿using System;
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
        private Bar bar;
        private EmptyConstructor emptyConstructor;

        [TestInitialize]
        public void SetUp()
        {
            faker = new Faker();
            foo = faker.Create<Foo>();
            bar = faker.Create<Bar>();
            emptyConstructor = faker.Create<EmptyConstructor>();
        }

        [TestMethod]
        public void ObjectGeneratorTest()
        {
            Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void CharGeneratorTest()
        {
            Assert.IsTrue((byte)foo.GetChar() > 0 && (byte)foo.GetChar() <= 255);
        }

        [TestMethod]
        public void ByteGeneratorTest()
        {
            Assert.IsTrue(foo.GetByte() != default(byte) && byte.MinValue <= foo.GetByte() && byte.MaxValue >= foo.GetByte());
        }

        [TestMethod]
        public void SByteGeneratorTest()
        {
            Assert.IsTrue(foo.GetSByte() != default(sbyte) && sbyte.MinValue <= foo.GetSByte() && sbyte.MaxValue >= foo.GetSByte());
        }

        [TestMethod]
        public void IntGeneratorTest()
        {
            Assert.IsTrue(foo.GetInt() != default(int) && int.MinValue <= foo.GetInt() && int.MaxValue >= foo.GetInt());
        }

        [TestMethod]
        public void UIntGeneratorTest()
        {
            Assert.IsTrue(foo.GetUInt() != default(uint) && uint.MinValue <= foo.GetUInt() && uint.MaxValue >= foo.GetUInt());
        }

        [TestMethod]
        public void ShortGeneratorTest()
        {
            Assert.IsTrue(foo.GetShort() != default(short) && short.MinValue <= foo.GetShort() && short.MaxValue >= foo.GetShort());
        }

        [TestMethod]
        public void USortGeneratorTest()
        {
            Assert.IsTrue(foo.GetUShort() != default(ushort) && ushort.MinValue <= foo.GetUShort() && ushort.MaxValue >= foo.GetUShort());
        }

        [TestMethod]
        public void LongGeneratorTest()
        {
            Assert.IsTrue(foo.GetLong() != default(long) && long.MinValue <= foo.GetLong() && long.MaxValue >= foo.GetLong());
        }

        [TestMethod]
        public void ULongGeneratorTest()
        {
            Assert.IsTrue(foo.GetULong() != default(ulong) && ulong.MinValue <= foo.GetULong() && ulong.MaxValue >= foo.GetULong());
        }

        [TestMethod]
        public void DecimalGeneratorTest()
        {
            Assert.IsTrue(foo.GetDecimal() != default(decimal) && decimal.MinValue <= foo.GetDecimal() && decimal.MaxValue >= foo.GetDecimal());
        }

        [TestMethod]
        public void FloatGeneratorTest()
        {
            Assert.IsTrue(foo.GetFloat() != default(float) && float.MinValue <= foo.GetFloat() && float.MaxValue >= foo.GetFloat());
        }

        [TestMethod]
        public void DoubleGeneratorTest()
        {
            Assert.IsTrue(foo.GetDouble() != default(double) && double.MinValue <= foo.GetDouble() && double.MaxValue >= foo.GetDouble());
        }

        [TestMethod]
        public void DateGeneratorTest()
        {
            DateTime empty = new DateTime();
            Assert.IsTrue(foo.GetDate() != empty);
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

        [TestMethod]
        public void EmptyConstructorGeneratorTest()
        {
            Assert.AreEqual(emptyConstructor, null);
        }

        [TestMethod]
        public void ReurciveGeneratorTest()
        {
            // 1 уровень рекурсии
            Assert.IsTrue(foo.GetBar() != null && foo.GetBar()._foo != null);
            Assert.IsTrue(bar._foo != null && bar._foo.GetBar() != null);

            // 2 уровень рекурсии
            Assert.IsTrue(foo.GetBar()._foo.GetBar() == null);
            Assert.IsTrue(bar._foo.GetBar()._foo == null);
        }

        [TestMethod]
        public void NonDTOFieldTest()
        {
            Assert.IsTrue(foo.justSimpleField == default(byte));
        }

        [TestMethod]
        public void NonDTOPropertyTest()
        {
            Assert.IsTrue(foo.NonDTOProperty == default(byte));
        }
    }
}
