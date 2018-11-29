using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Tests.Generic;
using Tests.TestUtilities;

namespace Tests.NonGeneric
{
    [GenericFixtureSource]
    public class NonGenericFixtureWithSource
    {
        private readonly string myArgument;

        public NonGenericFixtureWithSource(string argument)
        {
            myArgument = argument;
        }

        [Test]
        public void Foo()
        {
            Thread.Sleep(150);
        }
    }

    public class NonGenericFixtureSourceAttribute : CustomFixtureSourceAttribute
    {
        protected override IEnumerable<ITestFixtureData> Fixtures
        {
            get
            {
                yield return new TestFixtureData("Foo");
                yield return new TestFixtureData("Bar");
            }
        }
    }
}