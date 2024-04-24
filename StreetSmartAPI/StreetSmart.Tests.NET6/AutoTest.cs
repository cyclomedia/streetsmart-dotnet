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
        public async Task ApiLoginWithBasicAuthTest()
        {
            var result = await _fixture.InitWithBasicAuth();
            Assert.Equal(State.ApiInitialized, result);
        }

        [Fact]
        public async Task ApiDestroyWithBasicAuthTest()
        {
            var result = await _fixture.Destroy();
            Assert.Equal(State.ApiReady, result);
        }
    }
}
