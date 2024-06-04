using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetSmart.Tests.NET6
{
    public class AutoTest
    {
        private ApiFixture _fixture;
        public AutoTest()
        {
            _fixture = new ApiFixture();
        }

        [Fact]
        public void ApiLoginWithBasicAuthTest()
        {
            Assert.True(_fixture.InitWithBasicAuth().Result == State.ApiInitialized);
        }
        [Fact]
        public void ApiDestroyWithBasicAuthTest()
        {
            Assert.True(_fixture.Destroy().Result == State.ApiReady);
        }
    }
}
