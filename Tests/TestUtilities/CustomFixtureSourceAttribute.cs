using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework.Interfaces;
using IFixtureBuilder = NUnit.Framework.Interfaces.IFixtureBuilder;
using ITestFixtureData = NUnit.Framework.Interfaces.ITestFixtureData;
using ITypeInfo = NUnit.Framework.Interfaces.ITypeInfo;
using NUnitAttribute = NUnit.Framework.NUnitAttribute;
using NUnitTestFixtureBuilder = NUnit.Framework.Internal.Builders.NUnitTestFixtureBuilder;
using TestFixtureParameters = NUnit.Framework.Internal.TestFixtureParameters;
using TestSuite = NUnit.Framework.Internal.TestSuite;

namespace Tests.TestUtilities
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public abstract class CustomFixtureSourceAttribute : NUnitAttribute, IFixtureBuilder
    {
        private readonly NUnitTestFixtureBuilder builder = new NUnitTestFixtureBuilder();

        protected abstract IEnumerable<ITestFixtureData> Fixtures { get; }

        /// <summary>
        /// Gets or sets the category associated with every fixture created from
        /// this attribute. May be a single category or a comma-separated list.
        /// </summary>
        public string Category { get; set; }

        public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
        {
            foreach (ITestFixtureData fixtureParameters in this.RetrieveParameters())
                yield return this.builder.BuildFrom(typeInfo, new PreFilter(), fixtureParameters);
        }

        private IEnumerable<ITestFixtureData> RetrieveParameters()
        {
            try
            {
                List<ITestFixtureData> testFixtureDataList = this.Fixtures.ToList();
                if (this.Category != null)
                {
                    string category = this.Category;
                    char[] chArray = new char[1] { ',' };
                    foreach (string str in category.Split(chArray))
                    {
                        testFixtureDataList.ForEach(x => x.Properties.Add("Category", str));
                    }
                }

                return testFixtureDataList;
            }
            catch (Exception ex)
            {
                return new List<ITestFixtureData>
                {
                    new TestFixtureParameters(ex)
                };
            }
        }

        private class PreFilter : IPreFilter
        {
            public bool IsMatch(Type type)
            {
                return true;
            }

            public bool IsMatch(Type type, MethodInfo method)
            {
                return true;
            }
        }
    }
}