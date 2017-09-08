#region Assembly Bluestep.Services.TestUtil, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// C:\Users\morga\Source\Repos\ServiceLayer\Bluestep.Services\packages\Bluestep.Services.TestUtil.1.0.4\lib\net452\Bluestep.Services.TestUtil.dll
#endregion

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableWebApi.Tests
{
    public abstract class UnitTest
    {
        protected UnitTest()
        {
        }

        [TestInitialize]
        public virtual void PerformTest()
        {
            SetupDependencies();
            Act();
        }
        [TestCleanup]
        public virtual void TearDownDepencencies() { }
        protected abstract void Act();
        protected abstract void SetupDependencies();
    }
}