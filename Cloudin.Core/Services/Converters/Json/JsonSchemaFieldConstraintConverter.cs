using System.Text.Json;
using System.Text.Json.Serialization;

using Cloudin.Core.Interfaces.Entities;
using Cloudin.Core.Interfaces.Services.Converters;

namespace Cloudin.Core.Services.Converters.Json;

public class JsonSchemaFieldConstraintConverter
    : JsonConverter<ISchemaFieldConstraint>,
        ISchemaFieldConstraintConverter
{
    public static JsonSerializerOptions GetSerializerOptions() =>
        new() { Converters = { new JsonSchemaFieldConstraintConverter() } };

    public static ISchemaFieldConstraint? FromString(string value) =>
        JsonSerializer.Deserialize<ISchemaFieldConstraint>(
            json: value,
            options: GetSerializerOptions()
        );

    public override ISchemaFieldConstraint? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return reader.GetString()?.ToLowerInvariant() switch
        {
            "systemfield" => new SystemFieldConstraint(),
            "required" => new RequiredFieldConstraint(),
            "unique" => new UniqueFieldConstraint(),
            _ => null
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ISchemaFieldConstraint value,
        JsonSerializerOptions options
    )
    {
        throw new NotImplementedException();
    }
}
