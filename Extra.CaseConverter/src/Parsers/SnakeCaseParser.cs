namespace Extra.CaseConverter.Parsers;

internal class SnakeCaseParser : BaseParser
{
    protected override string Pattern => "[^_]";
}
