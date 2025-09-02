namespace Extra.CaseConverter.Parsers;

internal class CamelAndPascalCaseParser : BaseParser
{
    protected override string Pattern => "([A-Z]+(?=[A-Z][a-z])|[A-Z]?[a-z]+|[A-Z]+|[0-9]+)";
}
