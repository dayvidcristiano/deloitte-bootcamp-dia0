using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MinhaApi.Test;

public class ProgramTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ProgramTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Program_DeveSubirAplicacao_ComSucesso()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/swagger");

        Assert.True(response.IsSuccessStatusCode);
    }
}
