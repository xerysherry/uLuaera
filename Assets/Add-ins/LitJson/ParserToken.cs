#region Header
/**
 * ParserToken.cs
 *   Internal representation of the tokens used by the lexer and the parser.
 *
 * The authors disclaim copyright to this source code. For more details, see
 * the COPYING file included with this distribution.
 **/
#endregion


namespace LitJson
{
    internal enum ParserToken
    {
        // Lexer tokens (see section A.1.1. of the manual)
        /// <summary>65536</summary>
        None = System.Char.MaxValue + 1,
        /// <summary>65537</summary>
        Number,
        /// <summary>65538</summary>
        True,
        /// <summary>65539</summary>
        False,
        /// <summary>65540</summary>
        Null,
        /// <summary>65541</summary>
        CharSeq,
        // Single char
        /// <summary>65542</summary>
        Char,

        // Parser Rules (see section A.2.1 of the manual)
        /// <summary>65543</summary>
        Text,
        /// <summary>65544</summary>
        Object,
        /// <summary>65545</summary>
        ObjectPrime,
        /// <summary>65546</summary>
        Pair,
        /// <summary>65547</summary>
        PairRest,
        /// <summary>65548</summary>
        Array,
        /// <summary>65549</summary>
        ArrayPrime,
        /// <summary>65550</summary>
        Value,
        /// <summary>65551</summary>
        ValueRest,
        /// <summary>65552</summary>
        String,

        // End of input
        /// <summary>65553</summary>
        End,

        // The empty rule
        /// <summary>65554</summary>
        Epsilon
    }
}
