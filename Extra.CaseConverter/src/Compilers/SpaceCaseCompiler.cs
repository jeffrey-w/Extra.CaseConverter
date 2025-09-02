namespace Extra.CaseConverter.Compilers;

internal class SpaceCaseCompiler : ICompiler
{
    public static readonly ICompiler Instance = new SpaceCaseCompiler();

    private SpaceCaseCompiler()
    {
    }

    public string Compile(string[] input)
    {
        return string.Join(' ', input);
    }
}
