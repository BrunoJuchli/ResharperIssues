using System.Collections;
using System.Threading;
using NUnit.Framework;
using Tests.TestUtilities;

namespace Tests.Generic
{
    [GenericFixtureSource2]
    public class GenericFixtureWithCustomSourceAttribute2<T>
    {
        private readonly Container<T> myDependency;

        public GenericFixtureWithCustomSourceAttribute2(Container<T> dependency)
        {
            this.myDependency = dependency;
        }

        [Test]
        public void Foo()
        {
            Thread.Sleep(150);
        }
    }

    public class Container<T>
    {
        public T Value { get; }

        public Container(T value)
        {
            Value = value;
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
                yield return new TypedTestFixture<object>(new Container<object>("one"));
                yield return new TypedTestFixture<string>(new Container<string>("two"));
            }
        }
    }
}