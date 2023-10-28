namespace Cloudin.Core.Interfaces.Entities;

public record ISchemaFieldConstraint(string DisplayName);

public record ISchemaFieldType(string DisplayName, Type Type);

public class SchemaField
{
    /// <summary>
    /// /// Unique identifier for this field
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// ID used for accessing this schema through the API
    /// </summary>
    public required string AppId { get; set; }

    /// <summary>
    /// Name that will be displayed
    /// </summary>
    public required string DisplayName { get; set; }

    /// <summary>
    /// Represents the Type of the Field
    /// </summary>
    public required ISchemaFieldType Type { get; set; }

    /// <summary>
    /// Displays a hint for content editors and API users
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Represents the constraints of the field
    /// </summary>
    public IEnumerable<ISchemaFieldConstraint> Constraints { get; set; } =
        new HashSet<ISchemaFieldConstraint>();
}

public record SystemFieldConstraint : ISchemaFieldConstraint
{
    public SystemFieldConstraint() : base("System field") { }
}

public record RequiredFieldConstraint : ISchemaFieldConstraint
{
    public RequiredFieldConstraint() : base("Required") { }
}

public record UniqueFieldConstraint : ISchemaFieldConstraint
{
    public UniqueFieldConstraint() : base("Unique") { }
}

public record StringFieldType : ISchemaFieldType
{
    public StringFieldType() : base(DisplayName: "Text", Type: typeof(string)) { }
}

public record DateTimeFieldType : ISchemaFieldType
{
    public DateTimeFieldType() : base(DisplayName: "DateTime", Type: typeof(DateTime)) { }
}
