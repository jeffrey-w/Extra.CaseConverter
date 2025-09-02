namespace Extra.CaseConverter.Compilers;

internal class KebabCaseCompiler : ICompiler
{
    public static readonly ICompiler Instance = new KebabCaseCompiler();

    private KebabCaseCompiler()
    {
    }

    public string Compile(string[] input)
    {
        return string.Join('-', input);
    }
}
