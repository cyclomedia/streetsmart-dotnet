namespace StreetSmart.WinForms.Tests
{
    public class AutoTest : IClassFixture<ApiFixture>
    {
        private readonly ApiFixture _fixture;
        public AutoTest(ApiFixture fixture)
        {
            _fixture = fixture;
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
