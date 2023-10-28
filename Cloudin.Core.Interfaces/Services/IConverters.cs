using Cloudin.Core.Interfaces.Entities;

namespace Cloudin.Core.Interfaces.Services.Converters;

public interface IConverter<T>
{
    abstract static T? FromString(string value);
}

public interface ISchemaConverter : IConverter<SchemaEntity> { };

public interface ISchemaFieldConverter : IConverter<SchemaField> { };

public interface ISchemaFieldConstraintConverter : IConverter<ISchemaFieldConstraint> { };

public interface ISchemaFieldTypeConverter : IConverter<ISchemaFieldType> { };
