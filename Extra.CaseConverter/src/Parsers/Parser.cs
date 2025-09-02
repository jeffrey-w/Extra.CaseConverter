using System.Text.RegularExpressions;

namespace Extra.CaseConverter.Parsers;

internal interface IParser
{
    string[] Parse(string input);
}

internal abstract class BaseParser : IParser
{
    protected abstract string Pattern { get; }

    public string[] Parse(string input)
    {
        return Regex
              .Split(input, Pattern)
              .Where(s => !string.IsNullOrWhiteSpace(s))
              .ToArray();
    }
}
