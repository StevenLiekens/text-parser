namespace TextFx
{
    using System;

    /// <summary>Provides the base interface for types that process the lexical syntax of a language.</summary>
    public interface ILexer
    {
        /// <summary>Attempts to read the next element. A return value indicates whether the element was available.</summary>
        /// <param name="scanner">The scanner object that provides text symbols as well as contextual information about the text source.</param>
        /// <param name="previousElementOrNull">The previous element, if any.</param>
        /// <exception cref="ObjectDisposedException">The given text scanner is closed.</exception>
        /// <returns>A value container that contains the next available element, or a <c>null</c> reference, depending on whether the return value indicates success.</returns>
        ReadResult<Element> ReadElement(ITextScanner scanner, Element previousElementOrNull);
    }
}