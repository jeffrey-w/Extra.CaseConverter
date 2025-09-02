using Extra.CaseConverter.Compilers;
using Extra.CaseConverter.Parsers;

namespace Extra.CaseConverter;

/// <summary>
/// The <c>Instance</c> class provides operations for transforming a string from
/// one case to another.
/// </summary>
public static class Instance
{
    /// <summary>
    /// Indicates that the specified <paramref name="input" /> string is to be
    /// transformed from one case to another.
    /// </summary>
    /// <param name="input">The <see cref="string" /> to convert.</param>
    /// <returns>A new <see cref="SourceCaseSelector" />.</returns>
    public static SourceCaseSelector Convert(string input)
    {
        return new SourceCaseSelector(input);
    }

    internal enum Case
    {
        Camel,
        Pascal,
        Snake,
        Kebab,
        Space,
    }

    /// <summary>
    /// The <c>SourceCaseSelector</c> class provides a means for indicating the current
    /// case of an input string.
    /// </summary>
    public sealed class SourceCaseSelector
    {
        private readonly string _input;

        internal SourceCaseSelector(string input)
        {
            _input = input;
        }

        /// <summary>
        /// Indicates that the input supplied to this <c>SourceCaseSelector</c> is in camel
        /// case.
        /// </summary>
        /// <returns>A new <see cref="TargetCaseSelector" />.</returns>
        public TargetCaseSelector FromCamel()
        {
            return new TargetCaseSelector(_input, Case.Camel);
        }

        /// <summary>
        /// Indicates that the input supplied to this <c>SourceCaseSelector</c> is in
        /// Pascal case.
        /// </summary>
        /// <returns>A new <see cref="TargetCaseSelector" />.</returns>
        public TargetCaseSelector FromPascal()
        {
            return new TargetCaseSelector(_input, Case.Pascal);
        }

        /// <summary>
        /// Indicates that the input supplied to this <c>SourceCaseSelector</c> is in snake
        /// case.
        /// </summary>
        /// <returns>A new <see cref="TargetCaseSelector" />.</returns>
        public TargetCaseSelector FromSnake()
        {
            return new TargetCaseSelector(_input, Case.Snake);
        }

        /// <summary>
        /// Indicates that the input supplied to this <c>SourceCaseSelector</c> is in kebab
        /// case.
        /// </summary>
        /// <returns>A new <see cref="TargetCaseSelector" />.</returns>
        public TargetCaseSelector FromKebab()
        {
            return new TargetCaseSelector(_input, Case.Kebab);
        }

        /// <summary>
        /// Indicates that the input supplied to this <c>SourceCaseSelector</c> is in space
        /// case.
        /// </summary>
        /// <returns>A new <see cref="TargetCaseSelector" />.</returns>
        public TargetCaseSelector FromSpace()
        {
            return new TargetCaseSelector(_input, Case.Space);
        }
    }

    /// <summary>
    /// The <c>TargetCaseSelector</c> class provides a means for indicating the desired
    /// case of an input string.
    /// </summary>
    public sealed class TargetCaseSelector
    {
        private static readonly Dictionary<Case, IParser> Parsers = new()
        {
            { Case.Camel, new CamelAndPascalCaseParser() },
            { Case.Pascal, new CamelAndPascalCaseParser() },
            { Case.Snake, new SnakeCaseParser() },
            { Case.Kebab, new KebabCaseConverter() },
            { Case.Space, new SpaceCaseParser() },
        };

        private readonly string[] _input;

        internal TargetCaseSelector(string input, Case from)
        {
            _input = Parsers[from]
               .Parse(input);
        }

        /// <summary>
        /// Provides the input supplied to this <c>TargetCaseSelector</c> in camel case.
        /// </summary>
        /// <returns>A new string.</returns>
        public string ToCamel()
        {
            return CamelAndPascalCaseCompiler.Camel.Compile(_input);
        }

        /// <summary>
        /// Provides the input supplied to this <c>TargetCaseSelector</c> in Pascal case.
        /// </summary>
        /// <returns>A new string.</returns>
        public string ToPascal()
        {
            return CamelAndPascalCaseCompiler.Pascal.Compile(_input);
        }

        /// <summary>
        /// Provides the input supplied to this <c>TargetCaseSelector</c> in snake case.
        /// </summary>
        /// <returns>A new string.</returns>
        public string ToSnake()
        {
            return SnakeCaseCompiler.Regular.Compile(_input);
        }

        /// <summary>
        /// Provides the input supplied to this <c>TargetCaseSelector</c> in upper snake
        /// case.
        /// </summary>
        /// <returns>A new string.</returns>
        public string ToUpperSnake()
        {
            return SnakeCaseCompiler.Upper.Compile(_input);
        }

        /// <summary>
        /// Provides the input supplied to this <c>TargetCaseSelector</c> in kebab case.
        /// </summary>
        /// <returns>A new string.</returns>
        public string ToKebab()
        {
            return KebabCaseCompiler.Instance.Compile(_input);
        }

        /// <summary>
        /// Provides the input supplied to this <c>TargetCaseSelector</c> in space case.
        /// </summary>
        /// <returns>A new string.</returns>
        public string ToSpace()
        {
            return SpaceCaseCompiler.Instance.Compile(_input);
        }
    }
}
