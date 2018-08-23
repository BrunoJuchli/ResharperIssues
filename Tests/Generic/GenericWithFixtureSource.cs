using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Tests.TestUtilities;

namespace Tests.Generic
{
    [GenericFixtureSource]
    public class GenericWithFixtureSource<T>
    {
        private readonly T myDependency;

        public GenericWithFixtureSource(T dependency)
        {
            this.myDependency = dependency;
        }

        [Test]
        public void Foo()
        {
            Thread.Sleep(5000);
        }
    }


    public class GenericFixtureSourceAttribute : AbstractTheoryAttribute
    {
        protected override IEnumerable<ITestFixtureData> Fixtures
        {
            get
            {
                yield return new TypedTestFixture<object>("one");
                yield return new TypedTestFixture<string>("two");
            }
        }
    }
}