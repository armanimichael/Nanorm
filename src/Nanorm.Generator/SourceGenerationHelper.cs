﻿using System.Text;
using Microsoft.CodeAnalysis;

namespace Nanorm.Generator;

internal static class SourceGenerationHelper
{
    public static readonly Dictionary<string, string> GetMethodsMap = new()
    {
        { "byte", "GetByte" },
        { "short", "GetInt16" },
        { "int", "GetInt32" },
        { "long", "GetInt64" },
        { "float", "GetFloat" },
        { "double", "GetDouble" },
        { "decimal", "GetDecimal" },
        { "string", "GetString" },
        { "bool", "GetBoolean" },
        { "System.Guid", "GetGuid" },
        { "char", "GetChar" },
        { "System.DateTime", "GetDateTime" },
        
        { "byte?", "GetNullableByte" },
        { "short?", "GetNullableInt16" },
        { "int?", "GetNullableInt32" },
        { "long?", "GetNullableInt64" },
        { "float?", "GetNullableFloat" },
        { "double?", "GetNullableDouble" },
        { "decimal?", "GetNullableDecimal" },
        { "string?", "GetNullableString" },
        { "bool?", "GetNullableBoolean" },
        { "System.Guid?", "GetNullableGuid" },
        { "char?", "GetNullableChar" },
        { "System.DateTime?", "GetNullableDateTime" }
    };

    public static bool IsMappableType(ITypeSymbol typeSymbol) => GetMethodsMap.ContainsKey(typeSymbol.ToString());

    public static string GenerateExtensionTypes(List<TypeToGenerate> typesToGenerate)
    {
        var sb = new StringBuilder();
        sb.AppendLine("using global::Nanorm;");

        foreach (var typeToGenerate in typesToGenerate)
        {
            if (!string.IsNullOrEmpty(typeToGenerate.Namespace))
            {
                sb.AppendLine($$"""
            namespace {{typeToGenerate.Namespace}}
            {
            """);
            }

            sb.AppendLine($$"""
                partial {{ToKeyword(typeToGenerate.Kind)}} {{typeToGenerate.Identifier}} : IDataRecordMapper<{{typeToGenerate.Name}}>
                {
                    public static {{typeToGenerate.Name}} Map(global::System.Data.IDataRecord dataRecord) =>
                        new()
                        {
            """);

            sb.AppendLine($$"""
                            // {{typeToGenerate.Members.Count}} members
            """);

            foreach (var member in typeToGenerate.Members)
            {
                // TODO: Optimize this by setting backing field directly using UnsafeAccessor in .NET 8
                sb.AppendLine($"""
                            {member.Name} = dataRecord.{GetMethodsMap[member.Type.ToString()]}("{member.ColumnName}"),
            """);
            }

            // Close the Map method
            sb.AppendLine("""
                        };
            """);

            // Close the class
            sb.AppendLine("""
                }
            """);

            if (!string.IsNullOrEmpty(typeToGenerate.Namespace))
            {
                // Close the namespace
                sb.AppendLine("""
            }
            """);
            }
        }

        return sb.ToString();
    }

    public static string ToKeyword(TypeKind typeKind) => typeKind switch
    {
        TypeKind.Class => "class",
        TypeKind.Struct or TypeKind.Structure => "struct",
        _ => throw new InvalidOperationException(),
    };
}
