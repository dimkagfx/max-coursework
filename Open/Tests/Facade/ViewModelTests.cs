using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Facade {
    public abstract class ViewModelTests<TClass, TBaseClass> : ObjectTests<TClass> {
        [TestMethod] public void BaseClassTest() {
            Assert.IsInstanceOfType(obj, typeof(TBaseClass));
        }
    }
}
