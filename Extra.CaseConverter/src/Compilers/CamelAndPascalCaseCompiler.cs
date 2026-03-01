using System.Text;

namespace Extra.CaseConverter.Compilers;

internal class CamelAndPascalCaseCompiler : ICompiler
{
    public static readonly ICompiler Camel = new CamelAndPascalCaseCompiler(false);
    public static readonly ICompiler Pascal = new CamelAndPascalCaseCompiler(true);

    private readonly bool _pascal;

    private CamelAndPascalCaseCompiler(bool pascal)
    {
        _pascal = pascal;
    }

    public string Compile(string[] input)
    {
        return input
              .Skip(1)
              .Aggregate(
                   new StringBuilder(
                       _pascal
                           ? Convert(input.First())
                           : input
                            .First()
                            .ToLower()),
                   (builder, s) => builder.Append(Convert(s)),
                   builder => builder.ToString());
    }

    private static string Convert(string s)
    {
        return s.Any(char.IsLower)
            ? s
             .Skip(1)
             .Aggregate(
                  new StringBuilder(
                      char
                         .ToUpper(s.First())
                         .ToString()),
                  (builder, c) => builder.Append(char.ToLower(c)),
                  builder => builder.ToString())
            : s;
    }
}
