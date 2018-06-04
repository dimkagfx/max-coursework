using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
namespace Open.Tests.Facade.Common {
    [TestClass] public class UniqueEntityViewModelTests : ObjectTests<UniqueEntityViewModel> {
        protected override UniqueEntityViewModel getRandomTestObject() {
            return GetRandom.Object<UniqueEntityViewModel>();
        }

        [TestMethod] public void IsTemporalViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(TemporalViewModel));
        }

        [TestMethod] public void IDTest() {
            testReadWriteProperty(() => obj.ID, x => obj.ID = x);
        }
    }
}




