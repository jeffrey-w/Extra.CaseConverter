namespace Extra.CaseConverter.Parsers;

internal class SpaceCaseParser : BaseParser
{
    protected override string Pattern => @"[^\s]";
}
