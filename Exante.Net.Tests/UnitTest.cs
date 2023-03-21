using System.Diagnostics;
using Exante.Net.Enums;
using NUnit.Framework;

namespace Exante.Net.Tests;

public class Tests
{
    private static ExanteClient CreateExanteClient()
    {
        var clientId = Environment.GetEnvironmentVariable("EXANTE_CLIENT_ID");
        var applicationId = Environment.GetEnvironmentVariable("EXANTE_APPLICATION_ID");
        var sharedKey = Environment.GetEnvironmentVariable("EXANTE_SHARED_KEY");
        const ExantePlatformType platformType = ExantePlatformType.Demo;

        Debug.Assert(clientId != null, nameof(clientId) + " != null");
        Debug.Assert(applicationId != null, nameof(applicationId) + " != null");
        Debug.Assert(sharedKey != null, nameof(sharedKey) + " != null");

        var exanteClientOptions =
            new ExanteClientOptions(
                new ExanteApiCredentials(
                    clientId,
                    applicationId,
                    sharedKey
                ),
                platformType
            );
        var exanteClient = new ExanteClient(exanteClientOptions);
        return exanteClient;
    }

    [Test]
    public void AccountSummaryWorks()
    {
        var exanteClient = CreateExanteClient();
        var accountId = Environment.GetEnvironmentVariable("EXANTE_ACCOUNT_ID");
        Debug.Assert(accountId != null, nameof(accountId) + " != null");
        var accountSummary = exanteClient.GetAccountSummaryAsync(accountId, "USD").Result;

        Assert.IsTrue(accountSummary.Success);
    }
}