namespace Cloudin.Core.Interfaces.Entities;

public class SchemaField
{
    /// <summary>
    /// /// Unique identifier for this field
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Name that will be displayed
    /// </summary>
    public required string DisplayName { get; set; }

    /// <summary>
    /// ID used for accessing this schema through the API
    /// </summary>
    public required string AppId { get; set; }

    /// <summary>
    /// Displays a hint for content editors and API users
    /// </summary>
    public string? Description { get; set; }

}

