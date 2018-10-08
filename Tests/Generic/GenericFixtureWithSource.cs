using System.Collections;
using System.Threading;
using NUnit.Framework;
using Tests.TestUtilities;

namespace Tests.Generic
{
    [TestFixtureSource(typeof(GenericFixtureSourceHolder), nameof(GenericFixtureSourceHolder.Examples))]
    public class GenericFixtureWithSource<T>
    {
        private readonly T myDependency;

        public GenericFixtureWithSource(T dependency)
        {
            this.myDependency = dependency;
        }

        [Test]
        public void Foo()
        {
            Thread.Sleep(1000);
        }
    }

    public static class GenericFixtureSourceHolder
    {
        public static IEnumerable Examples
        {
            get
            {
                yield return new TypedTestFixture<object>("one");
                yield return new TypedTestFixture<string>("two");
            }
        }
    }
}