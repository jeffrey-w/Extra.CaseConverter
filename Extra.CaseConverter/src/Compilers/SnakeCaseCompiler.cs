namespace Extra.CaseConverter.Compilers;

internal class SnakeCaseCompiler : ICompiler
{
    public static readonly ICompiler Regular = new SnakeCaseCompiler(false);
    public static readonly ICompiler Upper = new SnakeCaseCompiler(true);

    private readonly bool _uppercase;

    private SnakeCaseCompiler(bool uppercase)
    {
        _uppercase = uppercase;
    }

    public string Compile(string[] input)
    {
        return string.Join('_', input.Select(s => _uppercase ? s.ToUpper() : s));
    }
}
