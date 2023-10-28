using System.Text.Json;
using Cloudin.Core.Interfaces.Entities;
using Cloudin.Core.Services.Converters.Json;

namespace Cloudin.Tests.Core.Services.Converters.Json;

[TestClass]
public class JsonSchemaFieldConstraintConverterTests
{
    [TestMethod]
    [DataRow(@"""SystemField""", typeof(SystemFieldConstraint))]
    [DataRow(@"""required""", typeof(RequiredFieldConstraint))]
    [DataRow(@"""UNIQUE""", typeof(UniqueFieldConstraint))]
    public void Deserialize_Single(string jsonString, Type type)
    {
        var constraint = JsonSerializer.Deserialize<ISchemaFieldConstraint>(
            json: jsonString,
            options: JsonSchemaFieldConstraintConverter.GetSerializerOptions()
        );

        Assert.IsNotNull(constraint);
        Assert.IsInstanceOfType(value: constraint, expectedType: type);
    }

    [TestMethod]
    public void Deserialize_Single_Many()
    {
        var jsonString = @"[""required"", ""SystemField"", ""unique""]";

        var constraints = JsonSerializer.Deserialize<ISchemaFieldConstraint[]>(
            json: jsonString,
            JsonSchemaFieldConstraintConverter.GetSerializerOptions()
        );

        Assert.IsNotNull(constraints);
        Assert.AreEqual(expected: 3, actual: constraints.Length);
    }
}
