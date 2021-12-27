using System;
using System.Threading.Tasks;
using Xunit;

namespace libanvl.monkey.meta.test;

public class RunnerTests
{
    [Fact]
    public async Task RunAsync_Returns0_ForSuccess()
    {
        Assert.Equal(0, await new Runner().RunAsync(Array.Empty<string>()));
    }
}