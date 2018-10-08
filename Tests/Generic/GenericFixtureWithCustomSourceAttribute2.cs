using System.Collections;
using System.Threading;
using NUnit.Framework;
using Tests.TestUtilities;

namespace Tests.Generic
{
    [GenericFixtureSource]
    public class GenericFixtureWithCustomSourceAttribute2<T>
    {
        private readonly T myDependency;

        public GenericFixtureWithCustomSourceAttribute2(T dependency)
        {
            this.myDependency = dependency;
        }

        [Test]
        public void Foo()
        {
            Thread.Sleep(5000);
        }
    }


    public class GenericFixtureSource2Attribute : TestFixtureSourceAttribute
    {
        public GenericFixtureSource2Attribute() : base(typeof(GenericFixtureSource2Attribute), nameof(Fixtures))
        {
        }

        public static IEnumerable Fixtures
        {
            get
            {
                yield return new TypedTestFixture<object>("one");
                yield return new TypedTestFixture<string>("two");
            }
        }
    }
}