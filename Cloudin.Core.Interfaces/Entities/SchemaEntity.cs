namespace Cloudin.Core.Interfaces.Entities;

public class SchemaEntity
{
    /// <summary>
    /// Name that will be displayed
    /// </summary>
    public required string DisplayName { get; set; }

    /// <summary>
    /// ID used for accessing this schema through the API
    /// </summary>
    public required string AppId { get; set; }

    /// <summary>
    /// Pluralized API ID for this schema
    /// </summary>
    public required string PluralAppId { get; set; }

    /// <summary>
    /// Displays a hint for content editors and API users
    /// </summary>
    public string? Description { get; set; }
}
