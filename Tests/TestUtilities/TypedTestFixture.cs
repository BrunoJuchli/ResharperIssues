using System;
using ITestFixtureData = NUnit.Framework.Interfaces.ITestFixtureData;
using TestParameters = NUnit.Framework.Internal.TestParameters;

namespace Tests.TestUtilities
{
    public class TypedTestFixture<T> : TestParameters, ITestFixtureData
    {
        public TypedTestFixture(params object[] arguments)
            : base(arguments)
        {
            this.TypeArgs = new[] { typeof(T) };
        }

        public Type[] TypeArgs { get; }
    }
}