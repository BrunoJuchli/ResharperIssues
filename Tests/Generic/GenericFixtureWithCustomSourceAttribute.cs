using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Tests.TestUtilities;

namespace Tests.Generic
{
    [GenericFixtureSource]
    public class GenericFixtureWithCustomSourceAttribute<T>
    {
        private readonly T myDependency;

        public GenericFixtureWithCustomSourceAttribute(T dependency)
        {
            this.myDependency = dependency;
        }

        [Test]
        public void Foo()
        {
            Thread.Sleep(150);
        }
    }


    public class GenericFixtureSourceAttribute : CustomFixtureSourceAttribute
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