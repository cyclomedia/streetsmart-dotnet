namespace StreetSmart.Tests.NET6
{
    public class AutoTest
    {
        private readonly ApiFixture _fixture;
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
