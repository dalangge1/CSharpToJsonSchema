using H.Generators;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using CSharpToJsonSchema.Generators.Core.Conversion;

namespace CSharpToJsonSchema.Generators;

[Generator]
public class JsonSchemaGenerator : IIncrementalGenerator
{
    #region Constants

    public const string Name = nameof(JsonSchemaGenerator);
    public const string Id = "OATG";

    #endregion

    #region Methods

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var attributes =
            context.SyntaxProvider
                .ForAttributeWithMetadataName("CSharpToJsonSchema.GenerateJsonSchemaAttribute")
                .SelectManyAllAttributesOfCurrentInterfaceSyntax()
                .SelectAndReportExceptions(PrepareData, context, Id);
        
        attributes
            .SelectAndReportExceptions(AsTools, context, Id)
            .AddSource(context);
        attributes
            .SelectAndReportExceptions(AsCalls, context, Id)
            .AddSource(context);
    }
    
    private static InterfaceData PrepareData(
        (SemanticModel SemanticModel, AttributeData AttributeData, InterfaceDeclarationSyntax InterfaceSyntax, INamedTypeSymbol InterfaceSymbol) tuple)
    {
        var (_, attributeData, _, interfaceSymbol) = tuple;

        return interfaceSymbol.PrepareData(attributeData);
    }
    
    private static FileWithName AsTools(InterfaceData @interface)
    {
        return new FileWithName(
            Name: $"{@interface.Name}.Tools.generated.cs",
            Text: Sources.GenerateClientImplementation(@interface));
    }
    
    private static FileWithName AsCalls(InterfaceData @interface)
    {
        return new FileWithName(
            Name: $"{@interface.Name}.Calls.generated.cs",
            Text: Sources.GenerateCalls(@interface));
    }

    #endregion
}