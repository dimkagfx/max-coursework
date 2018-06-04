using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Common;

namespace Open.Tests.Data.Common {
    [TestClass] public class TemporalDbRecordTests : ObjectTests<TemporalDbRecord> {
        private class testClass : TemporalDbRecord { }
        protected override TemporalDbRecord getRandomTestObject() {
            return GetRandom.Object<testClass>();
        }
        [TestMethod] public void IsAbstract() {
            Assert.IsTrue(typeof(TemporalDbRecord).IsAbstract);
        }
        [TestMethod] public void BaseTypeIsRootObjectDbRecord() {
            Assert.AreEqual(typeof(RootObject), typeof(TemporalDbRecord).BaseType);
        }
        [TestMethod] public void ValidFromTest() {
            DateTime rnd() => GetRandom.DateTime(null, obj.ValidTo.AddYears(-1));
            testReadWriteProperty(() => obj.ValidFrom, x => obj.ValidFrom = x, rnd);
        }
        [TestMethod] public void ValidToTest() {
            DateTime rnd() => GetRandom.DateTime(obj.ValidFrom.AddYears(1));
            testReadWriteProperty(() => obj.ValidTo, x => obj.ValidTo = x, rnd);
        }
        [TestMethod] public void CreateValidFromGreaterThanValidToTest() {
            var dt = GetRandom.DateTime(obj.ValidTo.AddYears(1));
            var validTo = obj.ValidTo;
            Assert.IsTrue(dt > validTo);
            obj.ValidFrom = dt;
            Assert.AreEqual(validTo, obj.ValidFrom);
            Assert.AreEqual(dt, obj.ValidTo);

        }
    }
}



