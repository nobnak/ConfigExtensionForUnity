using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestConfiguration {
    private const string C_K_A = "Category:Setting_Alpha";
    private const string C_V_A = "Value_Alpha";

    private const string C_K_B = "Category:Setting_Beta";
    private const string C_V_B = "Value_Beta";

    // A Test behaves as an ordinary method
    [Test]
    public void TestEnvironmentalVariable() {

        System.Environment.SetEnvironmentVariable(C_K_A, C_V_A);
        System.Environment.SetEnvironmentVariable(C_K_B, C_V_B);

        var builder = new ConfigurationBuilder();
        builder.AddEnvironmentVariables();

        var config = builder.Build();
        Assert.AreEqual(C_V_A, config[C_K_A]);
        Assert.AreEqual(C_V_B, config[C_K_B]);

    }
    [Test]
    public void TestJson() {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Application.streamingAssetsPath);
        builder.AddJsonFile("Config.json");

        var config = builder.Build();
        Assert.AreEqual(C_V_A, config[C_K_A]);
        Assert.AreEqual(C_V_B, config[C_K_B]);
    }
}
