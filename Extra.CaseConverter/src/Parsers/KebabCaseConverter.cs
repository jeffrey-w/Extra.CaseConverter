namespace Extra.CaseConverter.Parsers;

internal class KebabCaseConverter : BaseParser
{
    protected override string Pattern => "[^-]";
}
