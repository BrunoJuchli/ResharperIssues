using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Tests.Generic;
using Tests.TestUtilities;

namespace Tests.NonGeneric
{
    [GenericFixtureSource]
    public class NonGenericWithFixtureSource
    {
        private readonly string myArgument;

        public NonGenericWithFixtureSource(string argument)
        {
            myArgument = argument;
        }

        [Test]
        public void Foo()
        {
            Thread.Sleep(3000);
        }
    }

    public class NonGenericFixtureSourceAttribute : AbstractTheoryAttribute
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