using System;
using NUnit.Framework;
using ITestFixtureData = NUnit.Framework.Interfaces.ITestFixtureData;
using TestParameters = NUnit.Framework.Internal.TestParameters;


namespace Tests.NunitTestCase
{
    public class GenericFixtureWithTypeAndDifferentClosedGenericTypeConstructorArgsContainer<T>
    {
        public GenericFixtureWithTypeAndDifferentClosedGenericTypeConstructorArgsContainer(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }

    public class GenericFixtureWithTypeAndDifferentClosedGenericTypeConstructorArgsSource
    {
        public static readonly ITestFixtureData[] Source =
        {
            new TypedTestFixture<string>(new GenericFixtureWithTypeAndDifferentClosedGenericTypeConstructorArgsContainer<string>("Foo")),
            new TypedTestFixture<object>(new GenericFixtureWithTypeAndDifferentClosedGenericTypeConstructorArgsContainer<object>("Bar"))
        };

        public class TypedTestFixture<T> : TestParameters, ITestFixtureData
        {
            public TypedTestFixture(params object[] arguments)
                : base(arguments)
            {
                TypeArgs = new[] { typeof(T) };
            }

            public Type[] TypeArgs { get; }
        }
    }

    [TestFixtureSource(typeof(GenericFixtureWithTypeAndDifferentClosedGenericTypeConstructorArgsSource), "Source")]
    public class GenericFixtureSourceWithTypeAndDifferentClosedGenericTypeConstructorArgs<T>
    {
        private readonly GenericFixtureWithTypeAndDifferentClosedGenericTypeConstructorArgsContainer<T> _arg;

        public GenericFixtureSourceWithTypeAndDifferentClosedGenericTypeConstructorArgs(GenericFixtureWithTypeAndDifferentClosedGenericTypeConstructorArgsContainer<T> arg)
        {
            _arg = arg;
        }

        [Test]
        public void SomeTest()
        {
            Assert.That(!_arg.Value.Equals(default(T)), "constructor argument was not injected");
        }
    }
}