using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace ApiIntegrationTests;

public static class AssemblyInitializer
{
    public static void Initialize()
    {
        VerifySettings.Initialize();
    }
} 