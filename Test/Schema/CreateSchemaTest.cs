using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Context;
using Xunit;

namespace Test.Schema
{
    public class CreateSchemaCleanTest : IClassFixture<TestDataBaseFixture>
    {
        [Fact]
        public void CreateSchemaCleanEmpty()
        {

        }
    }
}
